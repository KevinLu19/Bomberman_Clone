using System;

namespace BomberMan;

public class Enchantress : PlayableCharacterManager
{
    // public Texture2D enchantress_sprite;
    
    private Rectangle _source_rectangle;

    private readonly float _speed = 6f;
    private Single rotation = 0;
    private Single scale = 1.2f;

    private readonly Animation _animation;
    private Vector2 _enchantress_position;
    private static Texture2D _enchantress_texture;

    public Enchantress() 
    {
        _enchantress_texture ??= Globals.Content.Load<Texture2D>("Enchantress/Idle");
        _animation = new(_enchantress_texture, 5, 1, 0.1f);
        _enchantress_position = new Vector2(100, 100);
        _source_rectangle = new(38, 61, 51, 67);
    }


    public void Update()
    {
        _animation.Update();

        // Need to add when a sprite is moving, use the Run sprite instead of the idle sprite.
        if (InputManager.Moving)
        {
            _enchantress_position += Vector2.Normalize(InputManager.Direction) * _speed;
        }
        
    }

    public void Draw()
    {
        _animation.Draw(_enchantress_position);
    }


    //public void Draw(SpriteBatch _sprite_batch)
    //{
    //    _sprite_batch.Draw(enchantress_sprite, enchantress_position, source_rectangle, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f); ;

    //}

}