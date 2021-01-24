using System;
using System.Collections.Generic;
using System.Linq;

class Manager
{
    List<Box> boxList = new List<Box>();
    List<Box> emptyBoxesList = new List<Box>();
    public int Score { get; set; }
    bool Full { get; set; }
    private bool AnythingMoved { get; set; }

    public Manager()
    {
        this.Score = 0;
        this.Full = false;
    }

    public void CreateBoxes()
    {
        for (int i = 1; i < 17; i++)
        {
            Box box = new Box(i);
            boxList.Add(box);
        }
    }

    public void AddNeighbours()
    {
        boxList[0].neighbours.Add(1);
        boxList[0].neighbours.Add(4);

        boxList[1].neighbours.Add(0);
        boxList[1].neighbours.Add(2);
        boxList[1].neighbours.Add(5);

        boxList[2].neighbours.Add(1);
        boxList[2].neighbours.Add(3);
        boxList[2].neighbours.Add(6);

        boxList[3].neighbours.Add(2);
        boxList[3].neighbours.Add(7);

        boxList[4].neighbours.Add(0);
        boxList[4].neighbours.Add(5);
        boxList[4].neighbours.Add(8);

        boxList[5].neighbours.Add(1);
        boxList[5].neighbours.Add(4);
        boxList[5].neighbours.Add(6);
        boxList[5].neighbours.Add(9);

        boxList[6].neighbours.Add(2);
        boxList[6].neighbours.Add(5);
        boxList[6].neighbours.Add(7);
        boxList[6].neighbours.Add(10);

        boxList[7].neighbours.Add(3);
        boxList[7].neighbours.Add(6);
        boxList[7].neighbours.Add(11);

        boxList[8].neighbours.Add(4);
        boxList[8].neighbours.Add(9);
        boxList[8].neighbours.Add(12);

        boxList[9].neighbours.Add(5);
        boxList[9].neighbours.Add(8);
        boxList[9].neighbours.Add(10);
        boxList[9].neighbours.Add(13);

        boxList[10].neighbours.Add(6);
        boxList[10].neighbours.Add(9);
        boxList[10].neighbours.Add(11);
        boxList[10].neighbours.Add(14);

        boxList[11].neighbours.Add(7);
        boxList[11].neighbours.Add(10);
        boxList[11].neighbours.Add(15);

        boxList[12].neighbours.Add(8);
        boxList[12].neighbours.Add(13);

        boxList[13].neighbours.Add(9);
        boxList[13].neighbours.Add(12);
        boxList[13].neighbours.Add(14);

        boxList[14].neighbours.Add(10);
        boxList[14].neighbours.Add(13);
        boxList[14].neighbours.Add(15);

        boxList[15].neighbours.Add(11);
        boxList[15].neighbours.Add(14);
    }

    private void UpdateEmptyBoxesList()
    {
        foreach (Box box in boxList)
        {
            if (box.NumberInBox == 0)
            {
                emptyBoxesList.Add(box);
            }
        }
    }

    public void AddRandom()
    {
        emptyBoxesList.Clear();
        UpdateEmptyBoxesList();

        Random randomNum = new Random();
        int randomNumber = Convert.ToInt32(randomNum.Next(1, 10));

        if (randomNumber == 1)
        {
            randomNumber = 4;
        }
        else
        {
            randomNumber = 2;
        }

        Random randomBox = new Random();

        int randomBoxNumber = randomBox.Next(emptyBoxesList.Count);

        int boxNumber = emptyBoxesList[randomBoxNumber].BoxNumber;

        foreach (Box box in boxList)
        {
            if (box.BoxNumber == boxNumber)
            {
                box.NumberInBox = randomNumber;
            }
        }
    }

    // Devide into more methods.
    public void Move(ConsoleKeyInfo direction)
    {
        if (direction.Key == ConsoleKey.UpArrow) //move up
        {
            MoveStuff(0, 4, 8, 12);
            MoveStuff(1, 5, 9, 13);
            MoveStuff(2, 6, 10, 14);
            MoveStuff(3, 7, 11, 15);
        }
        else if (direction.Key == ConsoleKey.DownArrow) //move down
        {
            MoveStuff(12, 8, 4, 0);
            MoveStuff(13, 9, 5, 1);
            MoveStuff(14, 10, 6, 2);
            MoveStuff(15, 11, 7, 3);
        }
        else if (direction.Key == ConsoleKey.LeftArrow) //move left
        {
            MoveStuff(0, 1, 2, 3);
            MoveStuff(4, 5, 6, 7);
            MoveStuff(8, 9, 10, 11);
            MoveStuff(12, 13, 14, 15);
        }
        else //move right
        {
            MoveStuff(3, 2, 1, 0);
            MoveStuff(7, 6, 5, 4);
            MoveStuff(11, 10, 9, 8);
            MoveStuff(15, 14, 13, 12);
        }

        foreach (Box box in boxList)
        {
            box.New = false;
        }

        if (AnythingMoved == true)
        {
            AddRandom();
            AnythingMoved = false;
        }


        foreach (Box box in boxList)
        {
            box.Changed = false;
        }
    }

    private void MoveStuff(int a, int b, int c, int d)
    {
        //1
        if (boxList[a].NumberInBox == 0 && boxList[b].NumberInBox != 0)
        {
            boxList[a].NumberInBox = boxList[b].NumberInBox;
            boxList[b].NumberInBox = 0;
            AnythingMoved = true;
        }
        else if (boxList[a].NumberInBox == boxList[b].NumberInBox & boxList[a].NumberInBox != 0)
        {
            boxList[a].NumberInBox = (boxList[a].NumberInBox * 2);
            Score += boxList[a].NumberInBox;
            boxList[b].NumberInBox = 0;
            boxList[a].Changed = true;
            AnythingMoved = true;
        }


        //2
        if (boxList[b].NumberInBox == 0 && boxList[c].NumberInBox != 0)
        {
            boxList[b].NumberInBox = boxList[c].NumberInBox;
            boxList[c].NumberInBox = 0;
            AnythingMoved = true;
        }
        else if (boxList[b].NumberInBox == boxList[c].NumberInBox && boxList[b].NumberInBox != 0 && boxList[c].Changed == false)
        {
            boxList[b].NumberInBox *= 2;
            Score += boxList[b].NumberInBox;
            boxList[c].NumberInBox = 0;
            boxList[b].Changed = true;
            AnythingMoved = true;
        }

        //3
        if (boxList[c].NumberInBox == 0 && boxList[d].NumberInBox != 0)
        {
            boxList[c].NumberInBox = boxList[d].NumberInBox;
            boxList[d].NumberInBox = 0;
            AnythingMoved = true;
        }
        else if (boxList[c].NumberInBox == boxList[d].NumberInBox && boxList[c].NumberInBox != 0 && boxList[c].Changed == false)
        {
            boxList[c].NumberInBox *= 2;
            Score += boxList[c].NumberInBox;
            boxList[d].NumberInBox = 0;
            boxList[c].Changed = true;
            AnythingMoved = true;

        }

        //4
        if (boxList[a].NumberInBox == 0 && boxList[b].NumberInBox != 0)
        {
            boxList[a].NumberInBox = boxList[b].NumberInBox;
            boxList[b].NumberInBox = 0;
            AnythingMoved = true;
        }
        else if (boxList[a].NumberInBox == boxList[b].NumberInBox && boxList[a].NumberInBox != 0 && boxList[b].Changed == false)
        {
            boxList[a].NumberInBox *= 2;
            Score += boxList[a].NumberInBox;
            boxList[b].NumberInBox = 0;
            boxList[a].Changed = true;
            AnythingMoved = true;
        }

        //5
        if (boxList[b].NumberInBox == 0 && boxList[c].NumberInBox != 0)
        {
            boxList[b].NumberInBox = boxList[c].NumberInBox;
            boxList[c].NumberInBox = 0;
            AnythingMoved = true;
        }
        else if (boxList[b].NumberInBox == boxList[c].NumberInBox && boxList[b].NumberInBox != 0 && boxList[c].Changed == false)
        {
            boxList[b].NumberInBox *= 2;
            Score += boxList[b].NumberInBox;
            boxList[c].NumberInBox = 0;
            boxList[b].Changed = true;
            AnythingMoved = true;
        }

        //6
        if (boxList[a].NumberInBox == 0 && boxList[b].NumberInBox != 0)
        {
            boxList[a].NumberInBox = boxList[b].NumberInBox;
            boxList[b].NumberInBox = 0;
            AnythingMoved = true;
        }
        else if (boxList[a].NumberInBox == boxList[b].NumberInBox && boxList[a].NumberInBox != 0 && boxList[b].Changed == false)
        {
            boxList[a].NumberInBox *= 2;
            Score += boxList[a].NumberInBox;
            boxList[b].NumberInBox = 0;
            boxList[a].Changed = true;
            AnythingMoved = true;
        }
    }

    public List<Box> PrintBoard()
    {
        List<Box> tempBoxList = new List<Box>();

        foreach (Box box in boxList)
        {
            tempBoxList.Add(box);
        }
        return tempBoxList;
    }

    public bool BoardFull()
    {
        bool full = false;
        int numberOfFullBoxes = 0;

        foreach (Box box in boxList)
        {
            if (box.NumberInBox != 0)
            {
                numberOfFullBoxes++;
            }
        }

        if (numberOfFullBoxes == 16)
        {
            full = true;
        }
        return full;
    }

    //Metod for checking if you can make a move.
    //if bool is false, then the game is over.
    public bool NoMoves()
    {
        int possibleMoves = 0;
        bool noMoves = false;

        foreach (Box box in boxList)
        {
            for (int i = 0; i < box.neighbours.Count; i++)
            {
                if (box.NumberInBox == boxList[box.neighbours[i]].NumberInBox)
                {
                    possibleMoves += 1;
                }
            }    
        }

        if (possibleMoves == 0)
        {
            noMoves = true;
        }
        return noMoves;
    }
}