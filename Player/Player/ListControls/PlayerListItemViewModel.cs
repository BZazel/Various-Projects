using System.Windows.Media.Imaging;

namespace Player
{/// <summary>
/// Item properties for each item in list
/// </summary>
    public class PlayerListItemViewModel : BaseViewModel

    {

        public int Index { get; set; }
        /// <summary>
        /// Full path of a file
        /// </summary>
        public string FullPath { get; set; }
        
        /// <summary>
        /// File Name
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Whole time in minutes
        /// </summary>
        public double TotalMinutes { get; set; }

        /// <summary>
        /// Total time in seconds
        /// </summary>
        public double TotalSeconds { get; set; }

        /// <summary>
        /// Temp; Color for video box
        /// </summary>
        public BitmapSource ImageSource { get; set; }



    }
}
