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
        Seven
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




        Rectangle wPawnrect;
 
        Rectangle wBishoprect;
     
        Rectangle bPawn1rect, bPawn2rect, bPawn3rect;
       
        Rectangle wQueenrect;
       
        
      
        
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
            window = new Rectangle(0,0 ,600,600);
            wPawnrect = new Rectangle(300, 450, 70, 70);
            bPawn1rect = new Rectangle(300, 80, 70,70);
            wBishoprect = new Rectangle(380, 535, 55, 55);
            wQueenrect = new Rectangle(230, 540, 70, 70);
            bPawn2rect = new Rectangle(520, 90, 70, 70);
            bPawn3rect = new Rectangle(240, 90, 70, 70);
 
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
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (move == Move.One)
            {
                wPawnrect.Y -= 1;

                if (wPawnrect.Y <= 312)
                    move = Move.Two;
            }
            else if (move == Move.Two)
            {
                bPawn1rect.Y += 1;
                if (bPawn1rect.Y >= 222)
                    move = Move.Three;

            }
            else if (move == Move.Three)
            {
                wQueenrect.X += 1;
                wQueenrect.Y -= 1;
                if (wQueenrect.X >= 534)
                    move = Move.Four;


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
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
