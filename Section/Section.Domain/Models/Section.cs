using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Domain.Models;

public class Section
{
    private Section(string name, string description, bool isSport, DayOfWeek day, TimeOnly time, int limitOfPlaces, Guid teacherId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsSport = isSport;
        Day = day;
        Time = time;
        LimitOfPlaces = limitOfPlaces;
        CreateDate = DateTime.UtcNow;
        TeacherId = teacherId;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsSport { get; private set; }
    public DayOfWeek Day { get; private set; }
    public TimeOnly Time { get; private set; }
    //public List<Student> Students { get; private set; }
    public Guid TeacherId { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime? ModifiedDate { get; private set; }
    public int RegisteredStudents { get; private set; }
    public int LimitOfPlaces { get; private set; }


    //public void RegisterToSection(Student student)
    //{
    //    if (CheckLimit() && CheckIfStudentIsAlreadyRegistred(student))
    //    {
    //        Students.Add(student);
    //    }
    //}

    //public bool UnregisterToSection(Student student)
    //{
    //    if (Students.Remove(student))
    //        return true;
    //    return false;
    //    //add log that this student is not registred to this section
    //}

    public static Section CreateSection(string name, string description, bool isSport, DayOfWeek day, TimeOnly time, int limitOfPlaces, Guid teacherId)
    {
        return new Section(name, description, isSport, day, time, limitOfPlaces, teacherId);
    }

    //private bool CheckIfStudentIsAlreadyRegistred(Student student)
    //{
    //    if (Students.Contains(student))
    //        return false;
    //    return true;
    //}

    //private bool CheckLimit()
    //{
    //    if (Students.Count >= LimitOfPlaces)
    //        return false;
    //    return true;
    //}

    public void UpdateSection(string? name, string? description, DayOfWeek? day, TimeOnly? time, int? limitOfPlaces,Guid? teacherId)
    {
        
        Name = name ?? Name;
        Description = description ?? Description;
        Day = day ?? Day;
        Time = time ?? Time;
        LimitOfPlaces = limitOfPlaces ?? LimitOfPlaces;
        TeacherId = teacherId ?? TeacherId;
        ModifiedDate = DateTime.UtcNow;
    }


    //change properties to independent classes
    //public void SetName<T>(T? value)
    //{
    //    if(value is not null)
    //    {
    //        Name = value;
    //    }
    //}
}
