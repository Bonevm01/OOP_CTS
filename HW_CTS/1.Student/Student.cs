using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define a class Student, which contains data about a student – first, middle and last name, 
// SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. 
// Use an enumeration for the specialties, universities and faculties. 
// Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() 
// and operators == and !=.

//Add implementations of the ICloneable interface. The Clone() method should deeply copy 
// all object's fields into a new object of type Student.

//Implement the  IComparable<Student> interface to compare students by names 
// (as first criteria, in lexicographic order) and by social security number 
// (as second criteria, in increasing order).

public class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public uint? SSN { get; set; }
    public string PermanentAddress { get; set; }
    public string MobilePhoneNumber { get; set; }
    public string Email { get; set; }
    public byte? Course { get; set; }

    public University Univ { get; set; }
    public Faculty Facult { get; set; }
    public Specialty Spec { get; set; }

    public Student()
        : this(null, null, null, null, null, null, null, null, University.NotSpecified, Faculty.NotSpecified, Specialty.NotSpecified)
    {
    }

    public Student(string fName, string mName, string lName, uint? socialNumber, string address, string phone, string mail,
        byte? course, University un, Faculty f, Specialty sp)
    {
        this.FirstName = fName;
        this.MiddleName = mName;
        this.LastName = lName;
        this.SSN = socialNumber;
        this.PermanentAddress = address;
        this.MobilePhoneNumber = phone;
        this.Email = mail;
        this.Course = course;
        this.Univ = un;
        this.Facult = f;
        this.Spec = sp;

    }

    public override bool Equals(object obj)
    {
        Student test = obj as Student;

        if (test == null)
        {
            return false;
        }

        if (!Object.Equals(this.SSN, test.SSN)) // SSN must be unique for each Student/Person and it is enough to compare only this field
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return string.Format("Name: {0} {1} {2}; Social number: {3};\nAddress: {4}\nPhone: {5}; E-mail: {6};\nUniversity: {7}; Faculty: {8}, Specialty: {9}, Course: {10}",
            this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress, this.MobilePhoneNumber, this.Email, this.Univ, this.Facult, this.Spec, this.Course);
    }

    public override int GetHashCode()
    {
        return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
    }

    public static bool operator ==(Student st1, Student st2)
    {
        return Student.Equals(st1, st2);
    }

    public static bool operator !=(Student st1, Student st2)
    {
        return !Student.Equals(st1, st2);
    }

    public Student Clone()
    {
        Student original = this;
        Student result = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress,
            this.MobilePhoneNumber, this.Email, this.Course, this.Univ, this.Facult, this.Spec);

        return result;
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }



    public int CompareTo(Student other)
    {
        if (this.FirstName!=other.FirstName)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }

        if (this.MiddleName!=other.MiddleName)
        {
            return this.MiddleName.CompareTo(other.MiddleName);
        }

        if (this.LastName!= other.LastName)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        if (this.SSN!=other.SSN)
        {
            if (this.SSN<other.SSN)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        return 0;
    }
}
