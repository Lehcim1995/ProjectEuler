using System.Drawing;

namespace adventofcode2021.util;

public class InfiniGrid<T>
{
    Dictionary<Point, T> Grid;
    private T defaultValue;

    public InfiniGrid()
    {
    }

    public void AddItem(Point location)
    {
        AddItem(location, defaultValue);
    }
    
    public void AddItem(Point location, T value)
    {
        Grid.Add(location, value);
    }

    public void DrawGrid()
    {
        // find min max
        Point min = new Point();
        Point max = new Point();
        
        foreach (var keyValuePair in Grid)
        {
            
            
        }
    }

}
