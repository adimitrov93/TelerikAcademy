//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

//I implemented this task in two ways. First of them (right after opening it -> ctrl + F5) is regular with one method, inside of witch is one "while" loop.
//Second is after you comment the line 16 and the first method and uncomment lines 18, 19, 21 and uncomment the second method. The second method is more interesting,
//because it is implemented using recursion. If you don't know what is that creature - google it. Long story short - the method calls itself.
//I recommend to debug the program by using F11 for the steps to see how is it working.

using System;

class BinarySearch
{
    static void Main()
    {
        int[] array = { 0, 1, 2, 4, 9, 12, 24, 25, 26, 29, 35, 49, 51, 62, 63, 64, 65, 66, 67, 80, 100, 101, 102, 104 };

        int searchedNumber = 68;

        int searchedIndex = BinarySearchMethod(array, searchedNumber);      //this must be commented for method 2

        //int startIndex = 0;                                               //this 3 rows must be uncommented for method 2
        //int endIndex = array.Length - 1;

        //int searchedIndex = BinarySearchMethod(array, searchedNumber, startIndex, endIndex);

        if (searchedIndex == -1)
        {
            Console.WriteLine("This number does not exist in this array.");
        }
        else
        {
            Console.WriteLine("{0} is at index {1}.", searchedNumber, searchedIndex);
        }
    }

    static int BinarySearchMethod(int[] array, int searchedNumber)          //this method must be commented too
    {
        int start = 0;
        int mid;
        int end = array.Length - 1;

        while (start <= end)
        {
            mid = (start + end) / 2;

            if (searchedNumber < array[mid])
            {
                end = mid - 1;
            }
            else if (searchedNumber > array[mid])
            {
                start = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;      //if the number is not in the array
    }

    //static int BinarySearchMethod(int[] array, int searchedNumber, int start, int end)        //this method must be uncommented too
    //{
    //    int mid = (start + end) / 2;

    //    if (start > end)
    //    {
    //        return -1;      //if the number is not in the array
    //    }
    //    else if (searchedNumber < array[mid])
    //    {
    //        end = mid - 1;
    //        mid = BinarySearchMethod(array, searchedNumber, start, end);
    //    }
    //    else if (searchedNumber > array[mid])
    //    {
    //        start = mid + 1;
    //        mid = BinarySearchMethod(array, searchedNumber, start, end);
    //    }

    //    return mid;
    //}
}