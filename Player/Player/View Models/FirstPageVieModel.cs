using Microsoft.Win32;
using System;
using System.Windows.Input;

namespace Player
{
    public class FirstPageVieModel :BaseViewModel
    {
        public ICommand OpenCommand { get; set; }
        public Uri path;


        public FirstPageVieModel()
        {
            OpenCommand = new RelayCommand(() => OpenFile());
        }


        private void OpenFile()
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.ShowDialog();

            if (opnDlg.FileName == String.Empty)
                return;
            ApplicationWindowViewModel.GoToPage("Player");


            path = new Uri(opnDlg.FileName);


            try
            {
                VideoDisplay.myElement.Source = path;

                VideoDisplay.myElement.Play();
            }
            catch { }

        }
    }
}
