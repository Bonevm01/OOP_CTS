using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tests
{
    static void Main()
    {
        BitArray64 arr1 = new BitArray64(31);

        // Test Ienumerable<int> - must work with foreach
        int position = 0;
        foreach (var bit in arr1)
        {
            Console.WriteLine("Position {0}, Value -> {1}",position, bit);
            position++;
        }

        // Test set of a new bit value on specific position and Test ToString()
        Console.WriteLine(arr1);
        arr1[10] = 1;
        Console.WriteLine(arr1);

        arr1[10] = 0;
        Console.WriteLine(arr1);

        BitArray64 arr2 = new BitArray64(256);

        //Test == != equals
        Console.WriteLine(arr1==arr2); //false

        arr2.InputNumber = 31;
        Console.WriteLine(arr1 == arr2); //true

        // Test GetHashCode()
        Console.WriteLine(arr2.GetHashCode());

    }
}
