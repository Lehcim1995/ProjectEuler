namespace ProjectEuler.Interfaces
{
    interface IProblem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        long Answer(params long[] arguments);
    }
}
