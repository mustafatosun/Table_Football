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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Table_Football
{
    public partial class PageSettings : PhoneApplicationPage
    {
        public PageSettings()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            p1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri( Settings.imgP1 +".png", UriKind.RelativeOrAbsolute));
            p2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.imgP2 + ".png", UriKind.RelativeOrAbsolute));
            ball.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.imgBall + ".png", UriKind.RelativeOrAbsolute));
            f1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.dizilis1.ToString() + ".png", UriKind.RelativeOrAbsolute));
            f2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.dizilis2.ToString() + ".png", UriKind.RelativeOrAbsolute));
            sound.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.sound.ToString() + ".png", UriKind.RelativeOrAbsolute));
            hiz.Value = Settings.speed;

        }

        private void p1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int ord = int.Parse(Settings.imgP1.Substring(6, 1));
            ord++;
            if (ord==7)
            {
                ord = 1;
            }
            Settings.imgP1 = "Player" + ord.ToString();
            p1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Player"+ ord.ToString()+ ".png", UriKind.RelativeOrAbsolute));
            tikekle();
        }

        private void p2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int ord = int.Parse(Settings.imgP2.Substring(6, 1));
            ord++;
            if (ord == 7)
            {
                ord = 1;
            }
            Settings.imgP2 = "Player" + ord.ToString();
            p2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Player" + ord.ToString() + ".png", UriKind.RelativeOrAbsolute));
            tikekle();
        }

        private void f1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Settings.dizilis1==3)
            {
                Settings.dizilis1 = 4;
                f1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.dizilis1.ToString() + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Settings.dizilis1 = 3;
                f1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.dizilis1.ToString() + ".png", UriKind.RelativeOrAbsolute));

            }
            tikekle();
        }

        private void f2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Settings.dizilis2 == 3)
            {
                Settings.dizilis2 = 4;
                f2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.dizilis2.ToString() + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Settings.dizilis2 = 3;
                f2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.dizilis2.ToString() + ".png", UriKind.RelativeOrAbsolute));

            }
            tikekle();
        }

        private void sound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Settings.sound)
            {
                Settings.sound = false;
                sound.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.sound.ToString() + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Settings.sound = true;
                sound.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Settings.sound.ToString() + ".png", UriKind.RelativeOrAbsolute));
            }
            tikekle();
        }

        private void ball_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int ord = int.Parse(Settings.imgBall.Substring(4, 1));
            ord++;
            if (ord == 4)
            {
                ord = 1;
            }
            Settings.imgBall = "Ball" + ord.ToString();
            ball.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Ball" + ord.ToString() + ".png", UriKind.RelativeOrAbsolute));
            tikekle();
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

        private void hiz_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.speed = (int)hiz.Value;
        }
    }
}