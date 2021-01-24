using System.Collections.Generic;

public class Box
{
    public int BoxNumber {get;}
    public int NumberInBox {get; set;}
    public bool Changed {get; set;}

    public bool New {get; set;} //Används för att se om det är en automatiskt tillagd ruta och då sätta annan färg på den vid utskrift.

    public List<int> neighbours = new List<int>();

    public Box(int boxNumber)
    {
        this.BoxNumber = boxNumber;
        this.NumberInBox = 0;
        this.Changed = false;
        
        this.New = true;
    }
}