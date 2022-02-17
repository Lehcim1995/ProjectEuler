using System.Drawing;

namespace adventofcode2021.util;

public class InfiniGrid<T>
{
    private readonly Dictionary<Point, T> _grid;
    private readonly T _defaultValue;
    private Point _min;
    private Point _max;
    private bool _dirty = false;

    public InfiniGrid(T defaultValue)
    {
        _grid = new Dictionary<Point, T>();
        _defaultValue = defaultValue;
    }

    public Dictionary<Point, T> Grid => _grid;

    public void AddItem(Point location)
    {
        AddItem(location, _defaultValue);
    }
    
    public void AddItem(Point location, T value)
    {
        _grid.Add(location, value);
    }

    public void SetItem(Point location, T value)
    {
        _grid[location] = value;
    }

    public void TryUpdateItem(Point location, Func<T, T> update, T defaultValue)
    {
        if (ItemExist(location))
        {
            _grid[location] = update(_grid[location]);
        }
        else
        {
            AddItem(location, defaultValue);
        }
        
    }

    public void TrySetItem(Point location, T value)
    {
        TrySetItem(location, value, _defaultValue);
    }
    
    public void TrySetItem(Point location, T value, T defaultValue)
    {
        if (ItemExist(location))
        {
            SetItem(location, value);
        }
        else
        {
            AddItem(location, defaultValue);
        }
    }

    public T GetItem(Point location)
    {
        return _grid[location];
    }

    public bool ItemExist(Point location)
    {
        
        return _grid.ContainsKey(location);
    }

    public void CalculateBounds()
    {
        // TODO
    }

    public void DrawGrid()
    {
        // find min max
        Point min = new Point();
        Point max = new Point();
        
        foreach (var keyValuePair in _grid)
        {
            min.X = Math.Min(keyValuePair.Key.X, min.X);
            min.Y = Math.Min(keyValuePair.Key.Y, min.Y);
            max.X = Math.Max(keyValuePair.Key.X, max.X);
            max.Y = Math.Max(keyValuePair.Key.Y, max.Y);
        }
        
        
    }

}
