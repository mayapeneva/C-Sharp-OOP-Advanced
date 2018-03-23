using System;

public class Rectangle : IDrawable
{
    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Height { get; }

    public int Width { get; }

    public void Draw()
    {
        this.DrawLine(this.Width, '*', '*');
        for (int i = 1; i < this.Height - 1; ++i)
        {
            this.DrawLine(this.Width, '*', ' ');
        }
        this.DrawLine(this.Width, '*', '*');
    }

    private void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);
        for (int i = 1; i < width - 1; ++i)
        {
            Console.Write(mid);
        }
        Console.WriteLine(end);
    }
}