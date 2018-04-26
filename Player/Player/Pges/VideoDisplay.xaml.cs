
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System;

namespace Player
{
    /// <summary>
    /// Logika interakcji dla klasy VideoDisplay.xaml
    /// </summary>
    public partial class VideoDisplay : BasePage<VideoPlayerViewModel>
    {
       DispatcherTimer timer = new DispatcherTimer();
       public static MediaElement myElement;
        public int CurrVidIndex = 0;
       
        
        public VideoDisplay()
        {
          
            InitializeComponent();
            myElement = myMediaPlayer;
       
            myElement.MediaOpened += MyMediaPlayer_MediaOpened;
            

            
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;

            ProgressSlider.MouseUp += ProgressSlider_MouseUp;
            ProgressSlider.GotMouseCapture += ProgressSlider_GotMouseCapture;
            ProgressSlider.LostMouseCapture += ProgressSlider_LostMouseCapture;


        }

       



        // Timer-based updating progress slider
        private void Timer_Tick(object sender, EventArgs e)
        {
            ProgressSlider.Value = myElement.Position.TotalMilliseconds;
            //Time Management - Current Time
            tbCurrentSeconds.Text = myElement.Position.Seconds>=10 ?Math.Floor((decimal)myElement.Position.Seconds).ToString(): "0"+ Math.Floor((decimal)myElement.Position.Seconds).ToString(); 
            tbCurrentMinutes.Text = Math.Floor((decimal)myElement.Position.Minutes).ToString();
            

        }

        #region VolumeSlider Events
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myElement.Volume = VolumeSlider.Value/100;
        }
        #endregion

        #region Progress Slider Events

        

        private void ProgressSlider_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            myElement.Position = TimeSpan.FromMilliseconds(ProgressSlider.Value);
            timer.Start();
            Animations.animTimer.Start();
        }

        private void ProgressSlider_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            timer.Stop();
            Animations.animTimer.Stop();
        }

        private void ProgressSlider_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myElement.Stop();
            myElement.Position = TimeSpan.FromMilliseconds(ProgressSlider.Value);
            timer.Start();
            myElement.Play();
        }
        #endregion

        // When Media opens..
        private void MyMediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {    //Time Management - WholeTime
            VolumeSlider.Value = 60;
            tbTotalMinutes.Text = Math.Floor((decimal)myElement.NaturalDuration.TimeSpan.Minutes).ToString();
            tbTotalSeconds.Text = myElement.NaturalDuration.TimeSpan.Seconds >=10? Math.Floor((decimal)myElement.NaturalDuration.TimeSpan.Seconds).ToString() :"0"+ Math.Floor((decimal)myElement.NaturalDuration.TimeSpan.Seconds).ToString() ;
           
            ProgressSlider.Maximum = myElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            Animations.ReversedMediaTools(MainTools);
            timer.Start();
            
        }
        

        // Drag and drop file execution
        private void Grid_Drop(object sender, System.Windows.DragEventArgs e)
        {  

            string[] FileList = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop, false);
            myElement.Source = new System.Uri(FileList[0]);
            PlayerListViewModel.GetFilesInfo(FileList);
            myElement.Play();
            

           
        }

        private void BasePage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (VideoPlayerViewModel.ToolsLoaded == false)
            {
                Animations.Anim_FromBottom(MainTools);
                Animations.Anim_FromTop(MainWindow.Instance.TitleBar);
                VideoPlayerViewModel.ToolsLoaded = true;
            }
            
            
            Animations.animTimer.Stop();
           Animations.animTimer.Start();
        }

        
    }
}
