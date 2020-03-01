using Godot;
using System;

public class Card : Node2D
{
    // Constants
    public const float WIDTH = 64.0f;
    public const float HEIGHT = 64.0f;

    // Properties
    private CardSpec spec;
    [Export]
    public CardSpec Spec
    {
        get { return spec; }
        set
        {
            spec = value;
            SyncProps();
        }
    }

    private Team team;
    [Export]
    public Team Team
    {
        get { return team; }
        set { team = value; SyncProps(); }
    }


    private void SyncProps()
    {
        var label = GetNode("Label") as Label;
        label.Text = spec.Text();

        var bg = GetNode("Background") as Control;
        bg.Modulate = team.Color();

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
