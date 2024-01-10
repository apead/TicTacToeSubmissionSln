using System;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe2d
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[,] _positions = new int[3, 3] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
        
        public TicTacToe2d()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }

        private bool IsMoveValid(int row, int column)
        {
            if (_positions[row,column] == -1)
                return true;

            return false;
        }

        private bool IsTied()
        {
            int blankSpaces = 0;
           
            for(int rowIndex=0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    if (_positions[rowIndex,columnIndex] == -1)
                    {
                        blankSpaces++;
                    }
                }
            }

            if (blankSpaces == 1) { 
                return true;
            }

            return false;
        }

        private bool CheckIfPlayerWins(int player)
        {
            if (_positions[0, 0] == player && _positions[0, 1] == player && _positions[0, 2] == player)
                return true;
            else if (_positions[1, 0] == player && _positions[1, 1] == player && _positions[1, 2] == player)
                return true;
            else if (_positions[2, 0] == player && _positions[2, 1] == player && _positions[2, 2] == player)
                return true;
            else if (_positions[0, 0] == player && _positions[1, 0] == player && _positions[2, 0] == player)
                return true;
            else if (_positions[0, 1] == player && _positions[1, 1] == player && _positions[2, 1] == player)
                return true;
            else if (_positions[0, 2] == player && _positions[1, 2] == player && _positions[2, 2] == player)
                return true;
            else if (_positions[0, 0] == player && _positions[1, 1] == player && _positions[2, 2] == player)
                return true;
            else if (_positions[0, 2] == player && _positions[1, 1] == player && _positions[2, 0] == player)
                return true;

            return false;
        }

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

                _positions[int.Parse(row),int.Parse(column)] = 0;

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
                    
                    _positions[int.Parse(row), int.Parse(column)] = 1;
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
