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
    class Snakes : Enemy
    {
    
             
        public void SnakesLoad (ContentManager Content)
        {
            this.Snaks1(Content, "Snakes", "Snake_f", 3, 0.15f);
        }
        public void SnakesLoad2(ContentManager Content)
        {
            this.Snaks2(Content, "SnakesA", "SnakeA_f", 3, 0.15f);
            
        }

        public void SnakesLoad3(ContentManager Content)
        {
            this.Snaks3(Content, "SnakesR", "SnakeR_f", 3, 0.15f);
        }
           
        public void Snak (ContentManager Content)
        {
            
            mySnakes = new ArrayList();

            myRandom = new Random();
           
            for (int s = 0;   s < 20; s++)
            {
                this.SnakesLoad(Content);
                this.SnakesLoad2(Content);
                this.SnakesLoad3(Content);

            
                nR = myRandom.Next(1, 4);
              

                if (nR == 1)
                {
                    Rectangle tempo =snake1.Pos;
                    if (s == 0)
                        tempo.X = 350;
                    if (s >= 1)
                        tempo.X = (myRandom.Next(360, 400)) + (((BasicAnimatedSprite)mySnakes[(s - 1)]).Pos.X); 


                    tempo.Y = posYs;
                   snake1.Pos = tempo;
                    mySnakes.Add(snake1);
                }
                else
                    if (nR == 2)
                    {
                        Rectangle tempo = snake2.Pos;
                        if (s == 0)
                            tempo.X = 350;
                        if (s >= 1)
                            tempo.X = (myRandom.Next(360, 400)) + (((BasicAnimatedSprite)mySnakes[(s - 1)]).Pos.X); 

                        tempo.Y = posYs;
                        snake2.Pos = tempo;

                        mySnakes.Add(snake2);
                    }

                    else
                        if (nR >= 3)
                        {
                            Rectangle tempo = snake3.Pos;
                            if (s == 0)
                                tempo.X = 350;
                            if (s >= 1)
                                tempo.X = (myRandom.Next(360, 400)) + (((BasicAnimatedSprite)mySnakes[(s - 1)]).Pos.X); 


                            tempo.Y = posYs;
                            snake3.Pos = tempo;

                            mySnakes.Add(snake3);
                        }

                direccion = SideDirection.snakes;
            }
        }

        }

    }

