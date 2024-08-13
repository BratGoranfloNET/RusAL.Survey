using RusAL.Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusAL.Survey.SurveyStrategy
{
    public class InputContext
    {
        IInputStrategy strategy;

        public InputContext(IInputStrategy strategy)
        {
            this.strategy = strategy;
        }

        public bool Input(int i, string question, SurveyItem survey)
        {
           return  strategy.InputAlgorithmInterface(i,  question,  survey);
        }
    }
}
