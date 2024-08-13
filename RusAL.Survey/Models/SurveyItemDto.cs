using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusAL.Survey.Models
{
    public class SurveyItemDto
    {
        public string FIO { get; set; }
        public string BirthDate { get; set; }
        public string Language { get; set; }
        public string Experience { get; set; }
        public string Phone { get; set; }

        public string Created { get; set; }
    }
}
