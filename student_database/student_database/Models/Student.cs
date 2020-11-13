using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace student_database.Models
{
    public class Student
    {
        public string student_id { get; set; }
        public string nama { get; set; }
        public int umur { get; set; }
        public string alamat { get; set; }
        public string telepon { get; set; }

    }
}