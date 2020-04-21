using System;
using Yoti.Auth.Exceptions;

namespace Yoti.Auth.Sandbox
{
    public class SandboxException : YotiException
    {
        public SandboxException()
        {
        }

        public SandboxException(string message)
            : base(message)
        {
        }

        public SandboxException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}