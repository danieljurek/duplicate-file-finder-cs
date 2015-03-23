using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections.Specialized;
using System.IO;

namespace DFF1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            statusBottomStrip.Items[0].Text = "Welcome to Daniel's Duplicate File Finder"; 
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            folderbrwPathSelector.ShowDialog();

            if (folderbrwPathSelector.SelectedPath != "" && 
                !chklstboxSelectedPaths.Items.Contains(folderbrwPathSelector.SelectedPath))
            {
                chklstboxSelectedPaths.Items.Add(folderbrwPathSelector.SelectedPath); 
            }
        }

        private void btnRemovePath_Click(object sender, EventArgs e)
        {
            while (chklstboxSelectedPaths.CheckedItems.Count > 0)
            {
                chklstboxSelectedPaths.Items.Remove(chklstboxSelectedPaths.CheckedItems[0]); 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool nestedPaths = false;           // Bool to indicate if there are any nested paths (result in mass duplicates)

            treeviewDuplicates.Nodes.Clear();


            // Check for nested paths
            foreach (string path in chklstboxSelectedPaths.Items)
            {
                foreach (string otherPath in chklstboxSelectedPaths.Items)
                {
                    if (path != otherPath && otherPath.Contains(path))
                    {
                        nestedPaths = true;
                        break;
                    }
                }

                if (nestedPaths == true)
                {
                    break;
                }
            }

            // -----------------------------------------------------------------------------------------------------
            // Begin the search for duplicate files
            // -----------------------------------------------------------------------------------------------------

            if (nestedPaths)
            {
                MessageBox.Show("Make sure you're not searching a directory\nand a child directory at the same time", "Error: Nested Search");
            }
            else
            {
                beginSearch(); 
            }

        }

        // ------------------------------------------------------------------------------------------------------
        // Search related functions

        private void beginSearch()
        {
            Dictionary<long, StringCollection> sizeDictionary = new Dictionary<long, StringCollection>();
            Dictionary<int, StringCollection> hashDictionary = new Dictionary<int, StringCollection>();
            Dictionary<string, StringCollection> duplicateDictionary = new Dictionary<string, StringCollection>();

            long fileSize;

            int first1kHash;
            int i, j;                          // For indexing our favorite loops
            char[] buffer = new char[1024];

            // For performance measuring. 
            DateTime startTime = DateTime.Now;

            statusBottomStrip.Items[0].Text = "Indexing and sizing files...";
            statusBottomStrip.Refresh(); 

            foreach (string dir in chklstboxSelectedPaths.Items)
            {
                listFiles(dir, ref sizeDictionary);
            }

            long location;

            statusBottomStrip.Items[0].Text = "Hashing 1k of same sized files...";
            statusBottomStrip.Refresh(); 
            ////////////////////////////////////////////////////////////////////////////////////////////
            foreach (StringCollection files in sizeDictionary.Values)
            {
                // If there are duplicates
                if (files.Count > 1)
                {
                    foreach (string filename in files)
                    {
                        // Hash first 1k of each file  and put it in the dictionary
                        using (StreamReader filestream = new StreamReader(filename))
                        {

                            fileSize = filestream.BaseStream.Length;


                            if (fileSize <= 1024)
                            {
                                filestream.Read(buffer, 0, 1024);
                            }
                            else
                            {
                                location = 0;

                                for (i = 0; i < 1024; i++)
                                {
                                    filestream.Read(buffer, i, 1);
                                    filestream.BaseStream.Seek(location, SeekOrigin.Begin);
                                    location += fileSize / 1024;
                                }
                            }

                            first1kHash = charToString(buffer).GetHashCode();



                            // Add that hash to the dictionary
                            if (hashDictionary.ContainsKey(first1kHash))
                            {
                                hashDictionary[first1kHash].Add(filename);
                            }
                            else
                            {
                                StringCollection temp = new StringCollection();
                                temp.Add(filename);

                                hashDictionary.Add(first1kHash, temp);
                            }

                            filestream.BaseStream.Close();
                            filestream.BaseStream.Dispose();
                        }
                    }
                }
            }


            bool added = false;             // For adding new values to the dictionary

            statusBottomStrip.Items[0].Text = "Comparing files directly.";
            statusBottomStrip.Refresh(); 
            /////////////////////////////////////////////////////////////////////////////////////////////
            foreach (StringCollection files in hashDictionary.Values)
            {
                // If there are duplicates
                if (files.Count > 1)
                {
                    for (i = 0; i < files.Count; i++)
                    {
                        // Determine file size. 
                        // fileSize = File.OpenRead(files[i]).Length;
                        FileStream sizeGetter;
                        sizeGetter = File.OpenRead(files[i]);
                        fileSize = sizeGetter.Length;
                        sizeGetter.Close();
                        sizeGetter.Dispose(); 


                        for (j = i + 1; j < files.Count; j++)
                        {
                            // If the files are of the same size 
                            // if(fileSize == File.OpenRead(files[j]).Length)
                            if (sizeDictionary[fileSize].Contains(files[j]))
                            {
                                // Run a bytewise comparison
                                if (bytewiseFileCompare(files[i], files[j]))
                                {
                                    // The files really are the same, add them to the list
                                    if (duplicateDictionary.ContainsKey(files[i]))
                                    {
                                        duplicateDictionary[files[i]].Add(files[j]);
                                    }
                                    else
                                    {
                                        // Make sure that files[i] isn't listed
                                        foreach (StringCollection tmpFilenames in duplicateDictionary.Values)
                                        {
                                            if (tmpFilenames.Contains(files[i]))
                                            {
                                                // No duplicate entries
                                                if (!tmpFilenames.Contains(files[j]))
                                                {
                                                    duplicateDictionary[tmpFilenames[0]].Add(files[j]);
                                                }
                                                added = true;
                                                break;
                                            }
                                        }

                                        if (!added)
                                        {
                                            StringCollection temp = new StringCollection();
                                            temp.Add(files[i]);
                                            temp.Add(files[j]);

                                            duplicateDictionary.Add(files[i], temp);
                                        }

                                        added = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////

            // Performance data:
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            foreach (StringCollection files in duplicateDictionary.Values)
            {
                TreeNode [] fileNodeChildren = new TreeNode[files.Count - 1]; 
                for (i = 1; i < files.Count; i++)
                {
                    fileNodeChildren[i-1] = new TreeNode(files[i]);
                }

                TreeNode fileNode = new TreeNode(files[0], fileNodeChildren); 
                
                treeviewDuplicates.Nodes.Add(fileNode); 
            }

            statusBottomStrip.Items[0].Text = "Operation finished " + duration.Hours + ":" + duration.Minutes + ":" +
                duration.Seconds + "." + duration.Milliseconds; 

        }


        private static string charToString(char[] input)
        {
            string temp = new string(input);
            return temp;
        }

        private static bool compareCharArrays(char[] input1, char[] input2)
        {
            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != input2[i])
                {
                    // Difference in the arrays
                    return false;
                }
            }

            // Arrays are the same
            return true;
        }

        private static bool bytewiseFileCompare(string file1, string file2)
        {
            StreamReader file1stream = new StreamReader(file1);
            StreamReader file2stream = new StreamReader(file2);

            char[] buffer1 = new char[1024];
            char[] buffer2 = new char[1024];

            while (!file1stream.EndOfStream)
            {
                file1stream.Read(buffer1, 0, 1024);
                file2stream.Read(buffer2, 0, 1024);

                if (!compareCharArrays(buffer1, buffer2))
                {
                    // Difference in the buffers, files are not the same
                    file1stream.Close();
                    file1stream.Dispose();

                    file2stream.Close();
                    file2stream.Dispose();

                    return false;
                }
            }

            file1stream.Close();
            file1stream.Dispose();

            file2stream.Close();
            file2stream.Dispose();

            // The files ARE the same
            return true;
        }

        private static void listFiles(string startDir, ref Dictionary<long, StringCollection> sizeDictionary)
        {
            long fileSize;

            // Add the files in the starting directory too
            foreach (string f in Directory.GetFiles(startDir))
            {
                fileSize = File.OpenRead(f).Length;
                if (sizeDictionary.ContainsKey(fileSize))
                {
                    sizeDictionary[fileSize].Add(f);
                }
                else
                {
                    StringCollection temp = new StringCollection();
                    temp.Add(f);

                    sizeDictionary.Add(fileSize, temp);
                }
            }

            // Then recurse through the list
            recurseFiles(startDir, ref sizeDictionary);

        }

        private static void recurseFiles(string startDir, ref Dictionary<long, StringCollection> sizeDictionary)
        {
            long fileSize;
            try
            {
                foreach (string d in Directory.GetDirectories(startDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        fileSize = File.OpenRead(f).Length;
                        if (sizeDictionary.ContainsKey(fileSize))
                        {
                            sizeDictionary[fileSize].Add(f);
                        }
                        else
                        {
                            StringCollection temp = new StringCollection();
                            temp.Add(f);

                            sizeDictionary.Add(fileSize, temp);
                        }
                    }
                    recurseFiles(d, ref sizeDictionary);
                }
            }
            catch (Exception e)
            {

            }
        }

        // ------------------------------------------------------------------------------------------------------
        // File handling functions

        private void btnOpenSelected_Click(object sender, EventArgs e)
        {
            /*
             * This function does not work as nicely as it should. The cmd box is 
             * visible. This should be fixed later. This might require shell32.dll
             * related operations.
             */


            FileInfo fileToOpen = new FileInfo(treeviewDuplicates.SelectedNode.Text);
            System.Diagnostics.Process.Start("cmd", "/C start /D \"" + fileToOpen.DirectoryName + "\" " + fileToOpen.Name); 

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            // Confirm file delete
            if (MessageBox.Show("Are you sure you want to delete the checked files?", "Delete confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < treeviewDuplicates.Nodes.Count; i++)
                    {
                        if (treeviewDuplicates.Nodes[i].Checked == true)
                            File.Delete(treeviewDuplicates.Nodes[i].Text);

                        for (int j = 0; j < treeviewDuplicates.Nodes[i].Nodes.Count; j++)
                        {
                            if (treeviewDuplicates.Nodes[i].Nodes[j].Checked == true)
                                File.Delete(treeviewDuplicates.Nodes[i].Nodes[j].Text);
                        }
                    }
                    statusBottomStrip.Items[0].Text = "Checeked files were successfully deleted."; 
                }
                catch (Exception expn)
                {
                    statusBottomStrip.Items[0].Text = expn.Message; 
                }
            }
        }

    }
}