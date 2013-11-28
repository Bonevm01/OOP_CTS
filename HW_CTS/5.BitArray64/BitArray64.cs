using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitArray64 : IEnumerable<int>
{
    public ulong InputNumber { get; set; }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("The index must be between 0 and 63");
            }

            else
            {
                return (int)((this.InputNumber & (ulong)1 << index) >> index);
            }

        }
        set
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("The index must be between 0 and 63");
            }

            if (value != 0 && value != 1)
            {
                throw new ArgumentOutOfRangeException("Bits value could be only 0 or 1");
            }

            if (value == 1)
            {
                this.InputNumber = this.InputNumber | ((ulong)1 << index);
            }
            else
            {
                this.InputNumber = this.InputNumber & ~((ulong)1 << index);
            }

        }

    }

    public BitArray64(ulong input)
    {
        this.InputNumber = input;
    }




    public IEnumerator<int> GetEnumerator()
    {
        int possition = 0;
        while (possition < 64)
        {
            yield return this[possition];
            possition++;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder myText = new StringBuilder();
        myText.Append("Position:");
        for (int i = 0; i < 64; i++)
        {
            myText.Append(string.Format("{0, 3}", i));

        }
        myText.Append("\n");
        string output = myText.ToString();
        myText.Clear();
        myText.Append("Bits:    ");
        for (int i = 0; i < 64; i++)
        {
            myText.Append(string.Format("{0, 3}", this[i]));
        }
        myText.Append("\n");
        output += myText.ToString();
        return output;
    }

    public override bool Equals(object obj)
    {
        BitArray64 myArr = obj as BitArray64;

        if (myArr == null)
        {
            return false;
        }

        return (this.InputNumber == myArr.InputNumber);

    }

    public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
    {
        return BitArray.Equals(arr1, arr2);
    }

    public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
    {
        return !BitArray.Equals(arr1, arr2);
    }

    public override int GetHashCode()
    {
        return this.InputNumber.GetHashCode() ^ 2013; //my code
    }
}
