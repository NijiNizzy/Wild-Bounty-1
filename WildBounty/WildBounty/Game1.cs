﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WildBounty
{
    /*
     * Author: Dezmon Gilbert
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

            // set up the finite state machine using a switch
            switch(gameState)
            {
                case GameState.Menu:
                    /* psuedo code for now until i can implement this 
                     * if(player presses 's')
                     * {
                     *      gameState = GameState.Game;
                     *      this.StartGame();
                     * }
                     * if(player presses 'c')
                     * {
                     *      gameState = GameState.Credits;
                     * }
                     * if(player presses 'h')
                     * {
                     *      gameState = GameState.Help;
                     * }
                     * if(player presses 'r')
                     * {
                     *      gameState = GameState.Scores;
                     * }
                     * */
                    break;
                case GameState.Game:
                    /*
                     * if(player health = 0)
                     * {
                     *      gameState = GameState.GameOver;
                     * }
                     * */
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Scores:
                    break;
                case GameState.Options:
                    break;
                case GameState.Credits:
                    break;
                case GameState.Help:
                    break;
                case GameState.About:
                    break;
                case GameState.Tips:
                    break;
                case GameState.Controls:
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

            base.Draw(gameTime);
        }
    }
}
