using System;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHavier()
    {
        var result = this.left.CompareTo(this.right);
        if (result > 0)
        {
            return this.left;
        }
        if (result < 0)
        {
            return this.right;
        }

        return default(T);
    }
}