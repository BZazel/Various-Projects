using System.Windows.Controls;

namespace Player
{
    public class BasePage :Page
    {

        public BasePage()
        {
            Loaded += BasePage_Loaded;
        }


        //On Page loaded...
        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
           
        }
    }

    public class BasePage<VM> : BasePage
        where VM:  BaseViewModel , new()
    {

        private VM mViewModel;

        public VM ViewModel
        {
            get => mViewModel; // {return mViemodel;}
            set {
                if (mViewModel == value) // if DataCtx has been set
                    return;

                mViewModel = value;
                DataContext = mViewModel;
            }
        }

        public BasePage() :base()
        {
            ViewModel = new VM();
        }

    }
}
