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

namespace NoteBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ChildForm = new Form();
            ChildForm.MdiParent = this;
            RichTextBox rtf = new RichTextBox();
            rtf.Size = ChildForm.Size;
            ChildForm.Controls.Add(rtf);
            ChildForm.Show();   
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form ChildForm = new Form();
                ChildForm.MdiParent = this;
                RichTextBox rtf = new RichTextBox();
                rtf.Size = ChildForm.Size;
                rtf.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.UnicodePlainText);
                ChildForm.Controls.Add(rtf);
                ChildForm.Show();   
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                if (activeChild != null)
                {
                    RichTextBox rtf = (RichTextBox)activeChild.ActiveControl;
                    if (rtf != null)
                    {
                        //Clipboard.SetDataObject(rtf.SelectedText);  
                        rtf.SelectionColor = colorDialog1.Color;
                    }
                }
     
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                 Form activeChild = this.ActiveMdiChild;
                 if (activeChild != null)
                 {
                     RichTextBox rtf = (RichTextBox)activeChild.ActiveControl;
                     if (rtf != null)
                     {
                         rtf.SelectionFont = fontDialog1.Font;
                     }
                 }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                if (activeChild != null)
                {
                    RichTextBox rtf = (RichTextBox)activeChild.ActiveControl;
                    if (rtf != null)
                    {
                        Clipboard.SetDataObject(rtf.SelectedText);                          
                    }
                }

            }
        }

        private void openFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] files= new string[0];
             if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)            
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.txt", SearchOption.TopDirectoryOnly);
           foreach (var f in files)
           {
               Form ChildForm = new Form();
               ChildForm.MdiParent = this;
               RichTextBox rtf = new RichTextBox();
               rtf.Size = ChildForm.Size;
               rtf.LoadFile(f, RichTextBoxStreamType.UnicodePlainText);
               ChildForm.Controls.Add(rtf);
               ChildForm.Show();   
           }
        }
    }
}
