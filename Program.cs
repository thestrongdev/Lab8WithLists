using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8Goodson_Lists
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                GetUserRequest();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void GetUserRequest()
        {

            List<string> classmates = new List<string>(){
                "SAM", "IVAN", "THERESA", "MIKE", "VERKEIA", "CIARRA",
                 "JASON", "BLAKE", "ADRYENNE", "DARSHAN", "DYLAN", "DANNY"};

            bool keepGoing = true;
            Console.WriteLine("Which student would you like to learn more about? Enter a number between 0 and 11 OR their name: ");

            do
            {
                string student = Console.ReadLine();
                student = student.ToUpper();

                bool realInteger = int.TryParse(student, out int studentID);

                if (studentID < 0 || studentID > 11 || !realInteger)
                {
                    if (CheckIfNameStudent(student, classmates))
                    {
                        classmates.IndexOf(student);

                        keepGoing = GetFact(classmates.IndexOf(student), classmates);
                    }

                    Console.WriteLine("\nEither that student doesn't exist or you didn't enter a whole number./nPlease try again and enter their name OR a number between 0 and 11: ");
                    continue;
                }
                else
                {
                    keepGoing = GetFact(studentID, classmates);
                }

            } while (keepGoing);

        }

        static bool GetFact(int studentID, List<string> classmates)
        {
            Console.WriteLine("Would you like their age, a random fact, or hometown? Please enter 'age' or 'random' or 'hometown': ");
            string userChoice = Console.ReadLine();
            GetStudentInfo(studentID, userChoice, GetStudentName(classmates, studentID));

            return GetAnother();

        }

        static string GetStudentName(List<string> classmates, int studentID)
        {
            return classmates[studentID];
        }

        static bool CheckIfNameStudent(string student, List<string> classmates)
        {
            return classmates.Contains(student);
        }

        static void GetStudentInfo(int studentID, string fact, string name) //really wanted to try out generics here for allowing entry of name or ID. couldn't figure it out though.
        {

            List<string> randomFacts = new List<string>(){
                                        "didn't want more than one kid",
                                        "studied c++ in school",
                                        "is friends with Mike and Jason",
                                        "is a product owner and roommates with Jason",
                                        "works at Quicken Loans",
                                        "likes photography",
                                        "is friends with Mike and Theresa",
                                        "first coded in 8th grade",
                                        "is an accountant",
                                        "worked in my first group for a coding exercise",
                                        "has roommates who are developers",
                                        "runs ultra marathons"};

            List<int> studentAges = new List<int>() {91, 85, 78, 94, 88, 66,
                                       75, 99, 102, 73, 80, 89 };



            List<string> hometowns = new List<string>() {"Candyland", "Hogwarts", "Bikini Bottom",
                                  "Ba Sing Se", "Transylvannia", "Schitt's Creek",
                                  "The Krusty Krab", "The Chum Bucket", "Azkaban",
                                  "The Abyss", "Antartica", "Hogwarts" };

            string studentHometown = hometowns[studentID];
            string studentInfo = randomFacts[studentID];
            int studentAge = studentAges[studentID];

            if (fact.Equals("age", StringComparison.OrdinalIgnoreCase))
            {

                Console.WriteLine($"\nStudent {studentID} is {name}. This student is {studentAge} years old!");

            }
            else if (fact.Equals("random", StringComparison.OrdinalIgnoreCase))
            {

                Console.WriteLine($"\nStudent {studentID} is {name}. This student {studentInfo}.");

            }
            else if (fact.Equals("hometown", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nStudent {studentID} is {name}. This student is from {studentHometown}.");
            }
            else
            {
                Console.WriteLine("Not an option");
            }
        }

        static bool GetAnother()
        {
            Console.WriteLine("\nLook up another student? (enter y/n)");

            do
            {

                string userInput = Console.ReadLine();

                if (userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nWhich student would you like to learn more about? Enter a number 0 and 11 OR their name: ");
                    return true;
                }
                else if (userInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }

            } while (true);
        }
    }
}
