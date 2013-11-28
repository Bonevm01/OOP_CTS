using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PersonTest
{
    static void Main()
    {
        // Test Person.ToString() - if age and name are not specified – to say so
        Person p1 = new Person();
        Console.WriteLine(p1);

        p1.Name = "Stojan";
        Console.WriteLine(p1);

        p1.Age = 34;
        Console.WriteLine(p1);
    }
}