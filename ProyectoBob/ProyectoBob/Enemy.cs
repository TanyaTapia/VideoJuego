using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

enum Life { Life0,Life1,Life2,Life3, gameover}

//Los enemigos tendran en comun el movimiento automatico y la capacidad de restar vidas a Bob
namespace ProyectoBob
{
    class Enemy : AnimatedCharacter  
    {
        BasicSprite Life0,Life1, Life2, Life3, GameOver, GObob;
        protected Life Lifes;
        int carga=3;
        float delay = 2500f;
        float delayJuego = 0;
        bool game;
        protected ArrayList Cactu; //Cargar muchos enemigos en un arreglo
        protected ArrayList mySnakes;
        protected ArrayList myBats;
        protected Random myRandom;
        protected int nR;


        public override Rectangle Pos
        {

            set
            {
                if (direccion == SideDirection.cac)
                {
                    //Dar la posicion de cada uno de los cactus 
                    for (int i = 0; i < Cactu.Count; i++)
                    {
                        ((BasicSprite)Cactu[i]).Pos = value;
                    }
                }

                if (direccion == SideDirection.snakes)
                {
                    for (int s = 0; s < mySnakes.Count; s++)
                    {
                        ((BasicAnimatedSprite)mySnakes[s]).Pos = value;
                    }
                }
                if (direccion == SideDirection.bats)
                {
                    for (int b = 0; b < myBats.Count; b++)
                    {
                        ((BasicAnimatedSprite)myBats[b]).Pos = value;
                    }
                }

            }

        }


        //Cargar los sprites de Cactus 
        public virtual void LoadContentCactus1(ContentManager Content, String dirName, String name)
        {
            cactus1 = new BasicSprite();
            cactus1.LoadContent(Content, dirName, name);
        }

        public virtual void LoadContentCactus2(ContentManager Content, String dirName, String name)
        {
            cactus2 = new BasicSprite();
            cactus2.LoadContent(Content, dirName, name);
        }

        public virtual void LoadContentCactus3(ContentManager Content, String dirName, String name)
        {
            cactus3 = new BasicSprite();
            cactus3.LoadContent(Content, dirName, name);
        }
//______________________________________________________Enemy  NIVEL2_________________________________________________________________________________________________________________


        //Cargar aqui los valores de los sprites de vivoras
        public virtual void Snaks1(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            snake1 = new BasicAnimatedSprite();
            snake1.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);

        }
        public virtual void Snaks2(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            snake2 = new BasicAnimatedSprite();
            snake2.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);

        }

        public virtual void Snaks3(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            snake3 = new BasicAnimatedSprite();
            snake3.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);

        }
 //_______________________________Bats__________________________________

        //Cargar aqui los valores de los sprites de murcielagos 
      
        public virtual void Bat1(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            bat1 = new BasicAnimatedSprite();
            bat1.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);

        }

        public virtual void Bat2(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            bat2 = new BasicAnimatedSprite();
            bat2.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);

        }
        public virtual void Bat3(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            bat3 = new BasicAnimatedSprite();
            bat3.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);

        }
 //_________________________________________________________________________________________________________________________________________________________________________________
        




        //Cargar aqui los valores de los sprites de murcielagos 
        
        public virtual void LoadLifes(ContentManager Content)
        {

            Life0 = new BasicSprite();
            Life0.LoadContent(Content, "Life", "LifeCero");

            Life1 = new BasicSprite();
            Life1.LoadContent(Content, "Life", "LifeUno");

            Life2 = new BasicSprite();
            Life2.LoadContent(Content, "Life", "LifeDos");

            Life3 = new BasicSprite();
            Life3.LoadContent(Content, "Life", "LifeTres");


            GameOver = new BasicSprite();
            GameOver.LoadContent(Content, "Menu", "gameover");

            GObob = new BasicSprite();
            GObob.LoadContent(Content, "Menu", "GObob");

            Lifes = Life.Life3;
            
        }


      public virtual Scene Colision(Rectangle rect)
        {

            if (direccion == SideDirection.cac)
            {
                for (int i = 0; i < Cactu.Count; i++)
                {
                    delay++;
                    delayJuego++;
                    bool n = ((BasicSprite)Cactu[i]).Colision(rect);

                    if (delay >= 2500)
                    {
                        if (((BasicSprite)Cactu[i]).Colision(rect) && carga == 3)
                        {

                            Lifes = Life.Life2;
                            carga = 2;
                            delay = 0;
                        }
                        else if (((BasicSprite)Cactu[i]).Colision(rect) && carga == 2)
                        {

                            Lifes = Life.Life1;
                            carga = 1;
                            delay = 0;
                        }
                        else if (((BasicSprite)Cactu[i]).Colision(rect) && carga <= 1)
                        {
                            Lifes = Life.Life0;
                            Lifes = Life.gameover;
                            carga = 0;
                            delay = 0;
                        }

                    }
                }

            }
            else
            if (direccion == SideDirection.snakes)
            {
                for (int i = 0; i < mySnakes.Count; i++)
                {
                    delay++;
                    bool n = ((BasicAnimatedSprite)mySnakes[i]).Colision(rect);

                    if (delay >= 2500)
                    {
                        if (((BasicAnimatedSprite)mySnakes[i]).Colision(rect) && carga == 3)
                        {

                            Lifes = Life.Life2;
                            carga = 2;
                            delay = 0;
                        }
                        else if (((BasicAnimatedSprite)mySnakes[i]).Colision(rect) && carga == 2)
                        {

                            Lifes = Life.Life1;
                            carga = 1;
                            delay = 0;
                        }
                        else if (((BasicAnimatedSprite)mySnakes[i]).Colision(rect) && carga <= 1)
                        {
                            Lifes = Life.Life0;
                            Lifes = Life.gameover;
                            carga = 0;
                            delay = 0;
                        }

                    }
                }
                
           

             }


            if (direccion == SideDirection.bats)
            {
                for (int i = 0; i < myBats.Count; i++)
                {
                    delay++;
                    bool n = ((BasicAnimatedSprite)myBats[i]).Colision(rect);

                    if (delay >= 2500)
                    {
                        if (((BasicAnimatedSprite)myBats[i]).Colision(rect) && carga == 3)
                        {

                            Lifes = Life.Life2;
                            carga = 2;
                            delay = 0;
                        }
                        else if (((BasicAnimatedSprite)myBats[i]).Colision(rect) && carga == 2)
                        {

                            Lifes = Life.Life1;
                            carga = 1;
                            delay = 0;
                        }
                        else if (((BasicAnimatedSprite)myBats[i]).Colision(rect) && carga <= 1)
                        {
                            Lifes = Life.Life0;
                            Lifes = Life.gameover;
                            carga = 0;
                            delay = 0;
                        }

                    }
                }

           
            }

            if (carga == 0)
            {
                return Scene.Menu;                
            }
        
             else if (delayJuego > 60000) //Tiempo estimado para saltar los 20 cactus
                return Scene.Level2;
            else
                return Scene.Level1;

         }

         public virtual bool Gameover()
        {

            if (Lifes == Life.gameover)
                game = true;
            else
                game = false;

            return game;
            
        }



        public  virtual void UpdateEnemy (GameTime gameTime)
         {
            
             //PARA CACTUS 
             if (direccion == SideDirection.cac)
             {
                 for (int k = 0; k < Cactu.Count; k++)
                 {
                     ((BasicSprite)Cactu[k]).SetMove(true);
                     ((BasicSprite)Cactu[k]).SetIncrement(new Vector2(-2, 0));
                     ((BasicSprite)Cactu[k]).Update(gameTime);
                     
                 }
             }

            if (direccion == SideDirection.snakes)
            {
                 for (int s = 0; s < mySnakes.Count; s++)
                 {

                     ((BasicAnimatedSprite)mySnakes[s]).SetMove(true);
                     ((BasicAnimatedSprite)mySnakes[s]).SetIncrement(new Vector2(-2, 0));
                     ((BasicAnimatedSprite)mySnakes[s]).Update(gameTime);
                    
                     
                  
                  }
            }

            if (direccion == SideDirection.bats)
            {
                for (int b = 0; b < myBats.Count; b++)
                {
                    ((BasicAnimatedSprite)myBats[b]).SetMove(true);
                    ((BasicAnimatedSprite)myBats[b]).SetIncrement(new Vector2(-2, 0));         
                    ((BasicAnimatedSprite)myBats[b]).Update(gameTime);
                }
            }
         }


        public virtual void DrawEnemys(SpriteBatch spriteBatch)
        {
            switch (direccion)
            {
                    //Pintar los cactus
                case SideDirection.cac:
                    {
                        for (int k = 0; k < Cactu.Count; k++)
                            ((BasicSprite)Cactu[k]).Draw(spriteBatch);
                        break;
                    }

                case SideDirection.snakes:
                    {
                        for (int s = 0; s < mySnakes.Count; s++)


                            ((BasicAnimatedSprite)mySnakes[s]).Draw(spriteBatch);
                             break;
                    }
                case SideDirection.bats:
                    {
                        for (int b= 0; b < myBats.Count; b++)
                            ((BasicAnimatedSprite)myBats[b]).Draw(spriteBatch);
                        break;
                    }


            }
        }

            public virtual void DrawLife(SpriteBatch spriteBatch )
            {
                switch(Lifes)
                {
                    case Life.Life3:
                        {
                            Rectangle temp = Life3.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life3.Pos = temp;
                            Life3.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life2:
                        {
                            Rectangle temp = Life2.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life2.Pos = temp;
                            Life2.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life1:
                        {
                            Rectangle temp = Life1.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life1.Pos = temp;
                            Life1.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life0:
                        {
                            Rectangle temp = Life0.Pos;
                            temp.X = 1100;
                            temp.Y = 0;
                            Life0.Pos = temp;
                            Life0.Draw(spriteBatch);
                            break;
                        }
                    case Life.gameover:
                        {
                            Rectangle tem = GameOver.Pos;
                            tem.X = 350;
                            tem.Y = 50;
                            GameOver.Pos = tem;
                            GameOver.Draw(spriteBatch);

                            Rectangle tempo = GObob.Pos;
                            tempo.X = 550;
                            tempo.Y = 400;
                            GObob.Pos = tempo;
                            GObob.Draw(spriteBatch);
                            break;
                        }
                }
            }
         
        }




    }

