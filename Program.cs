using System;

class TicTacToe
{
    static char[] board;
    static char currentPlayer;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. New game");
            Console.WriteLine("2. About the author");
            Console.WriteLine("3. Exit");
            Console.Write("> ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    ShowAbout();
                    break;
                case "3":
                    if (ConfirmExit())
                        return;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void StartNewGame()
    {
        board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        currentPlayer = 'X';

        while (true)
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine($"{currentPlayer}'s move (1-9) > ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int move) && move >= 1 && move <= 9 && board[move - 1] == ' ')
            {
                board[move - 1] = currentPlayer;

                if (CheckWin())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine($"{currentPlayer} won!");
                    Console.WriteLine("[Press Enter to return to main menu...]");
                    Console.ReadLine();
                    break;
                }

                if (IsBoardFull())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("[Press Enter to return to main menu...]");
                    Console.ReadLine();
                    break;
                }

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Illegal move! Try again.");
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static bool IsBoardFull()
    {
        foreach (char cell in board)
        {
            if (cell == ' ')
                return false;
        }
        return true;
    }

    static bool CheckWin()
    {
        int[,] winningCombinations = new int[,]
        {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Rows
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columns
            { 0, 4, 8 }, { 2, 4, 6 }              // Diagonals
        };

        for (int i = 0; i < winningCombinations.GetLength(0); i++)
        {
            if (board[winningCombinations[i, 0]] == currentPlayer &&
                board[winningCombinations[i, 1]] == currentPlayer &&
                board[winningCombinations[i, 2]] == currentPlayer)
            {
                return true;
            }
        }
        return false;
    }

    static void ShowAbout()
    {
        Console.Clear();
        Console.WriteLine("Tic-Tac-Toe Game");
        Console.WriteLine("Author: Your Name");
        Console.WriteLine("This game is a simple implementation of Tic-Tac-Toe.");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    static bool ConfirmExit()
    {
        Console.Write("Are you sure you want to quit? [y/n] > ");
        string confirmation = Console.ReadLine()?.ToLower();
        return confirmation == "y";
    }
}
