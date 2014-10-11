#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Movement
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        /*public static Texture2D PARTICLE;
        public static Texture2D PIPE_DR;
        public static Texture2D PIPE_LD;
        public static Texture2D PIPE_RU;
        public static Texture2D PIPE_UR;
        public static Texture2D PIPE_L;
        public static Texture2D PIPE_T;*/
        int levelX = 1;
        Texture2D particle;
        Texture2D derek;
        Texture2D pipe1;
        Texture2D pipe2;
        Texture2D pipe3;
        Texture2D pipe4;
        Texture2D pipe5;
        Texture2D pipe6;
        Texture2D pipe7;
        Texture2D pipe8;
        Texture2D pipe9;
        Texture2D pipe10;
        Texture2D pipe11;
        ReadFile file = new ReadFile();
        // Pipe object (not currently used)
        PipeArrays[,] pipe = new PipeArrays[5,5];
       
        // Position array { 0, 1, 1, 6, 0, ... }
        //                { 0, 0, 0, 2, 0, ... }
        char[,] level1 = new char[5, 6];

        // Can leave { up, down, left, right } (not currently used)
        /*int[] pipe1A = new int[4] { 0, 0, 1, 1 };
        int[] pipe2A = new int[4] { 1, 1, 0, 0 };
        int[] pipe3A = new int[4] { 0, 1, 0, 1 };
        int[] pipe4A = new int[4] { 1, 0, 1, 0 };
        int[] pipe5A = new int[4] { 1, 0, 0, 1 };
        int[] pipe6A = new int[4] { 0, 1, 1, 0 };
        int[] pipe7A = new int[4] { 0, 1, 1, 1 };
        int[] pipe8A = new int[4] { 1, 1, 1, 0 };
        int[] pipe9A = new int[4] { 1, 0, 1, 1 };
        int[] pipe10A = new int[4] { 1, 1, 0, 1 };
        int[] pipe11A = new int[4] { 1, 1, 1, 1 };*/

        int particleX, particleY, particlePosX, particlePosY, particleDX, particleDY, dead;
        int x = 0, y = 0;
        public Game1()
            : base()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Set the width of the screen
            graphics.PreferredBackBufferWidth = 600;
            // Set the height of the screen
            graphics.PreferredBackBufferHeight = 500;
            // Apply the changes
            graphics.ApplyChanges();

            // Set starting position
            particleX = 150;
            particleY = 150;


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /*PIPE_DR = Content.Load<Texture2D>("PipeDR.png");
            PIPE_LD = Content.Load<Texture2D>("PipeLD.png");
            PIPE_RU = Content.Load<Texture2D>("PipeRU.png");
            PIPE_UR = Content.Load<Texture2D>("PipeUR.png");
            PIPE_L = Content.Load<Texture2D>("PipeL.png");
            PIPE_T = Content.Load<Texture2D>("PipeT.png");
            PARTICLE = Content.Load<Texture2D>("particle.png");*/
            
            // Add the texture to the dictionary
            GraphicsManager.AddTexture("particle", Content.Load<Texture2D>("particle"));
            // Set the texture key
            particle = GraphicsManager.GetTexture("particle");
            // Repeat ...
            GraphicsManager.AddTexture("Derek", Content.Load<Texture2D>("Derek"));
            derek = GraphicsManager.GetTexture("Derek");
            GraphicsManager.AddTexture("pipe1", Content.Load<Texture2D>("pipe1"));
            pipe1 = GraphicsManager.GetTexture("pipe1");
            GraphicsManager.AddTexture("pipe2", Content.Load<Texture2D>("pipe2"));
            pipe2 = GraphicsManager.GetTexture("pipe2");
            GraphicsManager.AddTexture("pipe3", Content.Load<Texture2D>("pipe3"));
            pipe3 = GraphicsManager.GetTexture("pipe3");
            GraphicsManager.AddTexture("pipe4", Content.Load<Texture2D>("pipe4"));
            pipe4 = GraphicsManager.GetTexture("pipe4");
            GraphicsManager.AddTexture("pipe5", Content.Load<Texture2D>("pipe5"));
            pipe5 = GraphicsManager.GetTexture("pipe5");
            GraphicsManager.AddTexture("pipe6", Content.Load<Texture2D>("pipe6"));
            pipe6 = GraphicsManager.GetTexture("pipe6");
            GraphicsManager.AddTexture("pipe7", Content.Load<Texture2D>("pipe7"));
            pipe7 = GraphicsManager.GetTexture("pipe7");
            GraphicsManager.AddTexture("pipe8", Content.Load<Texture2D>("pipe8"));
            pipe8 = GraphicsManager.GetTexture("pipe8");
            GraphicsManager.AddTexture("pipe9", Content.Load<Texture2D>("pipe9"));
            pipe9 = GraphicsManager.GetTexture("pipe9");
            GraphicsManager.AddTexture("pipe10", Content.Load<Texture2D>("pipe10"));
            pipe10 = GraphicsManager.GetTexture("pipe10");
            GraphicsManager.AddTexture("pipe11", Content.Load<Texture2D>("pipe11"));
            pipe11 = GraphicsManager.GetTexture("pipe11");
            file.Read(levelX);
            level1 = file.SetPosArray();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();
            bool leftArrowKeyDown = state.IsKeyDown(Keys.Left);
            bool rightArrowKeyDown = state.IsKeyDown(Keys.Right);
            bool upArrowKeyDown = state.IsKeyDown(Keys.Up);
            bool downArrowKeyDown = state.IsKeyDown(Keys.Down);

            // How far into the pipe is it (250 = 50)
            particleDX = particleX % 100;
            particleDY = particleY % 100;

            // Which element of the array is it in (250 = 2)
            particlePosX = (particleY - (particleDY)) / 100;
            particlePosY = (particleX - (particleDX)) / 100;

            // Check where it can go
            if (state.IsKeyDown(Keys.Right))
            {
                // If there is a pipe to your right
                if ((level1[particlePosY, particlePosX + 1] > 0 
                    // Or if you are not at the center
                    || (particleDX < 50)) 
                    // And are moving down the middle of the pipe
                    && (particleDY > 48 && particleDY < 52))
                {
                        // If the particle is missaligned
                    if ((particleDY > 48 && particleDY < 52))
                    {
                        // Realign the particle
                        particleY = (particlePosY * 100) + 50;
                    }
                    // If you are not at the center
                    if (particleDX < 50
                    // Or are at or past the center
                    || (particleDX >= 50
                        // Can the pipe exit right
                    && (level1[particlePosY, particlePosX] != 2
                    && level1[particlePosY, particlePosX] != 4
                    && level1[particlePosY, particlePosX] != 6
                    && level1[particlePosY, particlePosX] != 8)
                        // Can next pipe accept right
                        && (level1[particlePosY, particlePosX + 1] != 2
                        && level1[particlePosY, particlePosX + 1] != 3
                        && level1[particlePosY, particlePosX + 1] != 5
                        && level1[particlePosY, particlePosX + 1] != 10)))
                    // Move
                    { particleX = particleX + 2; }

                }
            }
            if (state.IsKeyDown(Keys.Down))
            {
                if ((level1[particlePosY + 1, particlePosX] > 0
                    || (particleDY < 50))
                    && (particleDX > 48 && particleDX < 52))
                {
                    if (particleDX > 48 && particleDX < 52)
                    {
                        particleX = (particlePosX * 100) + 50;
                    }
                    if (particleDY < 50
                    || (particleDY >= 50
                    && (level1[particlePosY, particlePosX] != 4
                    && level1[particlePosY, particlePosX] != 5
                    && level1[particlePosY, particlePosX] != 9
                    && level1[particlePosY, particlePosX] != 1)
                        && (level1[particlePosY + 1, particlePosX] != 1
                        && level1[particlePosY + 1, particlePosX] != 3
                        && level1[particlePosY + 1, particlePosX] != 6
                        && level1[particlePosY + 1, particlePosX] != 7)))
                    { particleY = particleY + 2; }

                }
            }
            if (state.IsKeyDown(Keys.Left))
            {
                if ((level1[particlePosY, particlePosX - 1] > 0 
                    || (particleDX > 50)) 
                    && (particleDY > 48 && particleDY < 52))
                {
                    if ((particleDY > 48 && particleDY < 52))
                    {
                        particleY = (particlePosY * 100) + 50;
                    }
                    if (particleDX > 50
                    || (particleDX <= 50
                    && (level1[particlePosY, particlePosX] != 2
                    && level1[particlePosY, particlePosX] != 3
                    && level1[particlePosY, particlePosX] != 5
                    && level1[particlePosY, particlePosX] != 10)
                        && (level1[particlePosY, particlePosX - 1] != 2
                        && level1[particlePosY, particlePosX - 1] != 4
                        && level1[particlePosY, particlePosX - 1] != 6
                        && level1[particlePosY, particlePosX - 1] != 8)))
                    { particleX = particleX - 2; }

                }
            }
            if (state.IsKeyDown(Keys.Up))
            {
                if ((level1[particlePosY - 1, particlePosX] > 0 || (particleDY > 50)) && (particleDX > 48 && particleDX < 52))
                {
                    if (particleDX > 48 && particleDX < 52)
                    {
                        particleX = (particlePosX * 100) + 50;
                    }
                    if (particleDY > 50
                    || (particleDY <= 50
                    && (level1[particlePosY, particlePosX] != 1
                    && level1[particlePosY, particlePosX] != 3
                    && level1[particlePosY, particlePosX] != 6
                    && level1[particlePosY, particlePosX] != 7))
                        && (level1[particlePosY - 1, particlePosX] != 1
                        && level1[particlePosY - 1, particlePosX] != 4
                        && level1[particlePosY - 1, particlePosX] != 5
                        && level1[particlePosY - 1, particlePosX] != 9))
                    { particleY = particleY - 2; }


                }
            }
           /*for (x = 0; x < 5; x++)
            {
                for (y = 0; y < 6; y++)
                {
                    System.Diagnostics.Debug.WriteLine(level1[x, y]);
                }
                Console.WriteLine("");
            }*/
            System.Diagnostics.Debug.WriteLine(level1[particlePosX, particlePosY]);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.DimGray);
            base.Draw(gameTime);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // Draw each maze piece (this will be done using the texture2D array)
            /* spriteBatch.Draw(pipe3, new Vector2(100, 100), Color.White);

            spriteBatch.Draw(pipe7, new Vector2(200, 100), Color.White);

            spriteBatch.Draw(pipe4, new Vector2(200, 200), Color.White);

            spriteBatch.Draw(pipe5, new Vector2(100, 200), Color.White);

            spriteBatch.Draw(pipe1, new Vector2(300, 100), Color.White);

            spriteBatch.Draw(pipe3, new Vector2(200, 300), Color.White);

            spriteBatch.Draw(pipe6, new Vector2(400, 100), Color.White);

            spriteBatch.Draw(pipe2, new Vector2(400, 200), Color.White);

            spriteBatch.Draw(pipe9, new Vector2(400, 300), Color.White);

            spriteBatch.Draw(pipe1, new Vector2(500, 300), Color.White);

            spriteBatch.Draw(pipe9, new Vector2(300, 300), Color.White);

            spriteBatch.Draw(pipe2, new Vector2(200, 400), Color.White);

            spriteBatch.Draw(pipe2, new Vector2(300, 200), Color.White); */
            for (x = 0; x < 5; x++)
            {
                for (y = 0; y < 6; y++)
                {
                        if (level1[x, y] == '0')
                             spriteBatch.Draw(particle, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '1')
                            spriteBatch.Draw(pipe1, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '2')
                            spriteBatch.Draw(pipe2, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '3')
                            spriteBatch.Draw(pipe3, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '4')
                            spriteBatch.Draw(pipe4, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '5')
                            spriteBatch.Draw(pipe5, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '6')
                            spriteBatch.Draw(pipe6, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '7')
                            spriteBatch.Draw(pipe7, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '8')
                            spriteBatch.Draw(pipe8, new Vector2(y * 100, x * 100), Color.White);
                        if (level1[x, y] == '9')
                            spriteBatch.Draw(pipe9, new Vector2(y * 100, x * 100), Color.White);
                        
                }
            }

            spriteBatch.Draw(particle, new Vector2(particleX - 50, particleY - 50), Color.White);
            spriteBatch.End();
        }
    }
}