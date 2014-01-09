//Declare two integer variables and assign them with 5 and 10 and after that exchange their values.

using System;

class ExchangingValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        a += b;
        b = a - b;
        a -= b;
    }
}