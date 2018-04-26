using System;
using System.Windows.Controls;

namespace Player
{
    /// <summary>
    /// Logika interakcji dla klasy PlayerListItemControl.xaml
    /// </summary>
    public partial class PlayerListItemControl : UserControl
    {
        public PlayerListItemControl()
        {
            InitializeComponent();
             
        }


        private void ContentControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var i = ((PlayerListItemViewModel)DataContext).Index;
           //Get path from the viewModel's property
           VideoDisplay.myElement.Source = new Uri(((PlayerListItemViewModel)DataContext).FullPath);
           VideoDisplay.myElement.Play();
        }
    }
}
