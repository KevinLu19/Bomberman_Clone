using System;

namespace BomberMan;

public class Enchantress : PlayableCharacterManager
{
    private Rectangle _source_rectangle;

    private readonly float _speed = 6f;
    private Single rotation = 0;
    private Single scale = 1.2f;

    private readonly Animation _idle_animation;
    private readonly Animation _run_animation;
    private Vector2 _enchantress_position;
    private static Texture2D _idle_texture;     // use this for vertical movement.
    private static Texture2D _run_texture;      // use this for horizontal movement.

    public Enchantress() 
    {
        _idle_texture ??= Globals.Content.Load<Texture2D>("Enchantress/Idle");
        _run_texture ??= Globals.Content.Load<Texture2D>("Enchantress/Run");

        _idle_animation = new(_idle_texture, 5, 1, 0.3f);
        _run_animation = new(_run_texture, 8, 1, 0.2f);

        _enchantress_position = new Vector2(60, 100);
        _source_rectangle = new(38, 61, 51, 67);
    }


    public void Update()
    {
        //if (_enchantress_position.Y >= 0 || _enchantress_position.Y <= 0)
        //{
        //    _idle_animation.Update();
        //}
        _idle_animation.Update();

        if (_enchantress_position.X > 0)
        {
            _run_animation.Update();
        }

        // Need to add when the user pressed a or d, start the run animation. Only animate when character is moving.
        // Need to add when a sprite is moving, use the Run sprite instead of the idle sprite.
        if (InputManager.Moving)
        {
            _enchantress_position += Vector2.Normalize(InputManager.Direction) * _speed;

            
        }
        
    }

    public void Draw()
    {
        _idle_animation.Draw(_enchantress_position);
    }

}