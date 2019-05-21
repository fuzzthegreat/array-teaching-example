using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTeachingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Contains all prompts to the user - setup before the application gets into the run loop
            var promptArray = new string[5]; 

            // Contains the valid answer to each question
            var validResponseArray = new char[5];

            // Contains validity of the users' input
            var checkedResponses = new bool[5];

            // SET UP ALL POSSIBLE RESPONSE CHARACTERS            
            var possibleResponses = new char[4];
            possibleResponses[0] = 'A';
            possibleResponses[1] = 'B';
            possibleResponses[2] = 'C';
            possibleResponses[3] = 'D';

            // SET UP PROMPTS & ANSWERS
            promptArray[0] = "This is a prompt, the correct answer is A";
            validResponseArray[0] = 'A';
            promptArray[1] = "This is a prompt, the correct answer is B";
            validResponseArray[1] = 'B';
            promptArray[2] = "This is a prompt, the correct answer is C";
            validResponseArray[2] = 'C';
            promptArray[3] = "This is a prompt, the correct answer is D";
            validResponseArray[3] = 'D';
            promptArray[4] = "This is a prompt, the correct answer is A";
            validResponseArray[4] = 'A';


            // LOOP OVER ALL OF THE PROMPTS
            for (int i = 0; i < promptArray.Length; i++)
            {

                Console.WriteLine(promptArray[i]);

                // READ FIRST CHARACTER FROM THE INPUT
                var input = Console.ReadKey();
                Console.WriteLine();
                //  TURN INPUT INTO A STRING, UPPERCASE AND STORE IT
                char response = input.KeyChar.ToString().ToUpper().First(); // we know it's only 1 character long so hard-coding the first position of the string position is ok
                Console.WriteLine($"we got {response}");
                // VALIDATE THAT THE USER PROVIDED AN ACTUAL RESPONSE
                while (!possibleResponses.Contains(response))
                {
                    Console.WriteLine(
                        $"{response} is an invalid entry, please try again.  Valid entries are \"A, B, C, or D\"");

                    // READ FIRST CHARACTER FROM THE INPUT
                    input = Console.ReadKey();
                    Console.WriteLine();
                    //  TURN INPUT INTO A STRING, UPPERCASE AND STORE IT
                    response = input.KeyChar.ToString().ToUpper().First();

                }

                // AT THIS POINT WE HAVE A VALID ENTRY - LETS STORE THE VALIDITY
                // THE RIGHT SIDE HERE WILL RESOLVE TO A TRUE OR FALSE THEN STORE INTO CHECKEDRESPONSES                
                checkedResponses[i] = (response == validResponseArray[i]);
            }


            // AT THIS POINT, checkedResponses will contain either true or false for every question - lets re-ask the false ones.
            // BASICALLY A COPY PASTA FROM ABOVE EXCEPT FOR THE CORRECT CHECK
            // LOOP OVER ALL OF THE PROMPTS
            for (int i = 0; i < promptArray.Length; i++)
            {
                // IF WE HAVE THE CORRECT ANSWER, THIS TRIGGERS
                if (checkedResponses[i] == true)
                {
                    // GO TO THE NEXT QUESTION - DISREGARD INPUT
                    continue;
                }

                Console.WriteLine("You got this question incorrect, re-asking.");
                Console.WriteLine(promptArray[i]);

                // READ FIRST CHARACTER FROM THE INPUT
                var input = Console.ReadKey();
                Console.WriteLine();
                //  TURN INPUT INTO A STRING, UPPERCASE AND STORE IT
                char response = input.KeyChar.ToString().ToUpper().First(); // we know it's only 1 character long so hard-coding the first position of the string position is ok

                // VALIDATE THAT THE USER PROVIDED AN ACTUAL RESPONSE
                while (!possibleResponses.Contains(response))
                {
                    Console.WriteLine(
                        $"{response} is an invalid entry, please try again.  Valid entries are \"A, B, C, or D\"");

                    // READ FIRST CHARACTER FROM THE INPUT
                    input = Console.ReadKey();
                    Console.WriteLine();
                    //  TURN INPUT INTO A STRING, UPPERCASE AND STORE IT
                    response = input.KeyChar.ToString().ToUpper().First();

                }

                // AT THIS POINT WE HAVE A VALID ENTRY - LETS STORE THE VALIDITY
                // THE RIGHT SIDE HERE WILL RESOLVE TO A TRUE OR FALSE THEN STORE INTO CHECKEDRESPONSES                
                checkedResponses[i] = (response == validResponseArray[i]);
            }

            int score = 0;
            for (int j = 0; j < checkedResponses.Length; j++)
            {
                if (checkedResponses[j] == true)
                {
                    score += 1;
                }
            }

            // Need to cast the score to double to get the precision correct for percentage
            Console.WriteLine(
                $"Your score was {score}/{checkedResponses.Length} OR {(double)score / checkedResponses.Length:P2}");
            Console.WriteLine("This is the end of the quiz!");
            Console.ReadLine();
        }
    }
}
