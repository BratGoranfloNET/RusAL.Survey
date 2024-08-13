using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;
using System.Text;

namespace RusAL.Survey.Services.Concrete
{
    public class FileSurveyService : IFileSurveyService
    {
        private  string _directory => "Анкеты";

        private string[] _points => new string[]
            {
                "1. ФИО:",
                "2. Дата рождения:",
                "3. Любимый язык программирования:",
                "4. Опыт программирования на указанном языке:",
                "5. Мобильный телефон:",
                "Анкета заполнена:"
            };

        public IEnumerable<SurveyItemDto> GetSurveys()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathLoc = Path.GetDirectoryName(location);
            var fullDir = Path.Combine(pathLoc, _directory);

            string[] files = Directory.GetFiles(fullDir);

            var dtoList = new List<SurveyItemDto>();

            

            foreach (string file in files)
            {                
                var survItem = new SurveyItemDto();

                using (StreamReader reader = new StreamReader(file))
                {
                    string? s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        if (s.StartsWith(_points[0]))
                           { survItem.FIO = s.Replace(_points[0], "").Trim(); }

                        if (s.StartsWith(_points[1]))
                           { survItem.BirthDate = s.Replace(_points[1],"").Trim(); }

                        if (s.StartsWith(_points[2]))
                           { survItem.Language = s.Replace(_points[2], "").Trim(); }

                        if (s.StartsWith(_points[3]))
                           { survItem.Experience = s.Replace(_points[3], "").Trim(); }

                        if (s.StartsWith(_points[4]))
                            { survItem.Phone = s.Replace(_points[4], "").Trim(); }

                        if (s.StartsWith(_points[5]))
                            { survItem.Created = s.Replace(_points[5], "").Trim(); }

                    }

                    dtoList.Add(survItem);
                } 
                
            }

            
            return dtoList;
        }

        public void WriteSurvayFile(SurveyItem survey)
        {
            try
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;               
                var pathLoc = Path.GetDirectoryName(location);
                var fullDir = Path.Combine(pathLoc, _directory);
               
                bool exists = Directory.Exists(Path.Combine(fullDir));               
                if (!exists)
                    Directory.CreateDirectory(Path.Combine(fullDir));
                  
                var fileName = $"{survey.FIO}.txt";
                var path = Path.Combine(fullDir, fileName);

                var sb = new StringBuilder();
                sb.AppendLine($"{_points[0]} {survey.FIO}");
                sb.AppendLine($"{_points[1]} {survey.BirthDate.ToShortDateString()}");
                sb.AppendLine($"{_points[2]} {survey.Language}");
                sb.AppendLine($"{_points[3]} {survey.Experience}");
                sb.AppendLine($"{_points[4]}  {survey.Phone}");
                sb.AppendLine($" ");
                sb.AppendLine($"{_points[5]} {DateTime.Now.ToShortDateString()}");

                var newString = sb.ToString();
               
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.WriteLine(newString);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }
    }
}
