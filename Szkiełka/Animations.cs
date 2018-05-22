using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Szkiełka
{
    public static class Animations
    {
        public static ColorAnimationUsingKeyFrames correctAnim = new ColorAnimationUsingKeyFrames();
        public static ColorAnimationUsingKeyFrames wrongAnim = new ColorAnimationUsingKeyFrames();
        static Duration animDuration = new Duration(TimeSpan.FromMilliseconds(1000));

        public static void AnimationsSetup()
        {

            correctAnim.Duration = new Duration(TimeSpan.FromMilliseconds(1500));
            correctAnim.KeyFrames.Add(
                new LinearColorKeyFrame(
                    Colors.Green,
                    KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))
                    ));
            correctAnim.KeyFrames.Add(
                new LinearColorKeyFrame(
                    Colors.White,
                    KeyTime.FromPercent(1)
                    ));

            wrongAnim.Duration = animDuration;
            wrongAnim.KeyFrames.Add(
                new LinearColorKeyFrame(
                    Colors.Red,
                    KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))
                    ));
            wrongAnim.KeyFrames.Add(
                new LinearColorKeyFrame(
                    (Color)ColorConverter.ConvertFromString("#F3F3FF"),
            KeyTime.FromPercent(1)
                    ));
            
        }

        public static void CorrectAnim(FrameworkElement element)
        {

            var bgnd = new SolidColorBrush(Colors.Transparent);
            ((element as Button).Parent as WrapPanel).Background = bgnd;
            ((element as Button).Parent as WrapPanel).Background.BeginAnimation(SolidColorBrush.ColorProperty, correctAnim);

        }
        public static void WrongAnim(FrameworkElement element)
        {

            var bgnd = new SolidColorBrush(Colors.Transparent);
            ((element as Button).Parent as WrapPanel).Background = bgnd;
            ((element as Button).Parent as WrapPanel).Background.BeginAnimation(SolidColorBrush.ColorProperty, wrongAnim);

        }
        public static void CorrectButtonAnim(FrameworkElement element)
        {
           
           (element as Button).Background.BeginAnimation(SolidColorBrush.ColorProperty, correctAnim);

        }
        public static void WrongButtonAnim(FrameworkElement element)
        {
            
            (element as Button).Background.BeginAnimation(SolidColorBrush.ColorProperty, wrongAnim);
        }

      

    }
}
