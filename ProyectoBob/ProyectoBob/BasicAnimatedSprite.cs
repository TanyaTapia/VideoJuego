#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework.Storage;
// using Microsoft.Xna.Framework.GamerServices;
#endregion



namespace ProyectoBob
{
    class BasicAnimatedSprite
    {
        // Atributos
        Rectangle pos;
        // Para las animaciones
        int frameCount;         //cuantos cuadros son en total
        int currentFrame;       //que cuadro tenemos que dibujar
        ArrayList textureList;  //arreglo que almacena los cuadros de los archivos muliples
        float timer;            
        float timePerFrame;     //que tiempo debe de ser mostrado cada cuadro
        bool multipleFiles;     
        bool collision;         
        Vector2 increment;      //velocidad del movimiento automatico
        bool move;              //att para asiganar movimiento automatico


        Rectangle pos2;
           
        // Metodos
        public void SetIncrement(Vector2 input)
        {
            increment = input;

        }

        public void SetMove(bool set)
        {
            move = set;
        }    

        public void LoadContent(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.textureList = new ArrayList();
            this.multipleFiles = true;

            // Cargamos la imagenes en el arreglo
            for (int k = 1; k <= frameCount; k++)
            {
                Texture2D tex;
                tex = Content.Load<Texture2D>(nameDir + "/" + nameFile + k.ToString("00"));
                textureList.Add(tex);
            }

            pos = new Rectangle(0, 0, (((Texture2D)textureList[0]).Width), (((Texture2D)textureList[0]).Height));
        }
       

        public void Update(GameTime gameTime)
        {
            // Se calcula
            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
            if (move)
            {
                pos.Y += (int)increment.Y;
                pos.X += (int)increment.X;

            }         
        }


        //Metodo para checar la colision, incluso cuando el personaje se encuentra en movimiento
        public bool Colision(Rectangle rect)
        {
            bool tempCol = pos.Intersects(rect);
            if (collision || tempCol)

                collision = true;
            return collision;
        }      

     
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            // Draw animated sprite based on multiple files


            if (multipleFiles)
            {
                if (currentFrame < textureList.Count)
                {
                    Texture2D tex = (Texture2D)textureList[currentFrame];
                    spriteBatch.Draw(tex, pos, Color.White);
                }
            }

            spriteBatch.End();
        }
        
        // Propiedad para obtener la posicion
        public Rectangle Pos
        {
            set
            {
                pos = value;
            }
            get
            {
                return pos;
            }
        }



    }
}
