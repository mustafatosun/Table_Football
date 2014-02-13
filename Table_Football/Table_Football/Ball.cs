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
    class Ball
    {
        public Texture2D image;
        public Microsoft.Xna.Framework.Rectangle position;
        public Vector2 speed;
        public Ball()
        {
            position.Height = position.Width = 122;
            speed.X = speed.Y = Settings.speed;
        }

        public void update()
        {

            if (position.Height<=20)
            {
                if (speed.Y < 1 && speed.Y >= 0)
                {
                    speed.Y = Settings.speed;
                    speed.X = Settings.speed;
                }
                if (speed.Y < 0 && speed.Y > -1)
                {
                    speed.X = -Settings.speed;
                    speed.Y = -Settings.speed;
                }
                position.X += (int)speed.X;
                position.Y += (int)speed.Y;

                if (position.X <= 38)
                {
                    position.X = 39;
                    carpisma();
                    speed.X = -speed.X;
                }
                if (position.X + 20 >= 443)
                {
                    position.X = 422;
                    carpisma();
                    speed.X = -speed.X;
                }
                if (position.Y <= 90 && (position.X <= 179 || position.X + 20 >= 303))
                {
                    position.Y = 91;
                    carpisma();
                    speed.Y = -speed.Y;
                }
                if (position.Y + 20 >= 755 && (position.X <= 179 || position.X + 20 >= 303))
                {
                    position.Y = 734;
                    carpisma();
                    speed.Y = -speed.Y;
                }
            }
            else
            {
                position.X = 240 - position.Width / 2;
                position.Y = 424 - position.Height / 2;
                position.Height -= 3;
                position.Width -= 3;
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

    }
}
