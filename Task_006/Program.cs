var myFlag = new Derived();
myFlag.DrawAFlag();

abstract class Base
{
    public void DrawAFlag()
    {
        UpperColor();
        BottomCollor();
    }

    protected abstract void UpperColor();
    protected abstract void BottomCollor();
}

class Derived : Base
{
    protected override void UpperColor()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(new String('█', 7));
        Console.ResetColor();
    }

    protected override void BottomCollor()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(new String('█', 7));
        Console.ResetColor();
    }
}