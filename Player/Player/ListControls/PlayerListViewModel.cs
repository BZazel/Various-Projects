using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Player
{
    public  class PlayerListViewModel : BaseViewModel
    {


        public int _Index { get; set; } = 0;
        private static List<PlayerListItemViewModel> _ItemsList = new List<PlayerListItemViewModel>();  
        
        

        public static List<PlayerListItemViewModel> ItemsList
        {
            get { return _ItemsList; }
            set { _ItemsList = value;
                RaiseStaticPropertyChanged(nameof(ItemsList)); }
        }



        /// <summary>
        /// On static property changed
        /// </summary>

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        public static void RaiseStaticPropertyChanged(string name)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(name));

        }
        public PlayerListViewModel()
        {

        }

        /// <summary>
        /// Gets needed info about dropped file, for creating new playlist
        /// </summary>
        /// <param name="path"></param>
        /// 
        public static void GetFilesInfo(string[] pathList)
        {
            int Index = 0;
            List<PlayerListItemViewModel> List = new List<PlayerListItemViewModel>();
            
            foreach (var itemPath in pathList)
            {
                ShellFile shellFile = ShellFile.FromFilePath(itemPath);
                shellFile.Thumbnail.FormatOption = ShellThumbnailFormatOption.ThumbnailOnly;

                PlayerListItemViewModel item = new PlayerListItemViewModel();

                //Get total miliseconds length
                var totalTimeMs = shellFile.Properties.System.Media.Duration.Value;
                TimeSpan span = TimeSpan.FromMilliseconds((double)totalTimeMs/10000);

                //Get Minutes and seconds

               item.TotalMinutes = span.Minutes;
               item.TotalSeconds = span.Seconds;
                if (Path.GetExtension(itemPath) != ".mp3")
                {
                    item.ImageSource = shellFile.Thumbnail.BitmapSource;
                }
                item.FullPath = itemPath;
                item.Title = Path.GetFileNameWithoutExtension(itemPath);
                item.Index = Index++;
                
                List.Add(item);
               
            }
            PlayerListViewModel.ItemsList.Clear();
            PlayerListViewModel.ItemsList = List;

            //Title

            //Duration


        }


    }
}
