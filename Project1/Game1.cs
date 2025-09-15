using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _Logo;
        private int _LogoXpos = 100;
        private int _LogoYpos = 100;
        private int _Xspeed = 0;
        private int _Yspeed = 0;
        private bool _hitEdgeRight;
        private bool _hitEdgeTop;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _Logo = Content.Load<Texture2D>("OIP");//Logo Name test

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown (Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _LogoXpos -= 4;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _LogoXpos += 4;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _LogoYpos += 4;
            }
            if (Keyboard.GetState ().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _LogoYpos -= 4;
            }

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //put (x value, y value , width (800) , height (600) in Rectangle
            // _graphics.PreferredBackBufferWidth = 800;
            //_graphics.PreferredBackBufferHeight = 600;
            _spriteBatch.Draw(_Logo, new Rectangle(_LogoXpos, _LogoYpos, 100, 100), Color.White);

            if (_LogoXpos + _Logo.Width < _graphics.PreferredBackBufferWidth)
            {
                _Xspeed -= 4;
            }
          
            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
