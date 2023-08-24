using System;

namespace BomberMan;

/*
 Breakable rocks design: 
- 90% of the map should be filled with rocks.
- Have a chance to drop power ups when breaking rock (should be a low percentage)
- Make the rock break through player attacks (bombs)
 */

public class Rock
{
    private Vector2 _position;

    public Rectangle source_rectangle;
    private Single rotation = 0;
    private Single scale = 1.2f;

    private readonly Texture2D _rock_texture;

    //public Rock(Texture2D rock_texture)
    //{
    //    //_rock_texture = Globals.Content.Load<Texture2D>("Rock");

    //    _texture = rock_texture;
    //    _position = new Vector2(500, 500);

    //    // width: 56 px. Height: 62 px, x: -3px, -2 px;
    //    source_rectangle = new Rectangle(-3, -2, 58, 62);
    //}

    public Rock()
    {
        _rock_texture = Globals.Content.Load<Texture2D>("Rock");
        _position = new Vector2(500, 500);
        source_rectangle = new Rectangle(-3, -2, 58, 62);
    }


    // Make the rock breakable and have a chance to drop an item/powerup.
    public void Update()
    {

    }

    public void Draw()
    {
        //_sprite_batch.Draw(_texture, _position, source_rectangle, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);

        Globals.SpriteBatch.Draw(_rock_texture, _position, source_rectangle, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

}