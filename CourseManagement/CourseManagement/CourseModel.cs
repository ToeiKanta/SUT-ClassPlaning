using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    class CourseModel
    {
        public string NameID { get; set; }
        public string Name { get; set; }
        public string Credit { get; set; }
        public List<dates> Dates { get; set; }

        public class dates
        {
            public string Date { get; set; }
            public string Time { get; set; }
        }
    }
}
