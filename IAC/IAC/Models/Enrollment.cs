using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAC.Models
{
        public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int ParticipantID { get; set; }

            public virtual Course Course { get; set; }
            public virtual Participant Student { get; set; }
        }
 }
