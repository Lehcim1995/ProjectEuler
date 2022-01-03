using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode2021.days;
using NUnit.Framework;

namespace adventofcode2021Tests;

public class Tests
{

    private Day4.BingoBoard _board;
    
    [SetUp]
    public void Setup()
    {
        int[] number = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
        _board = new Day4.BingoBoard(number.ToList());
    }

    [Test]
    public void Test1()
    {
        Assert.False(_board.HasBingo());
        
        _board.TryMarkNumber(1);
        _board.TryMarkNumber(2);
        _board.TryMarkNumber(3);
        _board.TryMarkNumber(4);
        _board.TryMarkNumber(5);
        
        Assert.True(_board.HasBingo());
        Console.WriteLine(_board);
    }
    
    [Test]
    public void Test1_2()
    {
        Assert.False(_board.HasBingo());
        
        _board.TryMarkNumber(2);
        _board.TryMarkNumber(3);
        _board.TryMarkNumber(4);
        _board.TryMarkNumber(5);
        _board.TryMarkNumber(6);
        
        Assert.False(_board.HasBingo());
        Console.WriteLine(_board);
    }
    
    [Test]
    public void Test2()
    {
        Assert.False(_board.HasBingo());
        
        _board.TryMarkNumber(1);
        _board.TryMarkNumber(6);
        _board.TryMarkNumber(11);
        _board.TryMarkNumber(16);
        _board.TryMarkNumber(21);
        
        Assert.True(_board.HasBingo());
        Console.WriteLine(_board);
    }
    
    [Test]
    public void Test3()
    {
        Assert.False(_board.HasBingo());
        
        _board.TryMarkNumber(1);
        _board.TryMarkNumber(7);
        _board.TryMarkNumber(13);
        _board.TryMarkNumber(19);
        _board.TryMarkNumber(25);
        
        Assert.False(_board.HasBingo());
        Console.WriteLine(_board);
    }
}