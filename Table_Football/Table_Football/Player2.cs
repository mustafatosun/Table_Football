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
    class Player2
    {
        public Texture2D image;
        public Microsoft.Xna.Framework.Rectangle position;

        public Player2()
        {
            position.Height = position.Width = 34;

        }

        Vector2 ilk = Vector2.Zero;
        Vector2 son = Vector2.Zero;

        public void update(Ball ball, Player2[] team1)
        {
            TouchCollection touches = TouchPanel.GetState();
            foreach (TouchLocation touch in touches)
            {
                if (touch.Position.Y < 424)
                {
                    if (touch.State == TouchLocationState.Moved)
                    {
                        int farkX = (int)touch.Position.X-team1[0].position.X-10;
                        for (int i = 0; i < 10; i++)
                        {
                            team1[i].position.X += (int)farkX;
                        }
                        if (team1[0].position.X < 150 || team1[0].position.X > 300)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                team1[i].position.X -= (int)farkX;
                            }
                        }
                        for (int j = 0; j < 10; j++)
                        {
                            if (Math.Sqrt(Math.Pow(((ball.position.X + 10) - (team1[j].position.X + 17)), 2) + Math.Pow(((ball.position.Y + 10) - (team1[j].position.Y + 17)), 2)) < 27)
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    team1[i].position.X -= farkX;
                                }
                            }
                        }
                    }
                } 
            }     
        }
    }
}
