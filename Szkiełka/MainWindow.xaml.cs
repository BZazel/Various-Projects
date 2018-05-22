// @@ TO DO: 
//Klasa animacji
//Logika Losowania Zdjecia
//Logika zarządzania listami zdjęć
//Logika feedbacku
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Szkiełka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        LogicClass logic;
        bool isFullScreen = false;
        Canvas canvas;
        public MainWindow()
        {
            InitializeComponent();
            logic = new LogicClass();
            canvas = new Canvas();
            DataContext = logic;
        }

        

        private void MainGrid_Drop(object sender, DragEventArgs e)
        {
            
            if (!logic.PopulateArrays(e)) return;
          
            ButtonWrapper.Children.Clear();

            foreach (var item in logic.AnswersList)
            {
                var bgn = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
                Button btn = new Button();
                btn.Height = 30;
                btn.Background = bgn;
                btn.Margin = new Thickness(2);
                btn.Padding = new Thickness(2);
                btn.FontSize = 13;
                btn.Content = Path.GetFileName(item);
                btn.Click += logic.CheckAnswer;
                
                btn.SetBinding(VisibilityProperty, logic.VisibilityBinding);
                btn.HorizontalAlignment = HorizontalAlignment.Center;
               // btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F3F3FF"));
                ButtonWrapper.Children.Add(btn);

            }
           
            logic.currentImageUri = logic.CurrentList[logic.rand.Next(0,logic.CurrentList.Count -1)];
        }
              
        

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (logic.currentImageUri == null) return;

            switch (logic.myOption)
            {

                case LogicClass.Options.MainList:

                    if (logic.CurrentList.Count == 0) return;
                    //
                    if(logic.answerShow == true)
                    {

                        logic.CorrectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
                        logic.WrongList.RemoveAt(logic.WrongList.IndexOf(logic.currentImageUri));
                        logic.wrongListCount = logic.WrongList.Count.ToString();
                        logic.currentImageUri = logic.CurrentList[logic.rand.Next(0, logic.CurrentList.Count - 1)];

                        logic.answerShow = false;

                       return;
                            
                    }
                  
                    //
                    if (logic.CurrentList.Count == 0) return;

                    logic.CurrentList.RemoveAt(logic.CurrentList.IndexOf(logic.currentImageUri));
                    logic.currentListCount = logic.CurrentList.Count.ToString();
                    logic.currentImageUri = logic.CurrentList[logic.rand.Next(0, logic.CurrentList.Count - 1)];

                    break;

                case LogicClass.Options.WrongList:

                    logic.CorrectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));

                    logic.answerShow = false;

                    if (logic.WrongList.Count == 0) return;

                    logic.WrongList.RemoveAt(logic.WrongList.IndexOf(logic.currentImageUri));
                    logic.wrongListCount = logic.WrongList.Count.ToString();
                    if (logic.WrongList.Count == 0) return;

                    logic.currentImageUri = logic.WrongList[logic.rand.Next(0, logic.WrongList.Count - 1)];

                    break;

                default:
                    break;
            }

           // logic.MainList.RemoveAt(logic.MainList.IndexOf(logic.currentImageUri));

            
        }

      

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //On Empty list...
            if (logic.MainList == null) return;
            switch (logic.myOption)
            {
                case LogicClass.Options.MainList:
                    logic.currentImageUri = logic.CurrentList[logic.rand.Next(0, logic.CurrentList.Count - 1)];
                    break;
                case LogicClass.Options.WrongList:
                    if (logic.WrongList.Count == 0) return;

                    logic.currentImageUri = logic.WrongList[logic.rand.Next(0, logic.WrongList.Count - 1)];

                    break;
                default:
                    break;
            }

        }



        private void Next_Click(object sender, RoutedEventArgs e)
        {
            logic.CorrectButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));

            switch (logic.myOption)
            {
                case LogicClass.Options.MainList:
                    if (logic.CurrentList.Count == 0) return;
                    logic.currentImageUri = logic.CurrentList[logic.rand.Next(0, Convert.ToInt16(logic.currentListCount) - 1)];
                    break;
                case LogicClass.Options.WrongList:
                    if (logic.WrongList.Count == 0) return;
                    logic.currentImageUri = logic.WrongList[logic.rand.Next(0, Convert.ToInt16(logic.wrongListCount) - 1)];
                    break;
                default:
                    break;
            }

            logic.CorrectButton.SetBinding(UIElement.VisibilityProperty, logic.VisibilityBinding);
            logic.nextVisibility = Visibility.Collapsed;
            logic.answerShow = false;
        }

        private void ShowMeCorrect_Click(object sender, RoutedEventArgs e)
        {
            if (logic.answerShow == true) return;
            if (logic.currentImageUri == null) return;

            var imgTemp = Directory.GetParent(logic.currentImageUri.LocalPath).Name;

            var img = Regex.Replace(imgTemp, @"[0-9\-]", string.Empty);

            if (logic.myOption == LogicClass.Options.MainList)
            {
                logic.WrongList.Add(logic.currentImageUri);
                logic.wrongListCount = logic.WrongList.Count.ToString();

                var index = logic.CurrentList.IndexOf(logic.currentImageUri);
                logic.CurrentList.RemoveAt(index);

                logic.currentListCount = logic.CurrentList.Count.ToString();
                if (logic.CurrentList.Count == 0)
                {
                   logic.currentImageUri = null;
                    return;
                }
            }

            var buttons = ButtonWrapper.Children;
            foreach (var item in buttons)
            {
                if ((item as Button).Content.ToString() == img)
                {
                    logic.answerShow = true;
                    logic.CorrectButton = item as Button;
                    logic.CorrectButton.Visibility = Visibility.Visible;
                    logic.nextVisibility = Visibility.Visible;
                    logic.CorrectButton.Background = new SolidColorBrush(Colors.LightGreen);
                    return;
                }
            }
        }

        private void DisplayedImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount < 2) return;  

            if (isFullScreen == false)
            {
                

                var imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(logic.currentImageUri);
                imgBrush.Stretch = Stretch.Uniform;
                canvas.Background = imgBrush;

                canvas.Width= SystemParameters.FullPrimaryScreenWidth;
                canvas.Height = SystemParameters.FullPrimaryScreenHeight;

                canvas.MouseDown += Canvas_MouseDown;
                ImgWrapperGrid.Children[0].Visibility = Visibility.Collapsed;
                ImgWrapperGrid.Children.Add(canvas);
                Panel.SetZIndex(canvas, 1000);

                myWindow.WindowStyle = WindowStyle.None;
                myWindow.WindowState = WindowState.Maximized;
                isFullScreen = true;
            }
           

        }

        private void Canvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount < 2) return;

            ImgWrapperGrid.Children.Remove(canvas);
            myWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            myWindow.WindowState = WindowState.Normal;
            ImgWrapperGrid.Children[0].Visibility = Visibility.Visible;


            isFullScreen = false;
        }
    }

}
