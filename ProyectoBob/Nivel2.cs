using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


namespace ProyectoBob
{
    class Nivel2
    {
       
        
        Bob bob;
        BasicMap theMap, theMap2;
        Snakes snake1, snake2, snake3;
        Bats bat1, bat2, bat3;
        Logo logo;
        bool GO;

        public void LoadContent(ContentManager Content)
        {


            theMap = new BasicMap();
            theMap2 = new BasicMap();
            bob = new Bob();
            logo = new Logo();

            bob.LoadContent(Content);
            Rectangle temp = bob.Pos;
            temp.X = 100;
            temp.Y = 430;
            temp.Width = 140;
            temp.Height = 210;
            bob.Pos = temp;
            bob.SetMap(theMap);

            // Snakes

            snake1 = new Snakes();
            snake2 = new Snakes();
            snake3 = new Snakes();


            snake1.SnakesLoad(Content);
            snake1.Snak(Content);
            snake1.LoadLifes(Content);

            snake2.SnakesLoad2(Content);
            snake2.Snak(Content);
            snake2.LoadLifes(Content);

            snake3.SnakesLoad3(Content);
            snake3.Snak(Content);
            snake3.LoadLifes(Content);

            //Bats

            bat1 = new Bats();
            bat2 = new Bats();
            bat3 = new Bats();


            bat1.BatsLoad1(Content);
            bat1.TheBat(Content);
            bat1.LoadLifes(Content);

            bat2.BatsLoad2(Content);
            bat2.TheBat(Content);
            bat2.LoadLifes(Content);

            bat3.BatsLoad3(Content);
            bat3.TheBat(Content);
            bat3.LoadLifes(Content);




            //Mapas
            theMap.LoadContent_Transitable(Content, "TransitableCueva.png", 0, -1);
            theMap.LoadContent_Notransitable("NoTransitableCueva", Content, 0, 640);
            theMap.SetIncrement(14);

            theMap2.LoadContent_Transitable(Content, "TransitableCueva.png", 4080, -1);
            theMap2.LoadContent_Notransitable("NoTransitableCueva", Content, 9072, 640);
            theMap2.SetIncrement(14);

            //Logo
            logo.LoadContent(Content);



        }

        public Scene Update(GameTime gameTime)
        {
            if (snake1.Gameover() | snake2.Gameover() | snake3.Gameover() | bat1.Gameover() | bat2.Gameover() | bat3.Gameover())
            {
                GO = true;
            }
            else
            {
                theMap.Update(gameTime);
                theMap2.Update(gameTime);
                bob.Update(gameTime);
                //Snakes
                snake1.UpdateEnemy(gameTime);
                snake2.UpdateEnemy(gameTime);
                snake3.UpdateEnemy(gameTime);

                snake1.Colision(bob.Pos);
                snake2.Colision(bob.Pos);
                snake3.Colision(bob.Pos);

                //Bats
                bat1.UpdateEnemy(gameTime);
                bat2.UpdateEnemy(gameTime);
                bat3.UpdateEnemy(gameTime);

                bat1.Colision(bob.Pos);
                bat2.Colision(bob.Pos);
                bat3.Colision(bob.Pos);

            }
            return Scene.Level2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            theMap.DrawOver(spriteBatch);
            theMap2.DrawOver(spriteBatch);

            if (GO)
            {

            }
            else
            {
                bob.Draw(spriteBatch);
                snake1.DrawEnemys(spriteBatch);
                snake2.DrawEnemys(spriteBatch);
                snake3.DrawEnemys(spriteBatch);
                bat2.DrawEnemys(spriteBatch);
                bat3.DrawEnemys(spriteBatch);
                bat1.DrawEnemys(spriteBatch);
                logo.Draw(spriteBatch);
            }
            snake2.DrawLife(spriteBatch);
            snake3.DrawLife(spriteBatch);
            snake1.DrawLife(spriteBatch);

            bat2.DrawLife(spriteBatch);
            bat3.DrawLife(spriteBatch);
            bat1.DrawLife(spriteBatch);

            theMap.DrawUnder(spriteBatch);
            theMap2.DrawUnder(spriteBatch);
        }
    }
}
