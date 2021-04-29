using System;

namespace BoxOfficeBL
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Object was not found")
        {

        }
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
