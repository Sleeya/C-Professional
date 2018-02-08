using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangerousFloor
{
    
    class Program
    {
        private static char[,] matrix;
        static void Main(string[] args)
        {
            InitializeMatrix();

            MovePieces();
        }

        private static void MovePieces()
        {
            var input = string.Empty;
            while ((input=Console.ReadLine())!="END")
            {
                var piece = input[0];
                int pieceRow = int.Parse(input[1].ToString());
                int pieceCol = int.Parse(input[2].ToString());
                int pieceNewRow = int.Parse(input[4].ToString());
                int pieceNewCol = int.Parse(input[5].ToString());

                if (matrix[pieceRow,pieceCol]!= piece)
                {
                    Console.WriteLine($"There is no such a piece!");
                    continue;
                }

                if (pieceNewRow < 0 || pieceNewRow >= 8 || pieceNewCol < 0 || pieceNewCol >= 8)
                {
                    Console.WriteLine($"Move go out of board!");
                    continue;
                    
                }

                bool moveIsValid = false;
                switch (piece)
                {
                        case 'K':
                        if (pieceNewRow == pieceRow  && pieceNewCol == pieceCol + 1)
                        {
                            moveIsValid = true;
                            
                        }
                        else if (pieceNewRow == pieceRow  && pieceNewCol == pieceCol - 1)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceNewRow == pieceRow + 1 && pieceNewCol == pieceCol)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceNewRow == pieceRow - 1 && pieceNewCol == pieceCol )
                        {
                            moveIsValid = true;
                        }


                        else if (pieceNewRow == pieceRow+1 && pieceNewCol == pieceCol+1)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceNewRow == pieceRow + 1 && pieceNewCol == pieceCol - 1)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceNewRow == pieceRow - 1 && pieceNewCol == pieceCol - 1)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceNewRow == pieceRow - 1 && pieceNewCol == pieceCol + 1)
                        {
                            moveIsValid = true;
                        }

                            break;

                    case 'R':
                        if (pieceRow == pieceNewRow && pieceCol != pieceNewCol)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceRow != pieceNewRow && pieceCol == pieceNewCol)
                        {
                            moveIsValid = true;
                        }

                        break;

                    case 'B':
                        if (Math.Abs(pieceNewRow - pieceRow) == Math.Abs(pieceNewCol - pieceCol))
                        {
                            moveIsValid = true;
                        }
                        break;

                    case 'Q':
                        if (Math.Abs(pieceNewRow - pieceRow) == Math.Abs(pieceNewCol - pieceCol ))
                        {
                            moveIsValid = true;
                        }
                        else if (pieceRow == pieceNewRow && pieceCol != pieceNewCol)
                        {
                            moveIsValid = true;
                        }
                        else if (pieceRow != pieceNewRow && pieceCol == pieceNewCol)
                        {
                            moveIsValid = true;
                        }

                        break;

                    case 'P':
                        if (pieceNewRow == pieceRow - 1)
                        {
                            moveIsValid = true;
                        }
                        break;
                        
                }

                if (moveIsValid)
                {
                    matrix[pieceNewRow, pieceNewCol] = piece;
                    matrix[pieceRow, pieceCol] = 'x';
                }
                else
                {
                    Console.WriteLine($"Invalid move!");
                }
               

        }
        }

        private static void InitializeMatrix()
        {
            matrix= new char[8,8];

            for (int row = 0; row < 8; row++)
            {
                var input = Console.ReadLine().Split(',').ToArray();

                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = char.Parse(input[col]);
                }
            }
        }
    }
}
