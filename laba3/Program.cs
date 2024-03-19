using System;
using Newtonsoft.Json;

public class Time
{
    public int Hours { get; set; }
    public int Minutes { get;  set; }
    public int Seconds { get;  set; }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public int DifferentSeconds(Time second)
    {
        int sec1 = Hours * 3600 + Minutes * 60 + Seconds;
        int sec2 = second.Hours * 3600 + second.Minutes * 60 + second.Seconds;
        return Math.Abs(sec1 - sec2);
    }

    public Time TimeDifference(int secondsDiffer)
    {
        int tSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        tSeconds += secondsDiffer;
        int hours = tSeconds / 3600;
        int minutes = tSeconds % 3600 / 60;
        int seconds = tSeconds / 3600 % 60;
        return new Time(hours, minutes, seconds);
    }
    public void ser(string fileName)
    {
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText(fileName, json);
    }
    public static Time deser(string fileName)
    {
        string json = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<Time>(json);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("ввести години:");
        int a=int.Parse(Console.ReadLine());
        Console.Write("ввести хвилини:");
        int b = int.Parse(Console.ReadLine());
        Console.Write("ввести секунди:");
        int c = int.Parse(Console.ReadLine());
        Console.Write("ввести години (для допомiжного часу):");
        int a1 = int.Parse(Console.ReadLine());
        Console.Write("ввести хвилини (для допомiжного часу):");
        int b1 = int.Parse(Console.ReadLine());
        Console.Write("ввести секунди (для допомiжного часу):");
        int c1 = int.Parse(Console.ReadLine());
        Console.Write("ввести промiжок для рiзницi:");
        int dff = int.Parse(Console.ReadLine());
        Time t1 = new Time(a, b, c);
        Time t2 = new Time(a1, b1, c1);
        t1.ser("timeee.json");
        Time loadT1 = Time.deser("timeee.json");



        Console.WriteLine($"Рiзниця секунд- {loadT1.DifferentSeconds(t2)}");
        Time reTime = t1.TimeDifference(dff); 
        Console.WriteLine($"отримуємо час- {reTime.Hours}:{reTime.Minutes}:{reTime.Seconds}");

    }
}