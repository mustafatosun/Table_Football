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
    public partial class Difficultly : PhoneApplicationPage
    {
        public Difficultly()
        {
            InitializeComponent();
            
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            GamePage.botSpeed = 1;
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
        }

        private void Image_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            GamePage.botSpeed = 3;
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
        }

        private void Image_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            GamePage.botSpeed = 5;
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
    }
}