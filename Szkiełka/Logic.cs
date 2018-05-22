using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Szkiełka
{
    public class LogicClass : INotifyPropertyChanged
    {
        public List<Uri> MainList;
        public List<Uri> CurrentList;
        public List<Uri> WrongList;
        public List<string> AnswersList;
        public Button CorrectButton;
        public Random rand;
        public Binding VisibilityBinding;

        #region Properties
        private Visibility _nextVisibility = Visibility.Collapsed;

        public Visibility nextVisibility

        {
            get { return _nextVisibility; }
            set
            {
                _nextVisibility = value;
                OnPropertyChanged(nameof(nextVisibility));
            }
        }


        private bool _answerShow = false;

        public bool answerShow
        {
            get { return _answerShow; }
            set
            {
                _answerShow = value;
                OnPropertyChanged(nameof(answerShow));
            }
        }



        private bool _showCorrectAnswer;

        public bool showCorrectAnswer
        {
            get { return _showCorrectAnswer; }
            set
            {
                _showCorrectAnswer = value;
                OnPropertyChanged(nameof(showCorrectAnswer));
            }
        }


        private string _currentListCount;

        public string currentListCount
        {
            get { return _currentListCount; }
            set
            {

                _currentListCount = value;
                OnPropertyChanged(nameof(currentListCount));
            }
        }
        private string _wrongListCount;
        public string wrongListCount
        {
            get { return _wrongListCount; }
            set
            {
                _wrongListCount = value;
                OnPropertyChanged(nameof(wrongListCount));
            }
        }

        private Options _myOption = Options.MainList;

        public Options myOption
        {
            get { return _myOption; }
            set
            {
                if (value == Options.WrongList && WrongList == null)
                    _myOption = Options.MainList;

                OnPropertyChanged(nameof(myOption));
                _myOption = value;
            }
        }

        public enum Options
        {
            MainList,
            WrongList
        }

        private Uri _currentImageUri;
        public Uri currentImageUri
        {
            get { return _currentImageUri; }
            set
            {
                _currentImageUri = value;
                OnPropertyChanged(nameof(currentImageUri));
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public LogicClass()
        {
            rand = new Random();

            //Binding Options
            VisibilityBinding = new Binding("answerShow");
            VisibilityBinding.Converter = new BooleanToVisibilityConverter();

            Animations.AnimationsSetup();
        }


        public bool PopulateArrays(DragEventArgs e)
        {

            //Clear Everything ==========
            currentListCount = String.Empty;
            wrongListCount = String.Empty;

            MainList = new List<Uri>();
            CurrentList = new List<Uri>();
            WrongList = new List<Uri>();
            AnswersList = new List<string>();
            // ===========================
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string[] folders = Directory.GetDirectories(files[0]);

            if (folders.Length == 0) return false;

            foreach (var answer in folders)
            {
                var result = Regex.Replace(answer, @"[0-9\-]", string.Empty);

                AnswersList.Add(Path.GetFileName(result));

                var images = Directory.GetFiles(answer);

                foreach (var item in images)
                {
                    MainList.Add(new Uri(item));

                }
            }
            AnswersList.Sort();
            
           CurrentList = MainList;
            currentListCount = CurrentList.Count.ToString();
            var items = 1;


            return true;
        }

        public void CheckAnswer(object sender, RoutedEventArgs e)
        {
            if (answerShow == true) return;

            if (currentImageUri == null) return;

            var imgTemp = Directory.GetParent(currentImageUri.LocalPath).Name;

            var img = Regex.Replace(imgTemp, @"[0-9\-]", string.Empty);

            //On Correct Answer ...
            if ((sender as Button).Content.ToString() == img)
            {
                Animations.CorrectAnim(sender as FrameworkElement);
                nextVisibility = Visibility.Visible;
                switch (myOption)
                {
                    case Options.MainList:
                                            
                    CurrentList.RemoveAt(CurrentList.IndexOf(currentImageUri));
                    currentListCount = CurrentList.Count.ToString();
                        if (CurrentList.Count == 0)
                        {
                            this.currentImageUri = null;
                            return;
                        }
                    //currentImageUri = CurrentList[rand.Next(0, Convert.ToInt16(currentListCount)-1)];

                        break;
                        //
                    case Options.WrongList:

                        int index1 = WrongList.IndexOf(currentImageUri);
                        WrongList.RemoveAt(index1);
                        wrongListCount = WrongList.Count.ToString();
                        if (WrongList.Count == 0)
                        {
                            this.currentImageUri = null;
                            return;
                        }

                       // currentImageUri =  WrongList[rand.Next(0, Convert.ToInt16(wrongListCount) - 1)];
                        break;
                        //
                    default:
                        break;
                }
                
              
            }
            else
            {
                //
                Animations.WrongAnim(sender as FrameworkElement);

                if (showCorrectAnswer == true)
                {
                    if(myOption == Options.MainList)
                    {
                        WrongList.Add(currentImageUri);
                        wrongListCount = WrongList.Count.ToString();

                        var index = CurrentList.IndexOf(currentImageUri);
                        CurrentList.RemoveAt(index);

                        currentListCount = CurrentList.Count.ToString();
                        if (CurrentList.Count == 0)
                        {
                            this.currentImageUri = null;
                            return;
                        }
                    }

                    var buttons = ((sender as Button).Parent as WrapPanel).Children;
                    foreach (var item in buttons)
                    {
                        if ((item as Button).Content.ToString() == img)
                        {
                            answerShow = true;
                            CorrectButton = item as Button;
                            CorrectButton.Visibility = Visibility.Visible;
                            nextVisibility = Visibility.Visible;
                            CorrectButton.Background = new SolidColorBrush(Colors.LightGreen);
                            return;
                        }
                    }
                }
                else
                {
                    switch (myOption)
                    {
                        case Options.MainList:
                            WrongList.Add(currentImageUri);
                            wrongListCount = WrongList.Count.ToString();

                            var index = CurrentList.IndexOf(currentImageUri);
                            CurrentList.RemoveAt(index);
                            currentListCount = CurrentList.Count.ToString();
                            if (CurrentList.Count == 0)
                            {
                                this.currentImageUri = null;
                                return;
                            }
                            currentImageUri = CurrentList[rand.Next(0, Convert.ToInt16(currentListCount) - 1)];
                            break;
                        //
                        case Options.WrongList:

                            if (WrongList.Count == 0) return;
                            currentImageUri = WrongList[rand.Next(0, Convert.ToInt16(wrongListCount) - 1)];

                            break;

                        default:
                            break;
                    }

                }

               

              
            }
        }
    }
}
