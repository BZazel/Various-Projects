using System.Windows;
using System.Windows.Input;

namespace Player
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public static MainWindow Instance;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;

            this.DataContext = new ApplicationWindowViewModel(this);
          
           
            StateChanged += MainWindow_StateChanged;
            
        }

  
        
        private void MainWindow_StateChanged(object sender, System.EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {

                WindowState = System.Windows.WindowState.Maximized;
                Width = SystemParameters.VirtualScreenWidth;
                Height = SystemParameters.VirtualScreenHeight;
                //Topmost = true;
                Hide();
                Show();
            }
            else
            Topmost = false;
            Width = 1024;
            Height = 576;

        }

        

        #region Key events
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Escape) && WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }

            //Space Pause TO ADD
            //if (Keyboard.IsKeyDown(Key.Space))
            //{
            //    if (BasePageModel.IsPlaying == true)
            //    {
            //        BasePageModel.Player.Pause();
            //        BasePageModel.IsPlaying = false;
            //    }
            //    else
            //    {
            //        BasePageModel.Player.Play();
            //        BasePageModel.IsPlaying = true;
            //    }
            //}
        }

        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount >=2)
            {   
                if((sender as Window).WindowState != WindowState.Maximized)
                {
                    (sender as Window).WindowState = WindowState.Maximized;
                    //Width = SystemParameters.VirtualScreenWidth;
                    //Height = SystemParameters.VirtualScreenHeight;

                }
                else
                {
                    (sender as Window).WindowState = WindowState.Normal;
                }
            }

            if(ApplicationWindowViewModel.areToolsLoaded == false)
             Animations.WholePageAnim(TitleBar);

            Animations.animTimer.Stop();
            Animations.animTimer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Animations.WholePageAnim(TitleBar);
        }

    }
}
