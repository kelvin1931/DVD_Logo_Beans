using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _Logo;
        private int _LogoXpos = 100;
        private int _LogoYpos = 100;
        private int _Xspeed = 2;
        private int _Yspeed = 2;
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



            // TODO: Add your update logic here
            
            if(_LogoXpos <= 0 )
            {
                _hitEdgeRight = false;
            }
            else if (_LogoXpos > 700)
            {
                _hitEdgeRight = true;
            }
            if (_hitEdgeRight == false)
            {
                _LogoXpos += 2;
            }
            else if(_hitEdgeRight == true)
            {
                _LogoXpos -= 2;
            }
            if(_LogoYpos <= 0 )
            {
                _hitEdgeTop = false;
            }
            else if( _LogoYpos > 500)
            {
                _hitEdgeTop = true;
            }
            if (_hitEdgeTop == false)
            {
                _LogoYpos += 2;
            }
            if (_hitEdgeTop == true)
            {
                _LogoYpos -= 2;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            //put (x value, y value , width , height) in Rectangle
            _spriteBatch.Draw(_Logo, new Rectangle(_LogoXpos, _LogoYpos, 100, 100), Color.White);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
