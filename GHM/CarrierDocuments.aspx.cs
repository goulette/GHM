using System;
using System.Diagnostics;
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
    public partial class CarrierDocuments : System.Web.UI.Page
    {
        int CarrierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CarrierName = Session["CarrierName"].ToString();
            int.TryParse(Request.QueryString["id"], out CarrierID);
            if (Page.IsPostBack == false)
            {
                string strpath = Server.MapPath("~/Documents/" + CarrierName + "/");
                System.IO.DirectoryInfo RootDir = new System.IO.DirectoryInfo(strpath);
                TreeNode RootNode = OutputDirectory(RootDir, null);
                DocumentTreeView.Nodes.Add(RootNode);
            }
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

        protected void DocumentTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            string dir = "http://intranet.ghmagency.com/Documents/" + Session["CarrierName"] + "/";
            string path = dir + DocumentTreeView.SelectedNode.Text;
            CarrierDocumentsLabel.Text = path;
            Process P = new Process();
            P.StartInfo.FileName = path;
            P.StartInfo.Verb = "";
            P.Start();
            //System.Diagnostics.Process.Start();
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            string TransferString;
            TransferString = "~/CarrierInfo.aspx?id=" + CarrierID;
            Response.Redirect(TransferString);
        }
    }
}