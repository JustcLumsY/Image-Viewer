using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Viewer
{
    public partial class ImageViewer : Form
    {
        List<string> fileNames = new List<string>();
        public ImageViewer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
                       {Multiselect = true, ValidateNames = true, Filter = "JPEG|*.jpg"})
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileNames.Clear();
                    listView1.Items.Clear();
                    foreach (string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        fileNames.Add(fi.FullName);
                        listView1.Items.Add(fi.Name, 0);
                    }
                }
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                using (frmViewer frm = new frmViewer())
                {
                    Image img = Image.FromFile(fileNames[listView1.FocusedItem.Index]);
                    frm.ImageBox = img;
                    frm.ShowDialog();
                }
            }
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
