using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class UserInputProcessor
    {
        public static int ProcessUserInput(string[] userAnswers, int userStep, string[] categoryOptions)
        {
            string randomName = "";

            if (userAnswers[0].ToLower() == "c")
                DisplayCategories(categoryOptions);

            if (userStep == 4)
            {
                if (userAnswers[1].ToLower() == "y")
                    randomName = GenerateRandomName();

                DisplayJokesToUser(userAnswers[3].ToString(), randomName, Int32.Parse(userAnswers[4]), 0);
            }                

            return ControlUserStep(userAnswers, userStep);
        }

        private static void DisplayCategories(string[] categoryOptions)
        {
            for (int i = 0; i < categoryOptions.Length; i++)
            {
                Console.WriteLine(categoryOptions[i]);
            }
        }

        public static int ControlUserStep(string[] userAnswers, int userStep)
        {
            if (userAnswers[0].ToLower() == "c")
                userStep--;            

            if (userAnswers[2].ToLower() == "n" && userStep == 2)
                userStep++;

            userStep++;

            if (userStep == 5)
                userStep = 0;

            return userStep;
        }

        public static string GenerateRandomName()
        {
            dynamic holdValue = RandomNameCall.GetRandomName();
            return holdValue.name + " " + holdValue.surname;
        }

        public static void DisplayJokesToUser(string selectedCategory, string randomName, int selectedNumberOfJokes, int jokesDisplayedToUser)
        {
            string[] generatedJoke = RandomJokeCall.GetRandomJoke(selectedCategory);

            if (!String.IsNullOrEmpty(randomName))
                generatedJoke[0] = generatedJoke[0].Replace("Chuck Norris", randomName);

            Console.WriteLine(generatedJoke[0]);
            jokesDisplayedToUser++;

            if (selectedNumberOfJokes != jokesDisplayedToUser)
                DisplayJokesToUser(selectedCategory, randomName, selectedNumberOfJokes, jokesDisplayedToUser);
        }
    }
}
