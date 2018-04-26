using System.Windows;
using System.Windows.Controls;

namespace Player
{
    /// <summary>
    /// Logika interakcji dla klasy PlayerListControl.xaml
    /// </summary>
    public partial class PlayerListControl : UserControl
    {
        public PlayerListControl()
        {
            InitializeComponent();
           
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            //BasePageModel.GoToPage("Player");
            //string[] FileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //BasePageModel.Player.Source = new System.Uri(FileName[0]);
            ////ShellFile shellfile = ShellFile.FromFilePath(FileName[0]);
            ////var iks = shellfile.Properties.System.Video.Compression.Value;
            ////MessageBox.Show(iks.ToString());
            //GetFilesInfo(FileName);
            //BasePageModel.Player.Play();

        }
    }
}
