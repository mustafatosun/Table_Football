using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Phone.Marketplace;

namespace Table_Football
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool trial;
        // Constructor
        public MainPage()
        {
           
            InitializeComponent();
            LicenseInformation a = new LicenseInformation();
            trial = a.IsTrial();

        }

        // Simple button Click event handler to take us to the second page
        

       

        private void Image_Tap_1(object sender, GestureEventArgs e)
        {
            
            Flag.game = 1;
            NavigationService.Navigate(new Uri("/Flag.xaml", UriKind.Relative));
            tikekle();
        }

        private void Image_Tap_2(object sender, GestureEventArgs e)
        {
            tikekle();
            if (!trial)
            {
                NavigationService.Navigate(new Uri("/PageSettings.xaml", UriKind.Relative));
            }
            else
            {
                if (MessageBox.Show("You can not arrive Settings page. To arrive Settings, Please buy Full Version of Table Football", "It's Trial", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    MarketplaceReviewTask task = new MarketplaceReviewTask();
                    tikekle();
                    task.Show();
                }
            }
            
            
        }

        private void Image_Tap_3(object sender, GestureEventArgs e)
        {
            Flag.game = 2;
            tikekle();
            if (!trial)
            {
                NavigationService.Navigate(new Uri("/Flag.xaml", UriKind.Relative));
            }
            else
            {
                if (MessageBox.Show("You can not arrive 2 Player page. If you want to play with 2 players, Please buy Full Version of Table Football", "It's Trial", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    MarketplaceReviewTask task = new MarketplaceReviewTask();
                    tikekle();
                    task.Show();
                }
            }
        }

        private void Image_Tap_4(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
            tikekle();
        }

        private void Image_Tap_5(object sender, GestureEventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            tikekle();
            task.Show();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            tok();

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
        public void tok()
        {

            Stream stream = TitleContainer.OpenStream("asdasfds.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();

        }

       
    }
}