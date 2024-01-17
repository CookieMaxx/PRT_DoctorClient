using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT_DoctorClient
{
    public static class SurveyManager
    {

        public static List<Survey> Surveys = new List<Survey>
        {
            new Survey("Mental Health Inventory-5", new List<string>
            {
                "Are you feeling very nervous?",
                "Were you so depressed that nothing could cheer you up?",
                "Did you feel calm and collected?",
                "Did you feel down and depressed?",
                "Did you feel happy?"
            }),
            new Survey("General Health Questionnaire", new List<string>
            {
                "Have you recently felt perfectly well and in good health?",
                "Have you recently found that you are ill more frequently?",
                "Have you recently been feeling unhappy and depressed?"
            }),
            new Survey("Patient Health Questionnaire-9", new List<string>
            {
                "Over the last two weeks, how often have you been bothered by little interest or pleasure in doing things?",
                "Over the last two weeks, how often have you been bothered by feeling down, depressed, or hopeless?",
                "Over the last two weeks, how often have you been bothered by trouble falling asleep, staying asleep, or sleeping too much?"
            }),
            new Survey("Anxiety and Depression Detector", new List<string>
            {
                "I feel nervous and anxious frequently.",
                "I often feel afraid without any specific reason.",
                "I feel restless and can't stay calm.",
            })

         };
    }
}
