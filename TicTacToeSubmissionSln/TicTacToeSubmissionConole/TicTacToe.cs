using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[] _positions = new int[9] { -1, -1, -1, -1, -1, -1,-1,-1, -1 };
        
        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }

        private bool IsMoveValid(int row, int column)
        {
            int playPosition = (row * 3) + column;

            if (_positions[playPosition] == -1)
                return true;

            return false;
        }

        private bool IsTied()
        {
            int blankSpaces = 0;
           
            for(int index=0; index < _positions.Length; index++)
            {
                if (_positions[index] == -1)
                {
                    blankSpaces++; 
                }
            }

            if (blankSpaces == 1) { 
                return true;
            }

            return false;
        }

        private bool CheckIfPlayerWins(int player)
        {
            if (_positions[0] == player && _positions[1] == player && _positions[2] == player)
                return true;
            else if (_positions[3] == player && _positions[4] == player && _positions[5] == player)
                return true;
            else if (_positions[6] == player && _positions[7] == player && _positions[8] == player)
                return true;
            else if (_positions[0] == player && _positions[3] == player && _positions[6] == player)
                return true;
            else if (_positions[1] == player && _positions[4] == player && _positions[7] == player)
                return true;
            else if (_positions[2] == player && _positions[5] == player && _positions[8] == player)
                return true;
            else if (_positions[0] == player && _positions[5] == player && _positions[8] == player)
                return true;
            else if (_positions[2] == player && _positions[4] == player && _positions[6] == player)
                return true;

            return false;
        }


        /*private bool CheckIfXWins()
        {
            if (_positions[0] == 0 && _positions[1] == 0 && _positions[2] == 0)
                return true;
            else if (_positions[3] == 0 && _positions[4] == 0 && _positions[5] == 0)
                return true;
            else if (_positions[6] == 0 && _positions[7] == 0 && _positions[8] == 0)
                return true;
            else if (_positions[0] == 0 && _positions[3] == 0 && _positions[6] == 0)
                return true;
            else if (_positions[1] == 0 && _positions[4] == 0 && _positions[7] == 0)
                return true;
            else if (_positions[2] == 0 && _positions[5] == 0 && _positions[8] == 0)
                return true;
            else if (_positions[0] == 0 && _positions[5] == 0 && _positions[8] == 0)
                return true;
            else if (_positions[2] == 0 && _positions[4] == 0 && _positions[6] == 0)
                return true;

            return false;
        }
        */

     /*   private bool CheckIfOWins()
        {
            if (_positions[0] == 1 && _positions[1] == 1 && _positions[2] == 1)
                return true;
            else if (_positions[3] == 1 && _positions[4] == 1 && _positions[5] == 1)
                return true;
            else if (_positions[6] == 1 && _positions[7] == 1 && _positions[8] == 1)
                return true;
            else if (_positions[0] == 1 && _positions[3] == 1 && _positions[6] == 1)
                return true;
            else if (_positions[1] == 1 && _positions[4] == 1 && _positions[7] == 1)
                return true;
            else if (_positions[2] == 1 && _positions[5] == 1 && _positions[8] == 1)
                return true;
            else if (_positions[0] == 1 && _positions[5] == 1 && _positions[8] == 1)
                return true;
            else if (_positions[2] == 1 && _positions[4] == 1 && _positions[6] == 1)
                return true;

            return false;
        }
       */
        public void Run()
        {
            bool gameOver = false;
 
            bool validMove = false;

            string row = string.Empty;
            string column = string.Empty;

            while (!gameOver)
            {
                validMove = false;

                while (!validMove)
                {

                    Console.SetCursorPosition(2, 19);

                    Console.Write("Player X");

                    Console.SetCursorPosition(2, 20);

                    Console.Write("Please Enter Row: ");
                    row = Console.ReadLine();

                    Console.SetCursorPosition(2, 22);


                    Console.Write("Please Enter Column: ");
                    column = Console.ReadLine();

                    validMove = IsMoveValid(int.Parse(row), int.Parse(column));

                    if (!validMove)
                    {
                        Console.WriteLine("Invalid Move, Please Try Again!");
                    }

                }

                int playPosition = (int.Parse(row) * 3) + int.Parse(column);
                _positions[playPosition] = 0;
                _boardRenderer.AddMove(int.Parse(row), int.Parse(column), PlayerEnum.X, true);

                bool xWins = CheckIfPlayerWins(0);

                if (!xWins)
                {
                    validMove = false;

                    while (!validMove)
                    {
                        Console.SetCursorPosition(2, 19);

                        Console.Write("Player O");

                        Console.SetCursorPosition(2, 20);

                        Console.Write("Please Enter Row: ");
                        row = Console.ReadLine();

                        Console.SetCursorPosition(2, 22);


                        Console.Write("Please Enter Column: ");
                        column = Console.ReadLine();

                        validMove = IsMoveValid(int.Parse(row), int.Parse(column));

                        if (!validMove)
                        {
                            Console.WriteLine("Invalid Move, Please Try Again!");
                        }

                    }

                    playPosition = (int.Parse(row) * 3) + int.Parse(column);
                    _positions[playPosition] = 1;

                    _boardRenderer.AddMove(int.Parse(row), int.Parse(column), PlayerEnum.O, true);
                }

                bool OWins = CheckIfPlayerWins(1);

                bool tied = IsTied();

                Console.SetCursorPosition(2, 24);

                if (xWins)
                {
                    Console.WriteLine("Player X Wins!");
                }
                else if (OWins)
                {
                    Console.WriteLine("Player O Wins!");
                }
                else if (tied)
                {
                    Console.WriteLine("Game is tied!");
                }

                if (OWins || xWins || tied) { 
                    gameOver = true;
                }

            }
        }
    }
}
