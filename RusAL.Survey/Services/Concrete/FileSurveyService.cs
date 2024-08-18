using RusAL.Survey.Models;
using RusAL.Survey.Services.Abstract;
using System.IO.Compression;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RusAL.Survey.Services.Concrete
{
    public class FileSurveyService : IFileSurveyService
    {
        private string _location => System.Reflection.Assembly.GetExecutingAssembly().Location;
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
            var pathLoc = Path.GetDirectoryName(_location);
            var fullDir = Path.Combine(pathLoc, _directory);

            string[] files = Directory.GetFiles(fullDir);

            var dtoList = new List<SurveyItemDto>();
            
            foreach (string file in files)
            {
                var survItem = GetSurveyDtoFromFile(file);

                dtoList.Add(survItem);
            }
            
            return dtoList;
        }

        public void SaveSurveyFile(SurveyItem survey, out bool hasErrors)
        {
            hasErrors = false;

            try
            {                            
                var pathLoc = Path.GetDirectoryName(_location);
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
                hasErrors = true;
                var message = ex.Message;
                Console.WriteLine($"Произошла ошибка при записи файла {message}"); 
            }
        }

        public SurveyItemDto GetSurveyByFileName(string fileName)
        {
            var dto = new SurveyItemDto();

            try 
            {
                var pathLoc  = Path.GetDirectoryName(_location);
                var fullDir  = Path.Combine(pathLoc, _directory);
                var fullPath = Path.Combine(fullDir, fileName);

                dto = GetSurveyDtoFromFile(fullPath);

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.WriteLine($"Файл не найден {message}");
            }

            return dto;
        }

        private SurveyItemDto GetSurveyDtoFromFile(string file)
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
                    { survItem.BirthDate = s.Replace(_points[1], "").Trim(); }

                    if (s.StartsWith(_points[2]))
                    { survItem.Language = s.Replace(_points[2], "").Trim(); }

                    if (s.StartsWith(_points[3]))
                    { survItem.Experience = s.Replace(_points[3], "").Trim(); }

                    if (s.StartsWith(_points[4]))
                    { survItem.Phone = s.Replace(_points[4], "").Trim(); }

                    if (s.StartsWith(_points[5]))
                    { survItem.Created = s.Replace(_points[5], "").Trim(); }

                }
            }

            return survItem;
        }

        public void DeleteSurveyByFileName(string fileName, out bool hasErrors)
        {
            hasErrors = false;

            try
            {
                var pathLoc = Path.GetDirectoryName(_location);
                var fullDir = Path.Combine(pathLoc, _directory);
                var fullPath = Path.Combine(fullDir, fileName);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                else 
                {
                    hasErrors = true;
                    Console.WriteLine($"Файл не найден  {fullPath}");
                }

            }
            catch (Exception ex)
            {
                hasErrors = true;
                var message = ex.Message;
                Console.WriteLine($"Ошибка при удалении файла  {message}");
            }
        }

        public string[] GetFileList()
        {
            var pathLoc = Path.GetDirectoryName(_location);
            var fullDir = Path.Combine(pathLoc, _directory);

            string[] files = Directory.GetFiles(fullDir);

            int i = 0;
            foreach (var file in files)
            {
                files[i] = file.Replace(fullDir, "").Replace("\\", "");
                i++;               
            }

            return files;
        }

        public string[] GetFileListToday()
        {
            var pathLoc = Path.GetDirectoryName(_location);
            var fullDir = Path.Combine(pathLoc, _directory);

            string[] files = Directory.GetFiles(fullDir);

            var fileList = new List<string>();
            foreach (var file in files)
            {
                DateTime fileCreatedDate = File.GetCreationTime(file);
                
                if (fileCreatedDate.Date == DateTime.Now.Date)
                {
                    fileList.Add(file.Replace(fullDir, "").Replace("\\", ""));
                }
            }

            return fileList.ToArray();

        }

        public void ZipSurvey(string sourceFileName, string targetPath, out bool hasErrors)
        {
            hasErrors = false;

            try
            {
                var pathLoc = Path.GetDirectoryName(_location);
                var fullDir = Path.Combine(pathLoc, _directory);
                var fullPath = Path.Combine(fullDir, sourceFileName);

                bool exists = Directory.Exists(Path.Combine(targetPath));
                if (!exists)
                    Directory.CreateDirectory(Path.Combine(targetPath));

                var zipfileName = sourceFileName.Replace(".txt", ".zip");
                var zipPath = Path.Combine(targetPath, zipfileName);
                
                using FileStream sourceStream = new FileStream(fullPath, FileMode.OpenOrCreate);
                using FileStream targetStream = File.Create(zipPath);
                using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
                sourceStream.CopyTo(compressionStream); 

            }
            catch (Exception ex)
            {
                hasErrors = true;
                Console.WriteLine($"Ошибка при архивировании файла {ex.Message}");
            }
        }
    }
}
