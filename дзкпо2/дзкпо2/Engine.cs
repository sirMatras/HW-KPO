using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEngine
{
    public string GetEngineType();
    public bool IsSuitable(int strength);
}

public class PedalEngine : IEngine
{
    private const int pedalStrenght = 5;
    public int PedalSize { get; set; }
    public PedalEngine(int pedalSize)
    {
        PedalSize = pedalSize;
    }

    public string GetEngineType()
    {
        return "pedal";
    }

    public bool IsSuitable(int strength)
    {
        return strength > pedalStrenght;
    }
}

public class HandEngine : IEngine
{
    private const int handStrenght = 5;
    public int Size { get; set; }

    public HandEngine(int size)
    {
        Size = size;
    }

    public string GetEngineType()
    {
        return "hand";
    }

    public bool IsSuitable(int strength)
    {
        return strength > handStrenght;
    }
}
