using System.Collections.Generic;

namespace BomberMan;


public class Animation
{
    private readonly Texture2D _texture;
    private readonly List<Rectangle> _source_rectangles = new();
    private readonly int _frames;
    private int _frame;
    private readonly float _frame_time;
    private float _frame_time_left;
    private bool _active = true;

    public Animation(Texture2D texture, int frame_x, int frame_y, float frame_time, int row = 1) 
    {
        _texture = texture;
        _frame_time = frame_time;
        _frames = frame_x;
        var frame_width = _texture.Width / frame_x;
        var frame_height = _texture.Height / frame_y;

        for (int i = 0; i < _frames; i++)
        {
            _source_rectangles.Add(new(i * frame_width, (row - 1) * frame_height, frame_width, frame_height));
        }
    }
    public void Stop()
    {
        _active = false;
    }

    public void Start()
    {
        _active = true;
    }

    public void Reset()
    {
        _frame = 0;
        _frame_time_left = _frame_time;
    }

    public void Update()
    {
        if (!_active) return;

        _frame_time_left -= Globals.TotalSeconds;

        if (_frame_time_left <= 0)
        {
            _frame_time_left += _frame_time;
            _frame = (_frame + 1) % _frames;
        }
    }

    public void Draw(Vector2 pos)
    {
        Globals.SpriteBatch.Draw(_texture, pos, _source_rectangles[_frame], Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
    }
}