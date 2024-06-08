using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Domain.Models;

public class Section
{
    private Section(string name, string description, bool isSport, DayOfWeek day, TimeOnly time, int limitOfPlaces)
    {
        Name = name;
        Description = description;
        IsSport = isSport;
        Day = day;
        Time = time;
        LimitOfPlaces = limitOfPlaces;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }
    public bool IsSport { get; private set; }
    public DayOfWeek Day { get; private set; }
    public TimeOnly Time { get; private set; }
    public List<Student> Students { get; private set; }
    public int LimitOfPlaces { get; private set; }


    public void RegisterToSection(Student student)
    {
        if (CheckLimit() && CheckIfStudentIsAlreadyRegistred(student))
        {
            Students.Add(student);
        }
    }

    public bool UnregisterToSection(Student student)
    {
        if (Students.Remove(student))
            return true;
        return false;
        //add log that this student is not registred to this section
    }

    public static Section CreateSection(string name, string description, bool isSport, DayOfWeek day, TimeOnly time, int limitOfPlaces)
    {
        return new Section(name, description, isSport, day, time, limitOfPlaces);
    }

    private bool CheckIfStudentIsAlreadyRegistred(Student student)
    {
        if (Students.Contains(student))
            return false;
        return true;
    }

    private bool CheckLimit()
    {
        if (Students.Count >= LimitOfPlaces)
            return false;
        return true;
    }
}
