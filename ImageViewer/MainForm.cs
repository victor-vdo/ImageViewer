using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            this.openDialog.Multiselect = false;
            openDialog.Title = "Select the Image File";
            openDialog.InitialDirectory = @"C:\Users\";
            openDialog.Filter = "All files (*.*)|*.*|"+"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            openDialog.CheckFileExists = true;
            openDialog.CheckPathExists = true;
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
            openDialog.ReadOnlyChecked = true;
            openDialog.ShowReadOnly = true;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openDialog.FileNames)
                {
                    try
                    {
                        Image image = Image.FromFile(file);
                        this.pcbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.pcbImage.Image = image;  
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show("A security error was detected. Please, contact the software support.\n\n" +
                                                    "Error mensage : " + ex.Message + "\n\n" +
                                                    "Details (send to support):\n\n" + ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The image could not be showed : " + file.Substring(file.LastIndexOf('\\'))
                                                   + ". You don't have permission to read the file or " +
                                                   "the file is corrupted.\n\nError message : " + ex.Message);
                    }
                }
                
            }
        }
    }
}
