using System;
using System.IO;
using System.Windows.Forms;

namespace VitalLabSoft
{
    class FileExplorer
    {
        public FileExplorer()
        {
        }
        public string sRaiz = "";
        public bool CreateTree(TreeView treeView, string sRoot, string sRoot2)
        {
            bool returnValue = true;
            try
            {
                sRaiz = sRoot2;
                treeView.Nodes.Clear();
                // Create Desktop
                TreeNode desktop = new TreeNode();
                desktop.Text = sRoot;
                desktop.Tag = sRoot2;
                desktop.Nodes.Add("");
                treeView.Nodes.Add(desktop);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

        public bool AgregaNode(TreeView treeView, string sRoot, string sRoot2)
        {
            bool returnValue = true;
            try
            {
                TreeNode desktop = new TreeNode();
                desktop.Text = sRoot;
                desktop.Tag = sRoot2;
                desktop.Nodes.Add("");
                treeView.Nodes.Add(desktop);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }
        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {
            try
            {
                DirectoryInfo rootDir;

                Char[] arr = { '\\' };
                string[] nameList = parentNode.FullPath.Split(arr);
                string path = "";

                if (nameList.GetValue(0).ToString().Contains("Carpeta_OP"))
                {
                    path = sRaiz;

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + "\\" + nameList[i] + "\\";
                    }

                    rootDir = new DirectoryInfo(path);
                }
                else
                {
                    rootDir = new DirectoryInfo(parentNode.Tag + "\\");
                }

                parentNode.Nodes[0].Remove();
                foreach (DirectoryInfo dir in rootDir.GetDirectories())
                {

                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    node.Tag = dir.FullName;
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }
                foreach (FileInfo file in rootDir.GetFiles())
                {
                    TreeNode node = new TreeNode();
                    node.Text = file.Name;
                    node.Tag = file.FullName;
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    parentNode.Nodes.Add(node);
                }
            }
            catch
            {
            }
            return parentNode;
        }
    }
}
