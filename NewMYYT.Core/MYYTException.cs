using System;

namespace NewMYYT.Core
{
    [Serializable]
    public class MYYTException : Exception
    {
        public MYYTException(string message)
            : base(message)
        {
        }
    }
}