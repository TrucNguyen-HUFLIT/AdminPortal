using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EmailExistedException : Exception
    {
        public EmailExistedException(string email)
            : base($"Email '{email}' already exists!")
        {

        }
    }
}
