using System;

namespace CodeClinic.Application.Common.Exceptions
{
    public class PostException : Exception
    {
        public PostException()
            : base()
        {


        }

        public PostException(string message)
            : base(message)
        {


        }


        public PostException(string name, Exception innerException)
            : base(name?? $"Failed to create entity  \"{name}\" " , innerException)
        {
        }

        public PostException(string name, string reason)
            : base($"Failed to create entity  \"{name}\" because {reason}")
        {
        }
    }
}
