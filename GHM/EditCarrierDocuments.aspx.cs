using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GHM
{
    public partial class EditCarrierDocuments : System.Web.UI.Page
    {
        int CarrierID;
        public void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string strpath = Server.MapPath("~/Documents/" + Session["CarrierName"] + "/");
                System.IO.DirectoryInfo RootDir = new System.IO.DirectoryInfo(strpath);
                TreeNode RootNode = OutputDirectory(RootDir, null);
                DocumentTreeView.Nodes.Add(RootNode);
            }
       }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            int.TryParse(Request.QueryString["id"], out CarrierID);

            TransferString = "~/EditCarrier.aspx?id=" + CarrierID;

            Server.Transfer(TransferString);
        }

        TreeNode OutputDirectory(System.IO.DirectoryInfo directory, TreeNode parentNode)
        {
            if (directory == null) return null;
            // create a node for this directory 
            TreeNode DirNode = new TreeNode(directory.Name);
            // get subdirectories of the current directory 
            System.IO.DirectoryInfo[] SubDirectories = directory.GetDirectories();
            // OutputDirectory(SubDirectories[0], "Directories"); 
            // output each subdirectory 
            for (int DirectoryCount = 0; DirectoryCount < SubDirectories.Length; DirectoryCount++)
            {
                OutputDirectory(SubDirectories[DirectoryCount], DirNode);
            }
            // output the current directories file 
            System.IO.FileInfo[] Files = directory.GetFiles();
            for (int FileCount = 0; FileCount < Files.Length; FileCount++)
            {
                DirNode.ChildNodes.Add(new TreeNode(Files[FileCount].Name));
            }        // if the parent node is null, return this node 
                     // otherwise add this node to the parent and return the parent 
            if (parentNode == null)
            {
                return DirNode;
            }
            else
            {
                parentNode.ChildNodes.Add(DirNode);
                return parentNode;
            }
        }
    }
}