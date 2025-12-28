using Godot;

public partial class Main : Node2D
{
    private bool afk = false;
    private Node2D label;
    private SpawnHandler spawnHandler;

    public override void _Ready()
    {
        label = GetNode<Node2D>("Camera/AfkText");
        label.Visible = afk;
        spawnHandler = GetNode<SpawnHandler>("SpawnHandler");
    }

    private bool _wasMousePressed = false;
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("afk"))
        {
            afk = !afk;
            label.Visible = afk;
        }

        bool isMousePressed = Input.IsMouseButtonPressed(MouseButton.Left);

        if (!afk)
        {
            if (Input.IsActionJustPressed("spawn"))
            {
                spawnHandler.FreefallSpawnItem();
            }

            if (isMousePressed && !_wasMousePressed)
            {
                spawnHandler.AimedSpawnItem(GetGlobalMousePosition());
            }
        }
        _wasMousePressed = isMousePressed;
    }

    public void _on_timer_timeout()
    {
        if (afk)
        {
            spawnHandler.AimedSpawnItem(
                new Vector2(
                    spawnHandler.GlobalPosition.X + GD.RandRange(-500, 500),
                    spawnHandler.GlobalPosition.Y + GD.RandRange(-500, 500)
                )
            );
        }
    }
}
