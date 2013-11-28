using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StudentTest 
{
    static void Main()
    {
        Student st1 = new Student("Dimitar", "Ivanov", "Georgiev", 123546434, "Stud grad bl 42", "+359 888 235214", "gosho@mymail.bg", 2,
            University.UNSS, Faculty.Stopanski, Specialty.Marketing);
        Student st2 = new Student();

        // Test Student.equals
        Console.WriteLine(st1.Equals(st2));

        // Test Student operator == !=
        if (st1!=st2)
        {
            Console.WriteLine("Studen1 is different than Student2");
        }

        // Test Student.GetHashCode()
        Console.WriteLine("HashCode of Student1 is {0}", st1.GetHashCode());
        Console.WriteLine();
        Console.WriteLine(st1);

        // Test student.Clone()
        st2 = st1.Clone();

        // Test Student operator == !=
        if (st1==st2)
        {
            Console.WriteLine("Now the both students are equal");
        }

        // Test if the clone methods performs deep clonning
        st2.Facult = Faculty.Informatika;
        st2.FirstName = "Nedjalko";
        st2.Course = 4;
        st2.SSN = 65467616;
        Console.WriteLine();
        Console.WriteLine("Student 1: {0}", st1);
        Console.WriteLine();
        Console.WriteLine("Student 2: {0}", st2);


        Student st3 = st2.Clone();
        st3.MiddleName = "Yankov";
        st3.SSN = 54674751;

        Student st4 = st3.Clone();
        st4.SSN = 24674751;

        Student[] myArray = { st4, st2, st1, st3};

        // Test Student.CopmareTo method
        Array.Sort(myArray);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Sorted students are:");
        foreach (Student item in myArray)
        {
            Console.WriteLine();
            Console.WriteLine(item);
        }
    }
}
