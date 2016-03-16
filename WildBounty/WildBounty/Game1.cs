﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;

namespace WildBounty
{
    /*
     * Authors: Dezmon Gilbert
     * Purpose: To handle running the game 
     * Caveats: none
     * */
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        SpriteFont font;
        Texture2D playerImg;
        Texture2D bImage; 
        Player user;
        Bullet b;

        bool bulletExist;

        // attributes 
        enum GameState {Menu, // main menu
        Game,// the game being played
        GameOver, // when the game is finished
        Credits, // credit screen
        Scores, // screen to display scores
        Options, // screen to display the options
        Help, // help screen
        About,  // screen that gives information about the game and the creators
        Tips, // screen that gives the user tips on how to succeed and play
        Controls // shows the user the controls for the game
        }
        GameState gameState;
        KeyboardState kbState, prevKbState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            user = new Player(100, playerImg, 0, 0, 50, 50);
            //b = new Bullet(10, bImage, user.Rect.X, user.Rect.Y, 10, 10);
            bulletExist = false;

            // intial state of the game
            gameState = GameState.Menu;
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

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("Wild-West-1");
            font = Content.Load<SpriteFont>("SpriteFont1");
            playerImg = Content.Load<Texture2D>("CharacterAsset");
            bImage = Content.Load<Texture2D>("BulletAsset");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            prevKbState = kbState;
            kbState = Keyboard.GetState();

            // set up the finite state machine using a switch
            switch(gameState)
            {
                case GameState.Menu:
                    
                     if(this.SingleKeyPress(Keys.S)== true)
                     {
                        gameState = GameState.Game;
                        //this.StartGame();
                     }
                     if(this.SingleKeyPress(Keys.C)== true)
                     {
                        gameState = GameState.Credits;
                     }
                     if(this.SingleKeyPress(Keys.H)== true)
                     {
                        gameState = GameState.Help;
                     }
                     if (this.SingleKeyPress(Keys.R) == true)
                     {
                        gameState = GameState.Scores;
                     }
                     
                    break;
                case GameState.Game:
                    
                     /*if(player.Health == 0)
                     {
                        gameState = GameState.GameOver;
                     }
                     if(enemy.Health == 0)
                     {
                        player.BountyScore += enemy.Points;
                     }*/

                    // Player Movement
                    if(kbState.IsKeyDown(Keys.Up))
                    {
                        user.Rect = new Rectangle(user.Rect.X, user.Rect.Y - 5, user.Rect.Width, user.Rect.Height);
                        ScreenWrap(user);
                    }

                    if(kbState.IsKeyDown(Keys.Left))
                    {
                        user.Rect = new Rectangle(user.Rect.X - 5, user.Rect.Y, user.Rect.Width, user.Rect.Height);
                        ScreenWrap(user);
                    }

                    if(kbState.IsKeyDown(Keys.Down))
                    {
                        user.Rect = new Rectangle(user.Rect.X, user.Rect.Y + 5, user.Rect.Width, user.Rect.Height); 
                        ScreenWrap(user);
                    }

                    if(kbState.IsKeyDown(Keys.Right))
                    {
                        user.Rect = new Rectangle(user.Rect.X + 5, user.Rect.Y, user.Rect.Width, user.Rect.Height); 
                        ScreenWrap(user);
                    }

                    // Bullets
                    if(kbState.IsKeyDown(Keys.Space)&&bulletExist == false)
                    {
                        b = new Bullet(10, bImage, user.Rect.X+50, user.Rect.Y+10, 10, 10);
                        bulletExist = true;
                        /*for (int i = 0; i < 5; i++)
                        {
                            b.Rect = new Rectangle(b.Rect.X + 5, b.Rect.Y, b.Rect.Width, b.Rect.Height);
                        }*/
                    }
                    if(bulletExist == true)
                    {
                        b.Rect = new Rectangle(b.Rect.X + 10, b.Rect.Y, b.Rect.Width, b.Rect.Height);
                        if(b.Rect.X > GraphicsDevice.Viewport.Width)
                        {
                            bulletExist = false;
                        }
                    }

                    break;
                case GameState.GameOver:
                    
                     if(this.SingleKeyPress(Keys.T)== true) // for try again
                     {
                        gameState = GameState.Game;
                     }
                     if(this.SingleKeyPress(Keys.M)== true) 
                     {
                        gameState = GameState.Menu;
                     }
                     
                    break;
                case GameState.Scores:
                    
                     if(this.SingleKeyPress(Keys.B)== true)
                     {
                        gameState = GameState.Menu;
                     }   
                     
                    break;
                case GameState.Options:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Menu;
                    } 
                    break;
                case GameState.Credits:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Menu;
                    } 
                    break;
                case GameState.Help:
                    if(this.SingleKeyPress(Keys.B)== true)
                     {
                        gameState = GameState.Menu;
                     } 
                     if(this.SingleKeyPress(Keys.A) == true)
                     {
                        gameState = GameState.About;
                     } 
                     if(this.SingleKeyPress(Keys.T) == true)
                     {
                        gameState = GameState.Tips;
                     } 
                     if(this.SingleKeyPress(Keys.C) == true)
                     {
                        gameState = GameState.Controls;
                     } 
                     
                    break;
                case GameState.About:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Help;
                    }
                    break;
                case GameState.Tips:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Help;
                    }
                    break;
                case GameState.Controls:
                    if (this.SingleKeyPress(Keys.B) == true)
                    {
                        gameState = GameState.Help;
                    }
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if(gameState == GameState.Menu)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(font, "Wild Bounty", new Vector2(200, 120), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "Press S to Start", new Vector2(200, 190), Color.Red);
                spriteBatch.DrawString(font, "Press C for Credits", new Vector2(200, 210), Color.Red);
                spriteBatch.DrawString(font, "Press H for Help", new Vector2(200, 230), Color.Red);
                spriteBatch.DrawString(font, "Press R for Scores", new Vector2(200, 250), Color.Red);
            } 
            if (gameState == GameState.Game)
            {
                spriteBatch.Draw(playerImg, user.Rect, Color.White);
                if(bulletExist == true)
                {
                    spriteBatch.Draw(bImage, b.Rect, Color.White);
                }
            }
            if (gameState == GameState.GameOver)
            {

            }
            if (gameState == GameState.Scores)
            {
                GraphicsDevice.Clear(Color.Azure);
            }
            if (gameState == GameState.Options)
            {

            }
            if (gameState == GameState.Credits)
            {

            }
            if (gameState == GameState.Help)
            {

            }
            if (gameState == GameState.About)
            {

            }
            if (gameState == GameState.Tips)
            {

            }
            if (gameState == GameState.Controls)
            {

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        // checks to see if a button was pressed
        public bool SingleKeyPress(Keys key)
        {
            if (kbState.IsKeyDown(key) == true && prevKbState.IsKeyDown(key) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ScreenWrap(GameObject g)
        {
            if (g.Rect.X < -g.Rect.Width)
            {
                g.Rect = new Rectangle(GraphicsDevice.Viewport.Width, g.Rect.Y, g.Rect.Width, g.Rect.Height);
            }
            if (g.Rect.X > GraphicsDevice.Viewport.Width)
            {
                g.Rect = new Rectangle(0, g.Rect.Y, g.Rect.Width, g.Rect.Height);
            }
            if (g.Rect.Y < -g.Rect.Height)
            {
                g.Rect = new Rectangle(g.Rect.X, GraphicsDevice.Viewport.Height, g.Rect.Width, g.Rect.Height);
            }
            if (g.Rect.Y > GraphicsDevice.Viewport.Height)
            {
                g.Rect = new Rectangle(g.Rect.X, 0, g.Rect.Width, g.Rect.Height);
            }
        }
    }
}
