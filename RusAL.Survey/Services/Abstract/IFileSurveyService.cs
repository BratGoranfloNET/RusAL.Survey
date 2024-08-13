using RusAL.Survey.Models;

namespace RusAL.Survey.Services.Abstract
{
    public  interface IFileSurveyService
    {
         public void WriteSurvayFile(SurveyItem survey);

         public IEnumerable<SurveyItemDto> GetSurveys();
    }
}
