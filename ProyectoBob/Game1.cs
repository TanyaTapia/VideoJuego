#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
// using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace ProyectoBob
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        float screenWidth, screenHeight;

        MenuPrincipal menu;
        Nivel2 nivel2;
        Nivel1  nivel1;

        Scene currentScene;


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {

            menu = new MenuPrincipal();
            nivel1 = new Nivel1();
            nivel2 = new Nivel2();

            this.IsMouseVisible = true;
            this.graphics.IsFullScreen = true;
            this.screenWidth = graphics.GraphicsDevice.Viewport.Width;
            this.screenHeight = graphics.GraphicsDevice.Viewport.Height;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menu.LoadContent(Content);
            menu.PosicionBotones(screenWidth / 1.45f, screenHeight / 0.96f, screenWidth / 1.45f, screenHeight / 0.8f, screenWidth / 1.6f, screenHeight / 8);
            nivel1.LoadContent(Content);
            nivel2.LoadContent(Content);
        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (currentScene == Scene.Menu)
            {
                currentScene = menu.Update();
            }
            else if (currentScene == Scene.Level1)
            {
                currentScene = nivel1.Update(gameTime);
            }
            else if (currentScene == Scene.Level2)
            {
                currentScene = nivel2.Update(gameTime);
            }
            else if (currentScene == Scene.Exit)
            {
                this.Exit();
            }



            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);



            if (currentScene == Scene.Menu)
            {
                menu.Draw(spriteBatch);
            }
             else if (currentScene == Scene.Level1)
            {
                nivel1.Draw(spriteBatch);
            }
            else if (currentScene == Scene.Level2)
            {
                nivel2.Draw(spriteBatch);
            }
            spriteBatch.End();



            base.Draw(gameTime);

            
           
        }
    }
}
