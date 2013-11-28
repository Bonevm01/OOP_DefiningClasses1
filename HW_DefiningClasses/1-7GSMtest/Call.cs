using System;
//Task 8
class Call
{
    public DateTime date { get; private set; } //I decided to skip encapsulation
    public string time { get; private set; }
    public uint duration { get; private set; }
    public string dialedNumber { get; private set; }

    public Call(DateTime date, string time, uint durationInSeconds, string dialedNumber)
    {
        this.date = date;
        this.time = time;
        this.duration = durationInSeconds;
        this.dialedNumber = dialedNumber;
    }

    
}