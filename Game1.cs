
namespace BomberMan;
public class Game1 : Game
{
    // Resolution
    Point game_resolution = new Point(1020, 800);
    RenderTarget2D render_target;
    Rectangle render_target_destination;
    

    // Background map
    private Texture2D _game_map;
    Rectangle? source_rectangle;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {

        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = game_resolution.X;
        _graphics.PreferredBackBufferHeight = game_resolution.Y;

        _graphics.ApplyChanges();

        render_target = new RenderTarget2D(GraphicsDevice, game_resolution.X, game_resolution.Y);
        render_target_destination = GetRenderTargetDestination(game_resolution, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

        base.Initialize();
    }

    // GetRenderTargetDestination and Center Rectangle used for window stretching.
    Rectangle GetRenderTargetDestination(Point resolution, int preferredBackBufferWidth, int preferredBackBufferHeight)
    {
        float resolutionRatio = (float)resolution.X / resolution.Y;
        float screenRatio;
        Point bounds = new Point(preferredBackBufferWidth, preferredBackBufferHeight);
        screenRatio = (float)bounds.X / bounds.Y;
        float scale;
        Rectangle rectangle = new Rectangle();

        if (resolutionRatio < screenRatio)
            scale = (float)bounds.Y / resolution.Y;
        else if (resolutionRatio > screenRatio)
            scale = (float)bounds.X / resolution.X;
        else
        {
            // Resolution and window/screen share aspect ratio
            rectangle.Size = bounds;
            return rectangle;
        }
        rectangle.Width = (int)(resolution.X * scale);
        rectangle.Height = (int)(resolution.Y * scale);
        
        return CenterRectangle(new Rectangle(Point.Zero, bounds), rectangle);
    }

    static Rectangle CenterRectangle(Rectangle outerRectangle, Rectangle innerRectangle)
    {
        Point delta = outerRectangle.Center - innerRectangle.Center;
        innerRectangle.Offset(delta);
        return innerRectangle;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _game_map = Content.Load<Texture2D>("Bomberman_Starting_Map");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_game_map, new Vector2(0,0), source_rectangle, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);


        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
