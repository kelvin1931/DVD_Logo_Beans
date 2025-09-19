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
        private int foodXpos = 0;
        private int foodYpos = 0;
        private int _LogoXpos;
        private int _LogoYpos;
        private int _Xspeed = 0;
        private int _Yspeed = 0;
        private bool _hitEdgeRight;
        private bool _hitEdgeTop;
        private bool _foodNotThere;
        private int newX;
        private int newY;
        private float _elapsedTime;
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

            foodXpos = Random.Next(0, _graphics.PreferredBackBufferWidth - _food.Width);
            foodYpos = Random.Next(0, _graphics.PreferredBackBufferHeight - _food.Height);

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
                    _LogoXpos -= 4;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (_LogoXpos + _Logo.Width < _graphics.PreferredBackBufferWidth)
                {
                    _LogoXpos += 4;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (_LogoYpos + _Logo.Height < _graphics.PreferredBackBufferHeight)
                {
                    _LogoYpos += 4;
                }
            }
            if (Keyboard.GetState ().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (_LogoYpos > 0)
                {
                    _LogoYpos -= 4;
                }
            }
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_elapsedTime > 0)
            {
                
            }
            if(Rectangle.Intersect(("OIP 2"), ("SPOON"));

            { 
                foodXpos = Random.Next(0, _graphics.PreferredBackBufferWidth - _food.Width);
                foodYpos = Random.Next(0, _graphics.PreferredBackBufferHeight - _food.Height);
                Content.Load<Texture2D>("OIP 2");
                }
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //put (x value, y value , width (800) , height (600) in Rectangle
            // _graphics.PreferredBackBufferWidth = 800;
            //_graphics.PreferredBackBufferHeight = 600;
            _spriteBatch.Draw(_Logo, new Rectangle(_LogoXpos, _LogoYpos, _Logo.Width, _Logo.Height), Color.White);
            _spriteBatch.Draw(_food, new Rectangle(foodXpos, foodYpos, _food.Width, _food.Height), Color.White);



            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
