using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace ProyectoBob
{
    class Bats: Enemy
    {
        public void BatsLoad1(ContentManager Content)
        {
            this.Bat1(Content, "Bats", "Bat_f", 5, 0.15f);
        }
        public void BatsLoad2(ContentManager Content)
        {
            this.Bat2(Content, "BatsA", "BatA_f", 5, 0.15f);

        }

        public void BatsLoad3(ContentManager Content)
        {
            this.Bat3(Content, "BatsM", "BatM_f", 5, 0.15f);
        }

        public void TheBat(ContentManager Content)
        {
            myBats = new ArrayList();
            myRandom = new Random();

            for (int b= 0; b < 20; b++)
            {
                this.BatsLoad1(Content);
                this.BatsLoad2(Content);
                this.BatsLoad3(Content);


                nR = myRandom.Next(1, 4);

                if (nR == 1) 
                {
                    Rectangle tempo = bat1.Pos;
                    if (b == 0)
                        tempo.X = 600;
                    if (b >= 1)
                        tempo.X = (myRandom.Next(360, 400)) + (((BasicAnimatedSprite)myBats[(b - 1)]).Pos.X);

                    tempo.Y = posYb;
                    bat1.Pos = tempo;
                    myBats.Add(bat1);
                }
                else
                    if (nR == 2)
                    {
                        Rectangle tempo =bat2.Pos;
                        if (b == 0)
                            tempo.X = 600;
                        if (b >= 1)
                            tempo.X = (myRandom.Next(360, 400)) + (((BasicAnimatedSprite)myBats[(b - 1)]).Pos.X);

                        tempo.Y = posYb;
                        bat2.Pos = tempo;

                        myBats.Add(bat2);
                    }

                    else
                        if (nR >= 3)
                        {
                            Rectangle tempo = bat3.Pos;
                            if (b == 0)
                                tempo.X = 600;
                            if (b >= 1)
                                tempo.X = (myRandom.Next(360, 400)) + (((BasicAnimatedSprite)myBats[(b - 1)]).Pos.X);


                            tempo.Y = posYb;
                            bat3.Pos = tempo;

                          myBats.Add(bat3);
                        }

                direccion = SideDirection.bats;
            }
        }

      

        
       
    }
}
