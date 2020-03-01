using Godot;
using System;

public class Card : Node2D
{
    private CardSpec _spec;

    public const float WIDTH = 50.0f;
    public const float HEIGHT = 50.0f;

    public CardSpec spec
    {
        get { return _spec; }
        set
        {
            _spec = value;
        }
    }


    private void SyncProps()
    {
        var label = GetNode("Background/Label") as Label;
        label.Text = _spec.Text();

        Update();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SyncProps();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
