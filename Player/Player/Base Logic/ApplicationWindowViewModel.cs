using System;
using System.Windows;
using System.Windows.Input;

namespace Player
{
    public class ApplicationWindowViewModel : BaseViewModel

    {
        public static ApplicationWindowViewModel basePageInstance;
      
        public static bool areToolsLoaded;

        #region  Properties

        public Uri path { get; set; }


        public ApplicationPages CurrentPage { get; set; }

        #endregion


        #region Private properties
        private Window mWindow { get; set; }

        #endregion



        #region Commands
        public ICommand ExitCommand { get; set; }
        public ICommand ShowSideBarCommand { get; set; }
        #endregion
        #region Constructors



        public ApplicationWindowViewModel(Window window)
        {
            mWindow = window;


            basePageInstance = this;
           // ShowSideBarCommand = new RelayCommand(() => ShowSideBar());
            ExitCommand = new RelayCommand(() => mWindow.Close());


        }

        // TO ADD
        //private void ShowSideBar()

        //{ // Animate IN or out side bar
        //    if (areToolsLoaded == false)
        //        Animations.Anim_FromRight(MainWindow.Instance.SidePanel);
        //    else
        //        Animations.Anim_ToRight(MainWindow.Instance.SidePanel);
        //}

        #endregion

        /// <summary>
        /// Function for switching pages: Player | Main | 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void GoToPage(string PageName)
        {

            switch (PageName)
            {
                case "Player":
                    basePageInstance.CurrentPage = ApplicationPages.VideoPlayer;
                    break;

                case "Main":
                    basePageInstance.CurrentPage = ApplicationPages.first;
                    break;

                default:
                    break;
            }

        }


        




    }
}
