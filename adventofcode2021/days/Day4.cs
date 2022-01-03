using adventofcode2021.util;

namespace adventofcode2021.days;

public class Day4: IProblem
{
    private readonly List<string> _input = FileLoader.LoadAsList("day4_input.txt");

    public class BingoBoard
    {
       
        public BingoBoard(IReadOnlyList<int> numbers)
        {
            if (numbers.Count != 25)
            {
                throw new ArgumentOutOfRangeException(nameof(numbers), $"should have 25 numbers but has {numbers.Count}");
            }
            
            for (var index = 0; index < numbers.Count; index++)
            {
                BingoNumbers[index] = new BingoNumber(numbers[index]);
            }
        }

        public bool HasBingo()
        {
            bool bingo = false;
            for (var i = 0; i < 5; i++)
            {
                bingo |= BingoNumbers[i * 5].Marked && 
                         BingoNumbers[i * 5+1].Marked && 
                         BingoNumbers[i * 5+2].Marked &&
                         BingoNumbers[i * 5+3].Marked &&
                         BingoNumbers[i * 5+4].Marked;
                
                bingo |= BingoNumbers[i].Marked && 
                         BingoNumbers[i+5].Marked && 
                         BingoNumbers[i+10].Marked &&
                         BingoNumbers[i+15].Marked &&
                         BingoNumbers[i+20].Marked;
            }

            return bingo;
        }
        
        public void TryMarkNumber(int number)
        {
            var firstOrDefault = BingoNumbers.FirstOrDefault(b => b.Number == number, new BingoNumber(-1));
            firstOrDefault.Marked = true;
        }

        public BingoNumber[] BingoNumbers { get; } = new BingoNumber[25];

        public override string ToString()
        {
            
            var s = "";
            for (var i = 0; i < 25; i++)
            {
                var b = BingoNumbers[i];

                s += b.Marked ? " x" : b.Number < 10 ? " " + b.Number : b.Number;
                s += " ";
                if (i != 0 && (i + 1) % 5 == 0)
                {
                    s += "\n";
                }
            }
            
            return s;
        }
    }

    public class BingoNumber
    {
        public readonly int Number;
        public bool Marked;

        public BingoNumber(int number, bool marked = false)
        {
            Number = number;
            Marked = marked;
        }

        public override string ToString()
        {
            string m = Marked ? "Marked" : "Unmarked";
            return $"number: {Number} marked: {m}";
        }
    }

    private (List<BingoBoard>, List<int>) Setup()
    {
        var numbers = _input[0].Split(',').ToList().ConvertAll(s => int.Parse(s.Trim()));
        var bingoBoards = new List<BingoBoard>();
        
        for (var index = 2; index < _input.Count; index+=6)
        {
            var numberS = new List<string>();
            numberS.AddRange(_input[index].Split(' '));
            numberS.AddRange(_input[index+1].Split(' '));
            numberS.AddRange(_input[index+2].Split(' '));
            numberS.AddRange(_input[index+3].Split(' '));
            numberS.AddRange(_input[index+4].Split(' '));

            var convertAll = numberS.FindAll(s=> s.Length > 0).ConvertAll(s => int.Parse(s.Trim()));
            bingoBoards.Add(new BingoBoard(convertAll));
        }

        return (bingoBoards, numbers);
    }
    
    public long Answer(params long[] arguments)
    {
        // Prepare numbers
        var (bingoBoards, numbers) = Setup();
        var (foundBingoBoard, lastCalledNumber) = PlayForFirstBingo(bingoBoards, numbers);
        var unMarkedSum = foundBingoBoard.BingoNumbers.Where(number => !number.Marked).Sum(number => number.Number);
        
        return unMarkedSum * lastCalledNumber;
    }

    static (BingoBoard bingoBoard, int lastCalledNumber) PlayForFirstBingo(List<BingoBoard> bingoBoards, List<int> numbers)
    {
        foreach (var number in numbers)
        {
            foreach (var bingoBoard in bingoBoards)
            {
                bingoBoard.TryMarkNumber(number);
                if (bingoBoard.HasBingo())
                {
                    return (bingoBoard, number);
                }
            }
        }

        return (null, -1);
    }

    public long Answer2(params long[] arguments)
    {
        
        var (bingoBoards, numbers) = Setup();
        var (foundBingoBoard, lastCalledNumber) = PlayForLastBingo(bingoBoards, numbers);
        var unMarkedSum = foundBingoBoard.BingoNumbers.Where(number => !number.Marked).Sum(number => number.Number);
        
        return unMarkedSum * lastCalledNumber;
    }

    static (BingoBoard bingoBoard, int lastCalledNumber)  PlayForLastBingo(List<BingoBoard> bingoBoards, List<int> numbers)
    {

        List<BingoBoard> find = new List<BingoBoard>(bingoBoards);;
        
        foreach (var number in numbers)
        {
            List<BingoBoard> toRemove = new List<BingoBoard>();
            foreach (var bingoBoard in find)
            {
                bingoBoard.TryMarkNumber(number);
                if (bingoBoard.HasBingo())
                {
                    if (find.Count == 1)
                    {
                        return (bingoBoard, number);
                    }
                    toRemove.Add(bingoBoard);
                }
            }
            
            foreach (var bingoBoard in toRemove)
            {
                find.Remove(bingoBoard);
            }
        }
        
        return (null, -1);
    }
}