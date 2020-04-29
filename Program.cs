using System;

namespace TicTacToeConsoleGame
{
    class Program
    {
        // A 2d array that shape the playground Fields
        static char[,] playgroundFields = new char[3, 3]
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        // to count turns 
        static int turns = 0;

        static void Main(string[] args)
        {
            Play();
        }

        /// <summary>
        /// This method draw a 2d array that contains the set of fields to shape the playground Fields 
        /// on the console
        /// </summary>
        public static void DrawFields()
        {
            Console.Clear();
            Console.WriteLine("     |     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}  |", playgroundFields[0, 0], playgroundFields[0, 1], playgroundFields[0, 2]);
            Console.WriteLine("_____|_____|_____|");

            Console.WriteLine("     |     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}  |", playgroundFields[1, 0], playgroundFields[1, 1], playgroundFields[1, 2]);
            Console.WriteLine("_____|_____|_____|");

            Console.WriteLine("     |     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}  |", playgroundFields[2, 0], playgroundFields[2, 1], playgroundFields[2, 2]);
            Console.WriteLine("_____|_____|_____|");
            turns++;
        }


        /// <summary>
        /// This method is responsible for the game rules and the play techniques
        /// </summary>
        public static void Play()
        {
            int player = 2;
            int input = 0;
            bool checkFields = true;

            do
            {
                // the first time the player count is = 2, so player one choose a field  
                if (player == 2)
                {
                    player = 1;
                    XorO('O', input);
                }
                // the second time the player count is = 1, so player two choose a field 
                else if (player == 1)
                {
                    player = 2;
                    XorO('X',input);
                }
                // re-draw the fields with the player choices 
                DrawFields();

                #region

                char[] playerChoices = { 'X', 'O' };
                // loop to check if one of the players won or if it's a draw
                foreach (char playerChoice in playerChoices)
                {
                    if ((playgroundFields[0, 0] == playerChoice) && (playgroundFields[0, 1] == playerChoice) && (playgroundFields[0, 2] == playerChoice)
                        || (playgroundFields[1, 0] == playerChoice) && (playgroundFields[1, 1] == playerChoice) && (playgroundFields[1, 2] == playerChoice)
                        || (playgroundFields[2, 0] == playerChoice) && (playgroundFields[2, 1] == playerChoice) && (playgroundFields[2, 2] == playerChoice)
                        || (playgroundFields[0, 0] == playerChoice) && (playgroundFields[1, 0] == playerChoice) && (playgroundFields[2, 0] == playerChoice)
                        || (playgroundFields[0, 1] == playerChoice) && (playgroundFields[1, 1] == playerChoice) && (playgroundFields[2, 1] == playerChoice)
                        || (playgroundFields[0, 2] == playerChoice) && (playgroundFields[1, 2] == playerChoice) && (playgroundFields[2, 2] == playerChoice)
                        || (playgroundFields[0, 0] == playerChoice) && (playgroundFields[1, 1] == playerChoice) && (playgroundFields[2, 2] == playerChoice)
                        || (playgroundFields[0, 2] == playerChoice) && (playgroundFields[1, 1] == playerChoice) && (playgroundFields[2, 0] == playerChoice))

                    {
                        if (playerChoice == 'X')
                        {
                            Console.WriteLine("\n :::::::::::: Player Number ONE Won :::::::::::::");
                        }
                        else
                        {
                            Console.WriteLine("\n :::::::::: Player Number TWO Won :::::::::");
                        }
                        Console.WriteLine("::::::::: Please Press Anykey TO Reset The Game ::::::::: ");
                        Console.ReadKey();
                        ResetPlaygroundFields();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine(":::::: Draw ::::: No Winner ::::::");
                        Console.WriteLine("::::::::::: Please Press Anykey TO Reset The Game :::::::::::: ");
                        Console.ReadKey();
                        ResetPlaygroundFields();
                    }
                }
                #endregion
                #region
                // takes an input from the players and check if it's a vaild field or not 
                do
                {
                        Console.WriteLine("\nPlease Player number {0} Enter Your Field : ", player);
                        try
                        {
                            input = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Please Enter A Valid Number ... Thank You.");
                        }
                    if ((input == 1) && (playgroundFields[0, 0] == '1'))
                        checkFields = true;
                    else if ((input == 2) && (playgroundFields[0, 1] == '2'))
                        checkFields = true;
                    else if ((input == 3) && (playgroundFields[0, 2] == '3'))
                        checkFields = true;
                    else if ((input == 4) && (playgroundFields[1, 0] == '4'))
                        checkFields = true;
                    else if ((input == 5) && (playgroundFields[1, 1] == '5'))
                        checkFields = true;
                    else if ((input == 6) && (playgroundFields[1, 2] == '6'))
                        checkFields = true;
                    else if ((input == 7) && (playgroundFields[2, 0] == '7'))
                        checkFields = true;
                    else if ((input == 8) && (playgroundFields[2, 1] == '8'))
                        checkFields = true;
                    else if ((input == 9) && (playgroundFields[2, 2] == '9'))
                        checkFields = true;
                    else
                    {
                        Console.WriteLine(":::::::::: \nIncorrect Field Please Enter A Valid Field ::::::::::");
                        checkFields = false;
                    }

                } while (!checkFields);

                #endregion
            } while (true);
            
        }

        /// <summary>
        /// This method takes two parameters and check which field the player has choosen to replace it with 
        /// the player sign (X or O)
        /// </summary>
        /// <param name="playerSign"></param>
        /// <param name="input"></param>
        public static void XorO(char playerSign,int input)
        {
            switch (input)
            {
                case 1:
                    playgroundFields[0, 0] = playerSign;
                    break;
                case 2:
                    playgroundFields[0, 1] = playerSign;
                    break;
                case 3:
                    playgroundFields[0, 2] = playerSign;
                    break;
                case 4:
                    playgroundFields[1, 0] = playerSign;
                    break;
                case 5:
                    playgroundFields[1, 1] = playerSign;
                    break;
                case 6:
                    playgroundFields[1, 2] = playerSign;
                    break;
                case 7:
                    playgroundFields[2, 0] = playerSign;
                    break;
                case 8:
                    playgroundFields[2, 1] = playerSign;
                    break;
                case 9:
                    playgroundFields[2, 2] = playerSign;
                    break;
            }
        }

        /// <summary>
        /// This method reset the 2d array to it's first shape and re-draw the fields on the console
        /// </summary>
        public static void ResetPlaygroundFields()
        {
            char[,] playgroundFieldsAfterReset = new char[3, 3]
            {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
            };

            playgroundFields = playgroundFieldsAfterReset;
            DrawFields();
            turns = 0;
        }













    }
}
