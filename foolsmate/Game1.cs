using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace foolsmate
{

    enum Move
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Move move;

        Texture2D boardTexture;
        Rectangle window;

        Texture2D wPawnTexture;
        Texture2D bPawnTexture;
        Texture2D wQueenTexture;
        Texture2D wBishopTexture;
        Texture2D blunderTexture;




        Rectangle wPawnrect;
 
        Rectangle wBishoprect;
     
        Rectangle bPawn1rect, bPawn2rect, bPawn3rect,bPawn4rect;
       
        Rectangle wQueenrect;

        Rectangle blunder1rect, blunder2rect;


        int moveSpeed;
      
        
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            move = Move.One;
            moveSpeed = 2;
            window = new Rectangle(0,0 ,600,600);
            wPawnrect = new Rectangle(300, 450, 70, 70);
            bPawn1rect = new Rectangle(300, 80, 70,70);
            wBishoprect = new Rectangle(380, 535, 55, 55);
            wQueenrect = new Rectangle(230, 540, 70, 70);
            bPawn2rect = new Rectangle(520, 90, 70, 70);
            bPawn3rect = new Rectangle(240, 90, 70, 70);
            bPawn4rect = new Rectangle(381, 80, 70, 70);
            blunder1rect = new Rectangle(200, 40, 1000, 1000);
            blunder2rect = new Rectangle(400, 80, 1000, 1000);

 
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            boardTexture = Content.Load<Texture2D>("board");
            wPawnTexture = Content.Load<Texture2D>("wPawn");
            bPawnTexture = Content.Load<Texture2D>("bPawn");
            wBishopTexture = Content.Load<Texture2D>("wBishop");
            wQueenTexture = Content.Load<Texture2D>("wQueen");
            blunderTexture = Content.Load<Texture2D>("blunder (1)");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (move == Move.One)
            {
                wPawnrect.Y -= moveSpeed;

                if (wPawnrect.Y <= 312)
                    move = Move.Two;
            }
            else if (move == Move.Two)
            {
                bPawn1rect.Y += moveSpeed;
                if (bPawn1rect.Y >= 222)
                    move = Move.Three;

            }
            else if (move == Move.Three)
            {
                wQueenrect.X += moveSpeed;
                wQueenrect.Y -= moveSpeed;
                if (wQueenrect.X >= 534)
                    move = Move.Four;


            }
            else if (move== Move.Four)
            {

                bPawn2rect.Y += moveSpeed;
                if (bPawn2rect.Y>= 160)
                    move = Move.Five;
            }
            else if (move == Move.Five)
            {

                wBishoprect.X -= moveSpeed;
                wBishoprect.Y -= moveSpeed;
                if (wBishoprect.Y <= 305)
                    move = Move.Six;
            }
            else if (move == Move.Six)
            {

                bPawn3rect.Y += moveSpeed;
                if (bPawn3rect.Y >= 160)
                    move = Move.Seven;
            }
            else if (move == Move.Seven)
            {

                wQueenrect.X -= moveSpeed;
                wQueenrect.Y -= moveSpeed;

                if (wQueenrect.Y <= 75)
                {
                    move = Move.Eight;
                    bPawn4rect.Y = -100;
                    


                    
                    
                }
            }









            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(boardTexture, window, Color.White);
            _spriteBatch.Draw(wPawnTexture, wPawnrect, Color.White);
            _spriteBatch.Draw(wBishopTexture,wBishoprect, Color.White);
            _spriteBatch.Draw(wQueenTexture, wQueenrect,Color.White);
            _spriteBatch.Draw(bPawnTexture, bPawn1rect, Color.Green);
            _spriteBatch.Draw(bPawnTexture, bPawn2rect, Color.White);
            _spriteBatch.Draw(bPawnTexture, bPawn3rect, Color.Red);
            _spriteBatch.Draw(bPawnTexture,bPawn4rect, Color.White);
            _spriteBatch.Draw(blunderTexture, blunder1rect, Color.White);
            _spriteBatch.Draw(bPawnTexture, blunder2rect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
