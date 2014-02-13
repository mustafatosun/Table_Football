using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace Table_Football
{
    public partial class WinLose : PhoneApplicationPage
    {
        public WinLose()
        {
            InitializeComponent();
            
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            son();
            if (Settings.result==2)
            {
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Lose.png",UriKind.RelativeOrAbsolute));
            }
            else
            {
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Win.png",UriKind.RelativeOrAbsolute));
            }
            
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
        }
        public void tikekle()
        {

            Stream stream = TitleContainer.OpenStream("ekle.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            if (Settings.sound)
            {
                effect.Play();
            }

        }
        public void son()
        {

            Stream stream = TitleContainer.OpenStream("son.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            if (Settings.sound)
            {
                effect.Play();
            }

        }
    }
}