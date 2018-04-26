using System;

using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Player
{

    /// <summary>
    /// Contains all animations 
    /// </summary>
    public static class Animations
    {
        public static FrameworkElement ElementHost;

        /// <summary>
        /// Timer for main UI elements animate out event
        /// </summary>
        public static DispatcherTimer animTimer = new DispatcherTimer();

        #region Complex Animations for  Framework elements 

        public static void Anim_FromTop(FrameworkElement element)
        {
            var sb = new Storyboard();

            sb.Add_TopSlider();
            sb.Add_Opaciter();
            sb.Begin(element);
        }
        public static void Anim_ToTop(FrameworkElement element)
        {
            var sb = new Storyboard();

            sb.Add_ToTopSlider();
            sb.Add_RevesedOpaciter();
            sb.Begin(element);
        }
        public static void Anim_ToBottom(FrameworkElement element)
        {
            var sb = new Storyboard();

            sb.Add_ToBottomSlider();
            sb.Add_RevesedOpaciter();
            sb.Begin(element);
        }
        // SIDEPANEL Show
        public static void Anim_FromRight(FrameworkElement element)
        {
            var sb = new Storyboard();

            sb.Add_LeftSlider();
            sb.Begin(element);
            ApplicationWindowViewModel.areToolsLoaded = true;

        }
        // SIDEPANEL Hide
        public static void Anim_ToRight(FrameworkElement element)
        {
            var sb = new Storyboard();

            sb.Add_RightSlider();
            //sb.Add_RevesedOpaciter();
            sb.Begin(element);
            ApplicationWindowViewModel.areToolsLoaded = false;

        }
        public static void Anim_FromBottom(FrameworkElement element)
        {
            var sb = new Storyboard();
            sb.Add_BottomSlider();
            sb.Add_Opaciter();
            sb.Begin(element);
        } 
        #endregion

        #region Simple Animations to Add

        public static void Add_BottomSlider(this Storyboard storyboard)
        {
            var newAnimation = new ThicknessAnimation
            {
                From = new Thickness(0, 80, 0, -80), 
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),
            };
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(newAnimation);
        }
        public static void Add_ToBottomSlider(this Storyboard storyboard)
        {
            var newAnimation = new ThicknessAnimation
            {
                From = new Thickness(0),
           
                To = new Thickness(0, 80, 0, -80),
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),


            };
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(newAnimation);
        }

        public static void Add_TopSlider(this Storyboard storyboard)
        {
            var newAnimation = new ThicknessAnimation
            {
                From = new Thickness(0, -60, 0, 60),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),


            };
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(newAnimation);
        }

        public static void Add_RightSlider(this Storyboard storyboard)
        {
            var newAnimation = new ThicknessAnimation
            {
                From = new Thickness(300, 60, -300, 80),
                
                To = new Thickness(0,60,0,80),
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),


            };
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(newAnimation);
        }
        public static void Add_LeftSlider(this Storyboard storyboard)
        {
            var newAnimation = new ThicknessAnimation
            {
                From = new Thickness(0,60,0,80),
                To = new Thickness(300, 60, -300, 80),
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),


            };
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(newAnimation);
        }

        public static void Add_Opaciter(this Storyboard storyboard)
        {
            var opacityAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,

                Duration = new Duration(TimeSpan.FromMilliseconds(500)),

            };
            Storyboard.SetTargetProperty(opacityAnim, new PropertyPath("Opacity"));
            storyboard.Children.Add(opacityAnim);
        }
        public static void Add_RevesedOpaciter(this Storyboard storyboard)
        {
            var opacityAnim = new DoubleAnimation
            {
                From = 1,
                To = 0,

                Duration = new Duration(TimeSpan.FromMilliseconds(500)),

            };
            Storyboard.SetTargetProperty(opacityAnim, new PropertyPath("Opacity"));
            storyboard.Children.Add(opacityAnim);
        }

        public static void Add_ToTopSlider(this Storyboard storyboard)
        {
            var thickAnim = new ThicknessAnimation
            {
                From = new Thickness(0),
                To = new Thickness(0, -60, 0, 60),
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),
            };
        }

        #endregion

        /// <summary>
        /// Animate In TitleBar Top - to - bottom
        /// </summary>
        /// <param name="TitleBar"></param>
        public static void WholePageAnim(FrameworkElement TitleBar)
        {
            Anim_FromTop(TitleBar);
            ApplicationWindowViewModel.areToolsLoaded = true;
          
        }


        public static void ReversedTitleBar()
        {
           
           animTimer.Interval = TimeSpan.FromSeconds(3);
           animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();

        }
        public static void ReversedMediaTools(FrameworkElement element)
        {
            ElementHost = element;
            animTimer.Interval = TimeSpan.FromSeconds(3);
            animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();

        }


        private static void AnimTimer_Tick(object sender, EventArgs e)
        {
            ApplicationWindowViewModel.areToolsLoaded = false;
            Anim_ToTop(MainWindow.Instance.TitleBar);
            Anim_ToBottom(ElementHost);
            VideoPlayerViewModel.ToolsLoaded = false;
            animTimer.Stop();
        }

       
        
    }




}
