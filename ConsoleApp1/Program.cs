using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeGenerator
{
    class Program
    {
        static string[] categoryOptions = new string[50];
        static int userStep = 0;
        static string[] userAnswers = new string[5] { "", "", "", "", "" };
        static readonly string[] userQuestions = new string[5] { "Press c to get categories\nPress r to get random jokes",
                                                        "Want to use a random name? y/n",
                                                        "Want to specify a category? y/n",
                                                        "Enter a category.",
                                                        "How many jokes do you want? (1-9)" };
        
        private static void Main()
        {
            ApiHelper.InitializeApiClient();
            categoryOptions = CategoryCall.GetCategories();

            Console.WriteLine("Press x to quit at any question.");

            while (userAnswers[userStep].ToString().ToLower() != "x")
            {
                Console.WriteLine(userQuestions[userStep]);
                userAnswers[userStep] = Console.ReadLine();

                if (userAnswers[userStep].ToString().ToLower() == "x")
                    break;

                if (UserInputValidate.ValidateUserInput(userAnswers[userStep], userStep, categoryOptions))
                    userStep = UserInputProcessor.ProcessUserInput(userAnswers, userStep, categoryOptions);

                Console.WriteLine();
            }   
        }
    }
}
