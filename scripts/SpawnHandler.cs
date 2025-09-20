using System;
using Godot;

public partial class SpawnHandler : Node2D
{
    [Export]
    public PackedScene nodeToSpawnPath;

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("spawn"))
        {
            SpawnItem();
        }
    }

    public void SpawnItem(Vector2? location = null)
    {
        Vector2 spawnLocation = location ?? new Vector2(GlobalPosition.X, GlobalPosition.Y);
        Node2D node = nodeToSpawnPath.Instantiate<Node2D>();
        AddChild(node);
        node.GlobalPosition = spawnLocation;
        GD.Print("SPAWN!");
    }
}
