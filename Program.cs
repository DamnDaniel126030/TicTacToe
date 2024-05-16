using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	internal class Program
	{
		private static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		static char currentPlayer = 'X';

		static void Main(string[] args)
		{
			int move;
			bool isValidMove;
			while (true)
			{
				Console.Clear();
				PrintBoard();
                Console.WriteLine("Player " + currentPlayer + ", pick a box (1-9): ");
				isValidMove = int.TryParse(Console.ReadLine(), out move) && MoveIsValid(move);

				if (isValidMove)
				{
					board[move - 1] = currentPlayer;
					if (CheckWin())
					{
						Console.Clear();
						PrintBoard();
                        Console.WriteLine("Player " + currentPlayer + " nyert!");
						break;
                    }
					SwitchPlayer();
				}
				else
				{
                    Console.WriteLine("Invalid move, try again");
					Console.ReadLine();
                }

				if (IsBoardFull())
				{
					Console.Clear();
					PrintBoard();
                    Console.WriteLine("Tie!");
					break;
                }
            }
        }

		static void PrintBoard()
		{
            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
			Console.WriteLine("---|---|---");
			Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
		}

		static bool MoveIsValid(int move)
		{
			return move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O';
		}

		static void SwitchPlayer()
		{
			currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
		}

		static bool CheckWin()
		{
			return (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer ||
				board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer ||
				board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer ||
				board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer ||
				board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer ||
				board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer ||
				board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer ||
				board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);
		}

		static bool IsBoardFull()
		{
            foreach (char spotChar in board)
            {
                if (spotChar != 'X' && spotChar != 'O')
				{
					return false;
				}
            }
			return true; 
        }
	}
}
