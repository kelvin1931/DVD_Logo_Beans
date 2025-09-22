using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _Logo;
        private Texture2D _food;
        private SpriteFont _font;
        private int foodXpos = 0;
        private int foodYpos = 0;
        private int _LogoXpos;
        private int _LogoYpos;
        private int _Xspeed = 0;
        private int _Yspeed = 0;
        private bool _hitEdgeRight;
        private bool _hitEdgeTop;
        private bool _foodNotTher;
        private int newX;
        private int newY;
        private float _elapsedTime = 0f;
        private Rectangle  _logoRectangle, _foodRectangle;
        private Vector2 scorePos = new Vector2(30, 10);
        private int _score = 0;
        private string scoreString = "";
        
        private Random Random = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _LogoXpos = _graphics.PreferredBackBufferWidth / 2;
            _LogoYpos = _graphics.PreferredBackBufferHeight / 2;

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
            _Logo = Content.Load<Texture2D>("Spoon");
            _food = Content.Load<Texture2D>("OIP (2)");
            _font = Content.Load<SpriteFont>("fontstuff");

            foodXpos = Random.Next(0, _graphics.PreferredBackBufferWidth - _food.Width);
            foodYpos = Random.Next(0, _graphics.PreferredBackBufferHeight - _food.Height);

            _logoRectangle = new Rectangle(_LogoXpos, _LogoYpos, _Logo.Width, _Logo.Height);
            _foodRectangle = new Rectangle(foodXpos, foodYpos, _food.Width, _food.Height);
            //Logo Name test

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown (Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (_LogoXpos > 0)
                {
                    _LogoXpos -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (_LogoXpos + _Logo.Width < _graphics.PreferredBackBufferWidth)
                {
                    _LogoXpos += 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (_LogoYpos + _Logo.Height < _graphics.PreferredBackBufferHeight)
                {
                    _LogoYpos += 5;
                }
            }
            if (Keyboard.GetState ().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (_LogoYpos > 0)
                {
                    _LogoYpos -= 5;
                }
            }
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_elapsedTime >= 0f)
            {
                foodXpos = Random.Next(0, _graphics.PreferredBackBufferWidth - _food.Width);
                foodYpos = Random.Next(0, _graphics.PreferredBackBufferHeight - _food.Height);
                _elapsedTime = 0;
            }

            if(_logoRectangle.Intersects(_foodRectangle))
            {
                foodXpos = Random.Next(0, _graphics.PreferredBackBufferWidth - _food.Width);
                foodYpos = Random.Next(0, _graphics.PreferredBackBufferHeight - _food.Height);
                _score += 1;
             }



            _logoRectangle.X = _LogoXpos;
            _logoRectangle.Y = _LogoYpos;
            _foodRectangle.X = foodXpos;
            _foodRectangle.Y = foodYpos;
                
                
                // TODO: Add your update logic here


            base.Update(gameTime);
        }
        
        
       
            
            
            
            protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.GhostWhite);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //put (x value, y value , width (800) , height (600) in Rectangle
            // _graphics.PreferredBackBufferWidth = 800;
            //_graphics.PreferredBackBufferHeight = 600;
            _spriteBatch.Draw(_Logo, _logoRectangle, Color.White);
            _spriteBatch.Draw(_food, _foodRectangle, Color.White);
            _spriteBatch.DrawString(_font,"Score:{_score}", scorePos, Color.Black);


            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
