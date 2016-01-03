using RPS.RandomValueGenerator.Abstract;
using RPS.Shared;
using System;
using System.Threading;

namespace RPS.RandomValueGenerator
{
    public class RPSRandomSelection : IRandomSelection
    {
        Random _random = new Random();
        public Selection Select()
        {
            Thread.Sleep(10); //HACK: To make sure that random numbers are generated
            return (Selection)_random.Next(3);
        }
    }
}
