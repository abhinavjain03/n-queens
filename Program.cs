using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueensProblem
{

    class NQueen
    {
        public static int N = 8;
        public int[,] position = new int[8, 8];

        bool checkColumn(int column, int row)
        {
            for (int i = row - 1; i >= 0; i--)
            {
                if (position[i, column] != 0)
                    return false;
            }
            return true;
        }

        bool checkLeft(int row, int col)
        {
            int left = col - 1;
            for (int i = row - 1; i >= 0; i--)
            {
                if (left >= 0)
                {
                    if (position[i, left] == 0)
                        left--;
                    else
                        return false;
                }                                

            }
            return true;
        }

        bool checkRight(int row, int col)
        {
            int right = col + 1;
            for (int i = row - 1; i >= 0; i--)
            {
                if (right <= N-1)
                {
                    if (position[i, right] == 0)
                        right++;
                    else
                        return false;
                }

            }
            return true;

        }
        bool checkDiagonals(int row, int col)
        {
            int j = col;
            int right = col + 1;
            int left = col - 1;
            bool diagCheck=true;
            bool checkedLeft = true;
            bool checkedRight = true;

            checkedLeft = checkLeft(row, col);
            checkedRight = checkRight(row, col);

            if (checkedLeft && checkedRight)
            {
                diagCheck = true;
            }
            else
            {
                diagCheck = false;
            }
            return diagCheck;
        }

         public bool placeAQueen(int row)
        {
            bool colCheck;
            bool diagCheck;
            for (int i = 0; i < 50; i++)
            {
                colCheck=checkColumn(i, row);
                if (colCheck == true)
                {
                    diagCheck=checkDiagonals(row,i);
                    if (diagCheck == true)
                    {
                        Console.WriteLine("Placing Queen at position " + row + "," + i);
                        position[row, i] = 1;
                        return true;
                    }

                }
                        
            }
            return false;
        }
        public bool placeAQueenRecursion(int placesLeft)
        {
            int i;
            if (placesLeft == 0)
                return true;
           
                bool colCheck=false;
                bool diagCheck=false;
                for (i = 0; i < N; i++)
                {
                    colCheck = checkColumn(i, N - placesLeft);
                    if (colCheck == true)
                    {
                        diagCheck = checkDiagonals(N - placesLeft, i);
                        if (diagCheck == true)
                        {
                            //Console.WriteLine("Placing Queen at position " + (N - placesLeft) + "," + i);
                            position[N - placesLeft, i] = 1;
                        if (!placeAQueenRecursion(placesLeft - 1))
                        {
                            //Console.WriteLine("Removing Queen at position " + (N - placesLeft) + "," + i);
                            position[N - placesLeft, i] = 0;
                            continue;
                        }
                        else
                        {
                            return true;
                        }

                        }

                    }
                }
                if (!(colCheck && diagCheck))
                    return false;

            return false;
            
        }


    }

   


    class Runner
    {
        static void Main(string[] args)
        {
            NQueen nqueen = new NQueensProblem.NQueen();

            bool placedQueen;
            //NQueen.N=Convert.ToInt32(Console.ReadLine());

           placedQueen =  nqueen.placeAQueenRecursion(NQueen.N);
            if (placedQueen)
            {
                for (int i = 0; i < NQueen.N; i++)
                {
                    for (int j = 0; j < NQueen.N; j++)
                    {
                        Console.Write(nqueen.position[i, j] + "\t");
                    }
                    Console.Write("\n");
                }
            }
            Console.ReadKey();
            //for (int i = 0; i < 8; i++)
            //{
            //    placedQueen = nqueen.placeAQueen(i);
            //    if (placedQueen == false)
            //    {
            //        Console.WriteLine("CAnt place Queen, do something about it.");
            //        Console.ReadKey();
            //    }
            //}




            //start from beginning
            //chck whether queen can be placed there
            //if not move to the next square
            //if no square left, backtrack to the previous row and move the queen in the previous row
            //if yes, place and move to next


        }
    }
}
