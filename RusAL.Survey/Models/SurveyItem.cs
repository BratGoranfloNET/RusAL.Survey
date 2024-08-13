namespace RusAL.Survey.Models
{
    public  class SurveyItem
    { 
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        ///Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        ///Любимый язык программирования
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///Опыт
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        ///Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///Номер следующего вопроса
        /// </summary>
        public int NextQuestion { get; set; }

        /// <summary>
        ///Дата создания анекеты
        /// </summary>
        public DateTime Created { get; set; }

        public bool InnerCommand { get; set; }
    }
}
