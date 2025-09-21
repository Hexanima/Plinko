using Godot;

public partial class SpawnHandler : Node2D
{
    [Export]
    public float forceMultiplier = 1.0F;

    [Export]
    public PackedScene nodeToSpawnPath;

    public void FreefallSpawnItem(Vector2? spawnPosition = null)
    {
        Vector2 _spawnPosition = spawnPosition ?? GlobalPosition;

        AimedSpawnItem(_spawnPosition);
    }

    public void AimedSpawnItem(Vector2 aimedPosition, Vector2? spawnPosition = null)
    {
        Vector2 _spawnPosition = spawnPosition ?? GlobalPosition;
        Node2D node = nodeToSpawnPath.Instantiate<Node2D>();
        AddChild(node);
        node.GlobalPosition = new Vector2(
            _spawnPosition.X + (float)GD.RandRange(-0.1, 0.1),
            _spawnPosition.Y
        );

        if (node is RigidBody2D rigidBody)
        {
            Vector2 forceDirection = aimedPosition - _spawnPosition;
            rigidBody.ApplyForce(forceDirection * forceMultiplier);
        }
    }
}
