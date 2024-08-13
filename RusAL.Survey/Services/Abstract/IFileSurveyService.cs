using RusAL.Survey.Models;

namespace RusAL.Survey.Services.Abstract
{
    public  interface IFileSurveyService
    {
         public void SaveSurvayFile(SurveyItem survey, out bool hasErrors);

         public IEnumerable<SurveyItemDto> GetSurveys();

         public SurveyItemDto GetSurveyByFileName(string fileName);

         public void DeleteSurveyByFileName(string fileName, out bool hasErrors);
    }
}
