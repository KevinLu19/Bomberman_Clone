namespace BomberMan;

public class GameManager
{
    // Playable Charaters
    private Enchantress _enchantress;
    private Rock _breakable_rock;

    public void Init()
    {
        _enchantress = new();
        _breakable_rock = new();
    }

    public void Update()
    {
        InputManager.Update();
        _enchantress.Update();
        _breakable_rock.Update();
    }

    public void Draw()
    {
        _enchantress.Draw();
        _breakable_rock.Draw();
    }

}