namespace BomberMan;

public class GameManager
{
    private Enchantress _enchantress;

    public void Init()
    {
        _enchantress = new();
    }

    public void Update()
    {
        InputManager.Update();
        _enchantress.Update();
    }

    public void Draw()
    {
        //_enchantress.Draw();
    }

}