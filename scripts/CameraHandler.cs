using System;
using Godot;

public partial class CameraHandler : Camera2D
{
    private Node2D _afkText;

    public override void _Ready()
    {
        base._Ready();

        _afkText = GetNode<Node2D>("AfkText");
        _afkText.Scale = new Vector2(1 / Zoom.X, 1 / Zoom.Y);
    }
}
