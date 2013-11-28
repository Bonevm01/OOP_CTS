using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 

public class Person
{
    public string Name { get; set; }
    public byte? Age { get; set; }

    public Person()
        : this(null)
    {
    }

    public Person(string name)
        : this(name, null)
    {
    }

    public Person(string name, byte? age)
    {
        this.Name = name;
        this.Age = age;
    }

    // Override ToString() to display the information of a person and if age is not specified – to say so. 

    public override string ToString()
    {
        return string.Format("Name: {0}; Age: {1}.", this.Name ?? "<unnamed>", this.Age != null ? this.Age.ToString() : "Not specified");
    }

}
