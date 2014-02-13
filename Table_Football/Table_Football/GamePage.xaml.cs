using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace Table_Football
{
    public partial class GamePage : PhoneApplicationPage
    {
        ContentManager contentManager;
        GameTimer timer;
        SpriteBatch spriteBatch;

        

        // players
        enum State {None,Goal,Win,Lose };
        State state;
        SpriteFont fontTeam;
        SpriteFont fontScore;
        SpriteFont fontBall;
        SpriteFont fontWinLose;
        Player1[] team1;
        Player2[] team2;
        Ball ball;
        int lastX;
        int lastY;
        int score1;
        int score2;
        int top;
        public static int botSpeed;
        public static string teamName1,teamName2;
        Texture2D flag1, flag2;


        public GamePage()
        {
            
            

            // Get the content manager from the application
            contentManager = (Application.Current as App).Content;

            // Create a timer for this page
            timer = new GameTimer();
            timer.UpdateInterval = TimeSpan.FromTicks(333333);
            timer.Update += OnUpdate;
            timer.Draw += OnDraw;
            duduk();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the sharing mode of the graphics device to turn on XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(true);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(SharedGraphicsDeviceManager.Current.GraphicsDevice);

            fontTeam = contentManager.Load<SpriteFont>("fontTeams");
            fontScore = contentManager.Load<SpriteFont>("fontScore");
            fontBall = contentManager.Load<SpriteFont>("fontBall");
            fontWinLose = contentManager.Load<SpriteFont>("fontWinLose");
            state=State.None;

            // TODO: use this.content to load your game content here
            
            score1 = 0;
            score2 = 0;
            top =7;
            
            flag1 = contentManager.Load<Texture2D>(teamName1.ToString());
            flag2 = contentManager.Load<Texture2D>(teamName2.ToString());

            team1 = new Player1[10];
            team2 = new Player2[10];
            ball=new Ball();
            lastX = ball.position.X;
            lastY = ball.position.Y;
            createTeams();
            // Start the timer
            timer.Start();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Set the sharing mode of the graphics device to turn off XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(false);

            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Allows the page to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        private void OnUpdate(object sender, GameTimerEventArgs e)
        {
            #region winLose
            if (top==0)
            {
                if (score1<score2)
                {
                    Settings.result = 2;
                    NavigationService.Navigate(new Uri("/WinLose.xaml", UriKind.Relative));
                }
                else
                {
                    Settings.result = 1;
                    NavigationService.Navigate(new Uri("/WinLose.xaml", UriKind.Relative));   
                }
            }
            #endregion

           

            #region Goooooool
            if (ball.position.Y<90)
            {
                state = State.Goal;
                if(top!=1)
                    goal();
                score1++;
                top--;
                ball.position.X = 230;
                ball.position.Y = 414;
                ball.position.Height = ball.position.Width = 120;
            }
            if (ball.position.Y>735)
            {
                state = State.Goal;
                if (top != 1)
                    goal();
                score2++;
                top--;
                ball.position.X = 230;
                ball.position.Y = 414;
                ball.position.Height = ball.position.Width = 120;
            }
            #endregion

            ball.update();

            #region carpışma
            for (int i = 0; i < 10; i++)
            {
                if (Math.Sqrt(Math.Pow(((ball.position.X+10)-(team1[i].position.X+17)),2)+Math.Pow(((ball.position.Y+10)-(team1[i].position.Y+17)),2))<=27)
                {
                    carpisma();
                    if (lastX == ball.position.X && lastY == ball.position.Y)
                    {
                        ball.update();
                        //break;

                    }
                    float bmX = ball.position.X + 10;
                    float bmY = -(ball.position.Y + 10);
                    float pmX = team1[i].position.X + 17;
                    float pmY = -(team1[i].position.Y + 17);
                    float ilkX = ball.position.X - ball.speed.X + 10;
                    float ilkY = -(ball.position.Y - ball.speed.Y + 10);
                    float a1 = bmY - pmY;
                    float b1 = -(bmX - pmX);
                    float c1 = bmY * (bmX - pmX) - bmX * (bmY - pmY);
                    float m1 = -a1 / b1;
                    float m2;
                    float a2;
                    float b2;
                    float c2;
                    if (b1 == 0)
                    {
                        m2 = 0;
                    }
                    else
                    {
                        m2 = -1 / m1;
                    }
                    if (m1 == 0)
                    {
                        a2 = 1;
                        b2 = 0;
                        c2 = -ilkX;
                    }
                    else
                    {
                        a2 = m2;
                        b2 = -1;
                        c2 = ilkY - m2 * ilkX;
                    }
                    float kesY = (a1 * c2 - a2 * c1) / (a2 * b1 - a1 * b2);
                    float kesX;
                    if (a1 == 0)
                    {
                        kesX = ilkX;
                    }
                    else
                    {
                        kesX = (-b1 * kesY - c1) / a1;
                    }
                    float sonX = 2 * kesX - ilkX;
                    float sonY = 2 * kesY - ilkY;
                    lastX = ball.position.X;
                    lastY = ball.position.Y;
                    while (Math.Sqrt(Math.Pow(((ball.position.X+10)-(team1[i].position.X+17)),2)+Math.Pow(((ball.position.Y+10)-(team1[i].position.Y+17)),2))<=27)
                    {
                       ball.position.X -= (int)ball.speed.X;
                       ball.position.Y -= (int)ball.speed.Y; 
                    }
                    
                    ball.speed.X = sonX - bmX;
                    ball.speed.Y = -(sonY - bmY);

                    if (Math.Sqrt(Math.Pow(((ball.position.X + (int)ball.speed.X + 10) - (team1[i].position.X + 17)), 2) + Math.Pow(((ball.position.Y + (int)ball.speed.Y + 10) - (team1[i].position.Y + 17)), 2)) <= 27)
                    {
                        ball.speed.X = -ball.speed.X;
                        ball.speed.Y = -ball.speed.Y;
                    }
                    
                    
                   
                   

                }

                if (Math.Sqrt( Math.Pow(((ball.position.X + 10) - (team2[i].position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (team2[i].position.Y + 17)), 2)) <= 27)
                {
                    carpisma();
                    if (lastX == ball.position.X && lastY == ball.position.Y)
                    {
                        ball.update();


                    }
                    float bmX = ball.position.X + 10;
                    float bmY = -(ball.position.Y + 10);
                    float pmX = team2[i].position.X + 17;
                    float pmY = -(team2[i].position.Y + 17);
                    float ilkX = ball.position.X - ball.speed.X + 10;
                    float ilkY = -(ball.position.Y - ball.speed.Y + 10);
                    float a1 = bmY - pmY;
                    float b1 = -(bmX - pmX);
                    float c1 = bmY * (bmX - pmX) - bmX * (bmY - pmY);
                    float m1 = -a1 / b1;
                    float m2;
                    float a2;
                    float b2;
                    float c2;
                    if (b1 == 0)
                    {
                        m2 = 0;
                    }
                    else
                    { 
                        m2 = -1 / m1;
                    }
                    if (m1==0)
                    {
                        a2 = 1;
                        b2 = 0;
                        c2 = -ilkX;
                    }
                    else
                    {
                        a2 = m2;
                        b2 = -1;
                        c2 = ilkY - m2 * ilkX;
                    }
                    float kesY = (a1 * c2 - a2 * c1) / (a2 * b1 - a1 * b2);
                    float kesX;
                    if (a1==0)
                    {
                        kesX = ilkX;
                    }
                    else
                    {
                        kesX = (-b1 * kesY - c1) / a1;
                    }
                    
                    float sonX = 2 * kesX - ilkX;
                    float sonY = 2 * kesY - ilkY;
                    lastX = ball.position.X;
                    lastY = ball.position.Y;
                    while (Math.Sqrt( Math.Pow(((ball.position.X + 10) - (team2[i].position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (team2[i].position.Y + 17)), 2)) <= 27)
                    {
                        ball.position.X -= (int)ball.speed.X;
                        ball.position.Y -= (int)ball.speed.Y;
                    }
                    ball.speed.X = sonX - bmX;
                    ball.speed.Y = -(sonY - bmY);
                    if (Math.Sqrt( Math.Pow(((ball.position.X +(int)ball.speed.X+ 10) - (team2[i].position.X + 17)), 2) + Math.Pow(((ball.position.Y+(int)ball.speed.Y + 10) - (team2[i].position.Y + 17)), 2)) <= 27)
                    {
                        ball.speed.X = -ball.speed.X;
                        ball.speed.Y = -ball.speed.Y;
                    }

                    
                    
                    

                    

                   // MessageBox.Show(ball.speed.X + "," + ball.speed.Y + "," + bmX + "," + bmY + "," + pmX + "," + pmY + "," + ilkX + ","+ilkY
                     //  + "," + a1 + "," + b1 + "," + c1 + "," + m1 + "," + m2 + "," + a2 + "," + b2 + "," + c2 + "," + kesY + "," + kesX + "," + sonX + ","+sonY);
                    

                    
                }
            }
            #endregion
            #region players kontrol
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.DoubleTap | GestureType.FreeDrag;
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                for (int i = 0; i < 10; i++)
                {
                    team1[i].position.X += (int)gesture.Delta.X;
                }
                if (team1[0].position.X < 150 || team1[0].position.X > 300)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        team1[i].position.X -= (int)gesture.Delta.X;
                    }
                }
                for (int j = 0; j < 10; j++)
                {
                    if (Math.Sqrt(Math.Pow(((ball.position.X + 10) - (team1[j].position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (team1[j].position.Y + 17)), 2)) < 27)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            team1[i].position.X -= (int)gesture.Delta.X;
                        }
                    }
                }
            }

            Player2 min = team2[0];
            for (int i = 0; i < 10; i++)
            {
                if (Math.Sqrt(Math.Pow(((ball.position.X + 10) - (team2[i].position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (team2[i].position.Y + 17)), 2)) < Math.Sqrt(Math.Pow(((ball.position.X + 10) - (min.position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (min.position.Y + 17)), 2)))
                {
                    if ((ball.speed.Y > 0 && team2[i].position.Y+17 > ball.position.Y+10) || (ball.speed.Y < 0 && team2[i].position.Y+17 < ball.position.Y+10))
                    {
                        min = team2[i];
                    }

                }
            }
            int gecici = 0;
            if (ball.speed.Y < 0)
            {
                if (min.position.X+17 < ball.position.X+10)
                {
                    gecici = botSpeed;
                }
                if (min.position.X+17 > ball.position.X+10)
                {
                    gecici = -botSpeed;
                }
            }
            else
            {
                if (min.position.X+17 > ball.position.X+10)
                {
                    gecici = botSpeed;
                }
                if (min.position.X+17 < ball.position.X+10)
                {
                    gecici = -botSpeed;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                team2[i].position.X += gecici;
            }
            if (team2[0].position.X < 150 || team2[0].position.X > 300)
            {
                for (int i = 0; i < 10; i++)
                {
                    team2[i].position.X -= gecici;
                }
            }
            for (int j = 0; j < 10; j++)
            {
                if (Math.Sqrt(Math.Pow(((ball.position.X + 10) - (team2[j].position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (team2[j].position.Y + 17)), 2)) < 27)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        team2[i].position.X -= gecici;
                    }
                }
            }




            #endregion
            //TouchCollection touch = TouchPanel.GetState();
            //foreach (TouchLocation to in touch)
            //{
            //    if (to.State == TouchLocationState.Pressed)
            //    {
            //        MessageBox.Show(to.Position.X + "," + to.Position.Y);
            //    }
            //}
        }

        /// <summary>
        /// Allows the page to draw itself.
        /// </summary>
        private void OnDraw(object sender, GameTimerEventArgs e)
        {
            SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();



            spriteBatch.Draw(contentManager.Load<Texture2D>("Saha"), new Microsoft.Xna.Framework.Rectangle(0, 0, GraphicsDeviceManager.DefaultBackBufferHeight, GraphicsDeviceManager.DefaultBackBufferWidth), Color.White);
            spriteBatch.Draw(ball.image,ball.position,Color.White);
            spriteBatch.Draw(flag1, new Microsoft.Xna.Framework.Rectangle(68, 4, 65, 35), Color.White);
            spriteBatch.Draw(flag2, new Microsoft.Xna.Framework.Rectangle(GraphicsDeviceManager.DefaultBackBufferHeight-65-68, 4, 65, 35), Color.White);

            spriteBatch.DrawString(fontTeam, teamName1, new Vector2(25, 30), Color.White);
            spriteBatch.DrawString(fontTeam, teamName2, new Vector2(314, 30), Color.White);
            spriteBatch.DrawString(fontScore, score1.ToString()+":"+score2.ToString(), new Vector2(202, 10), Color.White);
            spriteBatch.DrawString(fontBall, top.ToString(), new Vector2(237, 0), Color.White);
            

            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Draw(team1[i].image,team1[i].position,Color.White);
                spriteBatch.Draw(team2[i].image, team2[i].position, Color.White);
            }


            spriteBatch.End();
        }

        void createTeams()
        {
            ball.image = contentManager.Load<Texture2D>(Settings.imgBall);
            ball.position.X = 230;
            ball.position.Y = 414;
            for (int i = 0; i < 10; i++)
            {
                team1[i] = new Player1();
                team1[i].image = contentManager.Load<Texture2D>(Settings.imgP1);
                team2[i] = new Player2();
                team2[i].image = contentManager.Load<Texture2D>(Settings.imgP2);
            }

            team1[0].position.X = 224;
            team1[0].position.Y = 707;
            team2[0].position.X = 224;
            team2[0].position.Y = 102;

            team1[1].position.X = 152;
            team1[1].position.Y = 626;
            team1[2].position.X = 293;
            team1[2].position.Y = 626;
            team2[1].position.X = 152;
            team2[1].position.Y = 179;
            team2[2].position.X = 293;
            team2[2].position.Y = 179;

            if (Settings.dizilis1==3)
            {
                team1[3].position.X = 117;
                team1[3].position.Y = 454;
                team1[4].position.X = 223;
                team1[4].position.Y = 454;
                team1[5].position.X = 329;
                team1[5].position.Y = 454;
                

                team1[6].position.X = 96;
                team1[6].position.Y = 266;
                team1[7].position.X = 181;
                team1[7].position.Y = 266;
                team1[8].position.X = 266;
                team1[8].position.Y = 266;
                team1[9].position.X = 351;
                team1[9].position.Y = 266;
                
            }
            else
            {
                team1[3].position.X = 117;
                team1[3].position.Y = 266;
                team1[4].position.X = 223;
                team1[4].position.Y = 266;
                team1[5].position.X = 329;
                team1[5].position.Y = 266;


                team1[6].position.X = 96;
                team1[6].position.Y = 454;
                team1[7].position.X = 181;
                team1[7].position.Y = 454;
                team1[8].position.X = 266;
                team1[8].position.Y = 454;
                team1[9].position.X = 351;
                team1[9].position.Y = 454;
            }

            if (Settings.dizilis2==3)
            {
                team2[3].position.X = 117;
                team2[3].position.Y = 353;
                team2[4].position.X = 223;
                team2[4].position.Y = 353;
                team2[5].position.X = 329;
                team2[5].position.Y = 353;

                team2[6].position.X = 96;
                team2[6].position.Y = 545;
                team2[7].position.X = 181;
                team2[7].position.Y = 545;
                team2[8].position.X = 266;
                team2[8].position.Y = 545;
                team2[9].position.X = 351;
                team2[9].position.Y = 545;
            }
            else
            {
                team2[3].position.X = 117;
                team2[3].position.Y = 545;
                team2[4].position.X = 223;
                team2[4].position.Y = 545;
                team2[5].position.X = 329;
                team2[5].position.Y = 545;

                team2[6].position.X = 96;
                team2[6].position.Y = 353;
                team2[7].position.X = 181;
                team2[7].position.Y = 353;
                team2[8].position.X = 266;
                team2[8].position.Y = 353;
                team2[9].position.X = 351;
                team2[9].position.Y = 353;
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to return Main Page?", "Exit", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                e.Cancel = true;
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                
            }
            
        }

        public void carpisma()
        {

            Stream stream = TitleContainer.OpenStream("odun.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            if (Settings.sound)
            {
                effect.Play();
            }

        }
        public void duduk()
        {

            Stream stream = TitleContainer.OpenStream("hakem.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            if (Settings.sound)
            {
                effect.Play();
            }

        }
        public void goal()
        {

            Stream stream = TitleContainer.OpenStream("abc.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            if (Settings.sound)
            {
                effect.Play();
            }

        }
    }
}