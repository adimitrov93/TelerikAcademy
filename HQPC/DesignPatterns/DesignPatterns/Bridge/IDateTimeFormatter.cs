namespace Bridge
{
    using System;

    // The "Implementor" class
    public interface ITimeFormatter
    {
        string Format(DateTime time);
    }
}
