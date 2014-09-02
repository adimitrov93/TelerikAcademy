using System;

public class Size
{
    private double width;
    private double height;

    public Size(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public static Size GetRotatedSize(Size size, double angle)
    {
        double absCosAngle = Math.Abs(Math.Cos(angle));
        double absSinAngle = Math.Abs(Math.Sin(angle));

        double rotatedWidth = absCosAngle * size.width + absSinAngle * size.height;
        double rotatedHeight = absSinAngle * size.width + absCosAngle * size.height;
        Size rotatedSize = new Size(rotatedWidth, rotatedHeight);

        return rotatedSize;
    }
}