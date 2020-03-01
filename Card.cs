using Godot;
using System;

public class Card : Control
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

    private Vector2? dragOrigin = null;
    public Vector2 Target = new Vector2(0, 0);

    private bool hovered = false;
    private bool Hovered
    {
        get { return hovered; }
        set { hovered = value; SyncProps(); }
    }


    private void SyncProps()
    {
        var label = GetNode("Label") as Label;
        label.Text = spec.Text();

        var bg = GetNode("Background") as Control;
        bg.Modulate = team.Color();
        if (hovered)
        {
            float h;
            float s;
            float v;
            bg.Modulate.ToHsv(out h, out s, out v);
            s *= 0.7f; // desaturate a little bit

            bg.Modulate = Color.FromHsv(h, s, v, bg.Modulate.a);
        }

        Update();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SyncProps();
    }

    public override void _Process(float delta)
    {
        if (dragOrigin == null)
        {
            if ((Target - RectPosition).LengthSquared() > 1)
            {
                var alpha = 0.2f;
                RectPosition = RectPosition * (1.0f - alpha) + Target * (alpha);
            }
        }
    }

    public void _OnMouseEntered()
    {
        GD.Print($"Mouse entered {team} {spec.Text()} card");
        Hovered = true;
    }

    public void _OnMouseExited()
    {
        GD.Print($"Mouse exited {team} {spec.Text()} card");
        Hovered = false;
    }

    public void _OnGuiInput(InputEvent ev)
    {
        GD.Print($"GUI input event {team} {spec.Text()} card {ev.AsText()}");

        if (ev is InputEventMouseButton butt)
        {
            if (butt.IsPressed())
            {
                dragOrigin = RectPosition;
            }
            else
            {
                if (dragOrigin != null)
                {
                    dragOrigin = null;
                }
            }
        }

        if (ev is InputEventMouseMotion motion)
        {
            if (dragOrigin != null)
            {
                RectPosition += motion.Relative;
            }
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
