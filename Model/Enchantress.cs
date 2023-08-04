
using System;

namespace BomberMan;

public class Enchantress : PlayableCharacterManager
{
    public Texture2D enchantress_sprite;
    public Vector2 enchantress_position;
    public Rectangle source_rectangle;
    private readonly float _speed = 6f;
    private Single rotation = 0;
    private Single scale = 1.2f;


    public Enchantress() { }

    public Enchantress(Texture2D texture)
    {
        enchantress_sprite = texture;
        enchantress_position = new Vector2(100, 100);
        source_rectangle = new Rectangle(38, 61, 51, 67);
    }


    public void Update()
    {
        if (InputManager.Moving)
        {
            enchantress_position += Vector2.Normalize(InputManager.Direction) * _speed;
        }
    }

    public void Draw(SpriteBatch _sprite_batch)
    {
        _sprite_batch.Draw(enchantress_sprite, enchantress_position, source_rectangle, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f); ;

    }

}