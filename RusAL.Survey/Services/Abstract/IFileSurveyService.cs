using RusAL.Survey.Models;

namespace RusAL.Survey.Services.Abstract
{
    public  interface IFileSurveyService
    {
         public void SaveSurveyFile(SurveyItem survey, out bool hasErrors);

         public IEnumerable<SurveyItemDto> GetSurveys();

         public SurveyItemDto GetSurveyByFileName(string fileName);

         public void DeleteSurveyByFileName(string fileName, out bool hasErrors);

         public string[] GetFileList(out bool hasErrors);

         public string[] GetFileListToday(out bool hasErrors);

         public void ZipSurvey(string sourceFileName, string targetPath, out bool hasErrors);

    }
}
