using System;
using System.Collections.Generic;
using System.Text;

namespace eMart.Tests.Exceptions
{
  public  class UserAlreadyExistException : Exception
    {
            public string Messages;
            public UserAlreadyExistException()
            {
                Messages = "Already Exist";
            }
            public UserAlreadyExistException(string message)
            {
                Messages = message;
            }

        }

 }

