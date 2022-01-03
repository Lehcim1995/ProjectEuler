namespace adventofcode2021;

public interface IProblem
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="arguments"></param>
    /// <returns></returns>
    long Answer(params long[] arguments);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="arguments"></param>
    /// <returns></returns>
    long Answer2(params long[] arguments);
}