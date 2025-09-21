using Godot;

public partial class Main : Node2D
{
    private bool afk = false;
    private Node2D label;
    private SpawnHandler spawnHandler;

    public override void _Ready()
    {
        label = GetNode<Node2D>("AfkText");
        spawnHandler = GetNode<SpawnHandler>("SpawnHandler");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("afk"))
            afk = !afk;

        label.Visible = afk;
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
