using System;
using Godot;

public partial class SpawnHandler : Node2D
{
    private float _spawnRadius = 0.0F;

    [Export(PropertyHint.Range, "0,10,or_greater")]
    public float SpawnRadius
    {
        get => _spawnRadius;
        set => _spawnRadius = Math.Abs(value);
    }

    [Export]
    public float forceMultiplier = 1.0F;

    [Export]
    public PackedScene nodeToSpawnPath;

    public void FreefallSpawnItem(Vector2? spawnPosition = null)
    {
        GD.Print(SpawnRadius);
        Vector2 _spawnPosition = spawnPosition ?? GlobalPosition;

        AimedSpawnItem(_spawnPosition);
    }

    public void AimedSpawnItem(Vector2 aimedPosition, Vector2? spawnPosition = null)
    {
        Vector2 _spawnPosition = spawnPosition ?? GlobalPosition;
        Node2D node = nodeToSpawnPath.Instantiate<Node2D>();
        AddChild(node);
        node.GlobalPosition = new Vector2(
            _spawnPosition.X + (float)GD.RandRange(-SpawnRadius, SpawnRadius),
            _spawnPosition.Y + (float)GD.RandRange(-SpawnRadius, SpawnRadius)
        );

        if (node is RigidBody2D rigidBody)
        {
            Vector2 forceDirection = aimedPosition - _spawnPosition;
            rigidBody.ApplyForce(forceDirection * forceMultiplier);
        }
    }
}
