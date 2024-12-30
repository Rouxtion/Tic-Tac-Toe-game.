using System;

class TicTacToe
{
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        while (true)
        {
            PrintBoard();
            Console.WriteLine($"{currentPlayer}'s move (1-9) > ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int move) && move >= 1 && move <= 9 && board[move - 1] == ' ')
            {
                board[move - 1] = currentPlayer;
                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("Game over!");
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
}
