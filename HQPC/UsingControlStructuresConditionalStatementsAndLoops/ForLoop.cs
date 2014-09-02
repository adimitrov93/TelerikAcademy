bool isValueFound = false;
for (int i = 0; i < 100; i++) 
{
    if (i % 10 == 0)
    {
        if (array[i] == expectedValue) 
        {
            isValueFound = true;
        }
    }

    Console.WriteLine(array[i]);
}

// More code here

if (isValueFound)
{
    Console.WriteLine("Value Found");
}