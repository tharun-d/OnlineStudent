using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class History
    {
        public string SubjectName { get; set; }
        public double Percantage { get; set; }
        public DateTime Examdate { get; set; }
        public string StatusOfExam { get; set; }
    }
}
