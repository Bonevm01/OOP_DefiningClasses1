using System;
//Task 1 - Define class
class Display
{
    private double? size;
    private int? numberOfColours;


    //Task 2 - Constructors
    public Display()
        : this(null)
    {
    }

    public Display(double? size)
        : this(null, null)
    {
    }

    public Display(double? size, int? numberOfColours)
    {
        this.size = size;
        this.numberOfColours = numberOfColours;
    }

    //Task 5 - Use properties to encapsulate the data fields 
    public double? Size
    {
        get {return this.size;}
        set 
        {
            if (value<2) //My choice
            {
                throw new ArgumentOutOfRangeException("Display size can't be smaller that 3.6''");
            }
            if (value>5) //My choice
            {
               throw new ArgumentOutOfRangeException("Display size can't be bigger that 5.0''"); 
            }
            this.size = value;
        }
    }
    public int? NumberOfColours
    {
        get { return this.numberOfColours;}
        set
        {
            if (value < 1) //My choice
            {
                throw new ArgumentOutOfRangeException("Number of colours has to be a possitive number."); 
            }
            if (value > 16000000) //My choice
            { 
                throw new ArgumentOutOfRangeException("Number of colours can't be more than 16M."); 
            }
            this.numberOfColours = value;
        }
    }
}
