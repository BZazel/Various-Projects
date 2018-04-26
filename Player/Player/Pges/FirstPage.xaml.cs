using Microsoft.WindowsAPICodePack.Shell;
using System.Windows;
using System.Windows.Controls;

namespace Player
{
    /// <summary>
    /// Logika interakcji dla klasy FirstPage.xaml
    /// </summary>
    public partial class FirstPage : BasePage<FirstPageVieModel>
    {
        public FirstPage()
        {
            InitializeComponent();
           

        }

        private void Grid_Drop(object sender, System.Windows.DragEventArgs e)
        {
            
            ApplicationWindowViewModel.GoToPage("Player");
            string[] FileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            VideoDisplay.myElement.Source = new System.Uri(FileName[0]);
            
            PlayerListViewModel.GetFilesInfo(FileName);
            VideoDisplay.myElement.Play();
        }
    }
}
