using System;

namespace TankConstruction.Errors
{
    public class TooManyForcesException : Exception
    {
        public TooManyForcesException(string message) : base(message)
        {
           
        }
    }
}
