﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAC.Models
{
    public class Participant
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}