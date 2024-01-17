using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT_DoctorClient
{
    public class Survey
    {
        public string Name { get; set; }
        public List<string> Questions { get; set; }
        public List<int> Responses { get; set; } // Assuming responses are numeric

        public Survey(string name, List<string> questions)
        {
            Name = name;
            Questions = questions;
        }
    }


}
