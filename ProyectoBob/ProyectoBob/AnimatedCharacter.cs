using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace ProyectoBob
{
   enum SideDirection { Stand_Right, Move_Right, GameOver, cac, snakes, bats}

    class AnimatedCharacter
    {
        // Attributes
        protected BasicSprite  cactus1, cactus2, cactus3;
        protected BasicAnimatedSprite snake1,snake2,snake3, bat1,bat2,bat3; //Enemigos del Nivel 2
        protected BasicAnimatedSprite  walkRigh;   
        protected SideDirection direccion;
        protected int incX = 2;
        protected float incY = 2;
        protected int posY = 550; //La posicion de los cactus en Y
        protected int posYs = 590;
        protected int posYb = 370;
 
        // Methods 

        //Loading metodo para animaciones con multiples archivos (BasicAnimatedSprite)     
        public virtual void LoadContent_WalkRight(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }  
        
        public virtual void Update(GameTime gameTime)
        {
            //Poner los valores por default         
            if (direccion == SideDirection.Move_Right)
                direccion = SideDirection.Stand_Right;
        }


        public virtual Rectangle Pos
        {
            set
            {
                walkRigh.Pos = value;

            }
            get { return walkRigh.Pos; }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            switch (direccion)
            {
                case SideDirection.Move_Right:
                    {
                        walkRigh.Draw(spriteBatch);
                        break;
                    }
            }
        }
    }
}


