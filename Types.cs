using Godot;

public enum CardKind
{
    Numeric,
    Up,
    Down,
}

public enum Team
{
    Red,
    Blue,

}

public static class TeamExtensions
{
    public static Color Color(this Team color)
    {
        switch (color)
        {
            case Team.Red:
                return new Color("#ff4c3d");
            case Team.Blue:
                return new Color("#84e2ff");
            default:
                return new Color("#fa43fa");
        }
    }
}

public struct CardSpec
{
    public CardKind kind;

    // Value of the card (1 through 7), irrelevant if
    // `kind` isn't Numeric
    public int value;

    public string Text()
    {
        switch (this.kind)
        {
            case CardKind.Down:
                return "D";
            case CardKind.Up:
                return "U";
            case CardKind.Numeric:
                return $"{this.value}";
            default:
                return "?";
        }
    }
}

