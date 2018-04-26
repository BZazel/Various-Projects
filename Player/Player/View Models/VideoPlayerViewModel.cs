using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Player
{
    public class VideoPlayerViewModel : BaseViewModel
    {
       public static bool ToolsLoaded;
       
       public Uri path;

       public ICommand StopCommand { get; set; }
       public ICommand PauseCommand { get; set; }
       public ICommand PlayCommand { get; set; }
       public ICommand OpenCommand { get; set; }

        public VideoPlayerViewModel()
        {

            PlayCommand = new RelayCommand(() => PlayVieo());
            PauseCommand = new RelayCommand(() => PauseVideo());
            OpenCommand = new RelayCommand(() => OpenFile());

        }
      



        


        #region Command Functions

        private void OpenFile()
        {

            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.ShowDialog();
            ApplicationWindowViewModel.GoToPage("Player");

            if (opnDlg.FileName == String.Empty)
                return;

            path = new Uri(opnDlg.FileName);

           
            try
            {
                VideoDisplay.myElement.Source = path;

                VideoDisplay.myElement.Play();
            }
            catch { }

        }


        private void PauseVideo()
        {
            VideoDisplay.myElement.Pause();
            Animations.animTimer.Stop();


        }

        private void StopVideo()
        {
            VideoDisplay.myElement.Stop();
            Animations.animTimer.Stop();
        }

        private void PlayVieo()
        {
            VideoDisplay.myElement.Play();
            Animations.animTimer.Start();

        }
        #endregion
    }
}
