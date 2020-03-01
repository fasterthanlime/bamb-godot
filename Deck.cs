using Godot;
using System;
using System.Collections.Generic;

public class Deck : Node2D
{
    private Team team = Team.Blue;
    [Export]
    public Team Team
    {
        get
        {
            return team;
        }
        set
        {
            team = value;
            SyncProps();
        }
    }

    public List<Card> cards = new List<Card>();

    private void SyncProps()
    {
        var bg = GetNode("Background") as TextureRect;
        bg.Modulate = team.Color();

        Update();
    }

    public override void _Ready()
    {
        SyncProps();

        // instantiate all cards
        var template = ResourceLoader.Load<PackedScene>("res://Card.tscn");

        var margin = 10.0f;
        var padding = 10.0f;
        var x = margin + padding;
        var y = margin + padding;

        var specs = fullDeck();
        foreach (var spec in specs)
        {
            var card = template.Instance() as Card;
            card.Team = team;
            card.Spec = spec;
            card.Position = new Vector2(x, y);
            x += Card.WIDTH + padding;
            AddChild(card);
        }
    }

    private static CardSpec[] fullDeck()
    {

        CardSpec[] res = {
            new CardSpec { kind = CardKind.Numeric, value = 1 },
            new CardSpec { kind = CardKind.Numeric, value = 2 },
            new CardSpec { kind = CardKind.Numeric, value = 3 },
            new CardSpec { kind = CardKind.Numeric, value = 4 },
            new CardSpec { kind = CardKind.Numeric, value = 5 },
            new CardSpec { kind = CardKind.Numeric, value = 6 },
            new CardSpec { kind = CardKind.Numeric, value = 7 },
            new CardSpec { kind = CardKind.Down },
            new CardSpec { kind = CardKind.Up },
        };
        return res;
    }
}
