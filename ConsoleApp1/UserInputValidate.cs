using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class UserInputValidate
    {
        public static bool ValidateUserInput(string userAnswer, int userStep, string[] categoryOptions)
        {
            return userStep switch
            {
                0 => ValidateTwoOptionQuestion(userAnswer, userStep),
                1 => ValidateTwoOptionQuestion(userAnswer, userStep),
                2 => ValidateTwoOptionQuestion(userAnswer, userStep),
                3 => ValidateSelectedCategoryExists(userAnswer, categoryOptions),
                4 => ValidateSelectedNumberIsCorrect(userAnswer),
                _ => FailedValidation()
            };
        }

        public static bool ValidateTwoOptionQuestion(string userAnswer, int userStep)
        {
            if (userStep == 0 && (userAnswer.ToLower() == "c" || userAnswer.ToLower() == "r"))
                return true;

            if (userStep != 0 && (userAnswer.ToLower() == "y" || userAnswer.ToLower() == "n"))
                return true;

            return FailedValidation();
        }

        public static bool ValidateSelectedCategoryExists(string userAnswer, string[] categoryOptions)
        {
            for (int i = 0; i < categoryOptions.Length; i++)
            {
                if (userAnswer.ToLower() == categoryOptions[i])
                    return true;
            }
            return FailedValidation();
        }

        public static bool ValidateSelectedNumberIsCorrect(string userAnswer)
        {
            if (Int32.TryParse(userAnswer, out int parsedNumber))
                if(parsedNumber > 0 && parsedNumber < 10)
                    return true;

            return FailedValidation();
        }

        public static bool FailedValidation()
        {
            Console.WriteLine("Incorrect input, please try again.");
            return false;
        }
    }
}
