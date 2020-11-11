using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Program
    {
        // the playField
        static char[,] playField =
        {
            { '1','2','3' },    //row 0
            { '4','5','6' },   //row 1
            { '7','8','9' }   //row 2
        };

        static int turns = 0;
        static void Main(string[] args)
        {
            int player = 2;  //Player 1 starts
            int input = 0;
            bool inputCorrect = true;
           
            //runs code as long as the program runs
            do
            {               
                if (player==2)
                {
                    player = 1;
                    EnterXOrO('O',input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXOrO('X', input);
                }
                SetField();

                #region Check winning condition
                char [] playerChars = { 'X', 'O' };
                foreach (char playerChar in playerChars)
                {
                    if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                        )                        
                    {
                        if (playerChar=='O')
                        {
                            Console.WriteLine("\nPlayer 1 has won the game!!!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 2 has won the game!!!");
                        }
                        Console.WriteLine("Please press any key to reset the game");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nDRAW!!");
                        Console.WriteLine("Please press any key to reset the game");
                        Console.ReadKey();
                        ResetField();
                    }
                }
                #endregion
                #region Check If field is already taken
                do
                {
                    Console.Write("\nPlayer {0} :Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a number!!!");
                    }

                    if (input == 1 && playField[0, 0] == '1')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 2 && playField[0, 1] == '2')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 3 && playField[0, 2] == '3')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 4 && playField[1, 0] == '4')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 5 && playField[1, 1] == '5')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 6 && playField[1, 2] == '6')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 7 && playField[2, 0] == '7')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 8 && playField[2, 1] == '8')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 9 && playField[2, 2] == '9')
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect input. Please use another field!");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);
                #endregion

            } while (true);

            //Console.ReadKey();
        }
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0,0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");       
            turns++;

        }
        public static void ResetField()
        {
            // the playFieldInitial for reset field
            char[,] playFieldInitial =
            {
                { '1','2','3' },    //row 0
                { '4','5','6' },   //row 1
                { '7','8','9' }   //row 2
            };
            playField = playFieldInitial;
            SetField();
            turns = 0;
        }
        public static void EnterXOrO(char playerSign, int input)
        {
            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }            
        }
    }
}
