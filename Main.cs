using Godot;
using System;

public class Main : Node2D
{
    public override void _Ready()
    {
        var template = ResourceLoader.Load<PackedScene>("res://Card.tscn");
        var card = template.Instance() as Card;

        var board = GetNode("Board");

        card.spec = new CardSpec { kind = CardKind.Down };
        card.Position = new Vector2(40, 40);
        board.AddChild(card);
    }
}
