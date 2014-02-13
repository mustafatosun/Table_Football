using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace Table_Football
{
    public partial class Flag : PhoneApplicationPage
    {
        public static int game;
        int step;
        string team1, team2;
        public Flag()
        {
            InitializeComponent();
            
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            if (step==0)
            {
                if (team1!=null)
                {
                    txtblck.Text = ">";
                    step++;
                }
                else
                {
                    MessageBox.Show("Please, first your team!");
                }
                
            }
            else
            {
                if (team2!=null)
                {
                    if (game == 1)
                    {
                        GamePage.teamName1 = team1;
                        GamePage.teamName2 = team2;
                        NavigationService.Navigate(new Uri("/Difficultly.xaml", UriKind.Relative));
                    }
                    else
                    {
                        GamePage2.teamName1 = team1;
                        GamePage2.teamName2 = team2;
                        NavigationService.Navigate(new Uri("/GamePage2.xaml", UriKind.Relative));
                    }
                }
                else
                {
                    MessageBox.Show("Please, choose second team!");
                }
            }
            
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {

            step = 0;
            txtblck.Text = "<";
        }

        private void Image_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            if (step==0)
            {
                team1 = "Argentina";
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Argentina.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = "Argentina";
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Argentina.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            if (step == 0)
            {
                team1 = "Brasil";
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Brasil.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = "Brasil";
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Brasil.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "British";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name+".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "China";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_6(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "France";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_7(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "Germany";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_8(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "Italy";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_9(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "Japan";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_10(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "Russia";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_11(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "Spain";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_12(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "Turkey";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Image_Tap_13(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tikekle();
            string name = "USA";
            if (step == 0)
            {
                team1 = name;
                img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                team2 = name;
                img2.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(name + ".png", UriKind.RelativeOrAbsolute));
            }
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