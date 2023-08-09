using System;

namespace BomberMan;

/*
 Breakable rocks design: 
- 90% of the map should be filled with rocks.
- Have a chance to drop power ups when breaking rock (should be a low percentage)

 */

public class Rock
{
    private Texture2D _texture;
    private Vector2 _position;

    public Rectangle source_rectangle;
    private Single rotation = 0;
    private Single scale = 1.2f;

    public Rock(Texture2D rock_texture)
    {
        _texture = rock_texture;
        _position = new Vector2(500, 500);

        // width: 56 px. Height: 62 px, x: -3px, -2 px;
        source_rectangle = new Rectangle(-3, -2, 58, 62);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch _sprite_batch)
    {
        _sprite_batch.Draw(_texture, _position, source_rectangle, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

}