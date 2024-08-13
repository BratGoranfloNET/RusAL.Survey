namespace RusAL.Survey.Models
{
    public  class SurveyItem
    {
        public string FIO { get; set; }
        public DateTime BirthDate { get; set; }
        public string Language { get; set; }
        public int Experience { get; set; }
        public string Phone { get; set; }

        public int CurrQuestion { get; set; }
        public int NextQuestion { get; set; }

        public DateTime Created { get; set; }
    }
}
