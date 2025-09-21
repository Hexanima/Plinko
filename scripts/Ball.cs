using Godot;

public partial class Ball : RigidBody2D
{
    private MeshInstance2D mesh;
    private PointLight2D light;

    public override void _Ready()
    {
        mesh = GetNode<MeshInstance2D>("RoundShape/MeshInstance2D");
        light = GetNode<PointLight2D>("PointLight2D");

        Color randomColor = new Color(GD.Randf(), GD.Randf(), GD.Randf());
        Modulate = randomColor;
        light.Color = randomColor;
    }

    public void _on_timer_timeout()
    {
        QueueFree();
    }
}
