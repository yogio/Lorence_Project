using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IAC.Models;
using IAC.DAL;

namespace IAC.DAL
{
    public class IACitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<IACDbContext>
    {
        protected override void Seed(IACDbContext context)
        {
            var students = new List<Participant>
            {
            new Participant{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Participant{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Participant{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Participant{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Participant{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Participant{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Participant{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Participant{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{EnrollmentID=1,CourseID=1050},
            new Enrollment{EnrollmentID=1,CourseID=4022},
            new Enrollment{EnrollmentID=1,CourseID=4041},
            new Enrollment{EnrollmentID=2,CourseID=1045},
            new Enrollment{EnrollmentID=2,CourseID=3141},
            new Enrollment{EnrollmentID=2,CourseID=2021},
            new Enrollment{EnrollmentID=3,CourseID=1050},
            new Enrollment{EnrollmentID=4,CourseID=1050},
            new Enrollment{EnrollmentID=4,CourseID=4022},
            new Enrollment{EnrollmentID=5,CourseID=4041},
            new Enrollment{EnrollmentID=6,CourseID=1045},
            new Enrollment{EnrollmentID=7,CourseID=3141},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}