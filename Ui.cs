using System;
using System.Collections.Generic;

class Ui
{
    public void PrintBoard(List<Box> tempBoxList, int score)
    {
        string board = "";

        for (int i = 0; i < tempBoxList.Count; i++)
        {
            if (tempBoxList[i].NumberInBox == 0)
            {
                board += "|    ";
            }
            else
            {
                if (tempBoxList[i].NumberInBox > 999)
                {
                    board += "|" + tempBoxList[i].NumberInBox + "";
                }
                else if (tempBoxList[i].NumberInBox > 99)
                {
                    board += "| " + tempBoxList[i].NumberInBox + "";
                }
                else if (tempBoxList[i].NumberInBox > 9)
                {
                    board += "| " + tempBoxList[i].NumberInBox + " ";
                }
                else
                {
                    board += "|  " + tempBoxList[i].NumberInBox + " ";
                }
            }

            if (i == 3 || i == 7 || i == 11)
            {
                board += "|\n---------------------\n";
            }
            else if (i == 15)
            {
                board += "|";
            }
        }

        board += "\n\nScore: " + score;

        Console.Clear();
        Console.WriteLine(board);
    }

    public ConsoleKeyInfo Direction()
    {
        bool loop = true;
        ConsoleKeyInfo direction;

        do
        {
            direction = Console.ReadKey();
            if (direction.Key == ConsoleKey.UpArrow || direction.Key == ConsoleKey.DownArrow || direction.Key == ConsoleKey.LeftArrow || direction.Key == ConsoleKey.RightArrow)
            {
                loop = false;
            }
        } while (loop);

        return direction;
    }

    public void GameOver()
    {
        Console.WriteLine("Game over!!!");
        Console.WriteLine("\n\n\n");
        Environment.Exit(0);
    }
}