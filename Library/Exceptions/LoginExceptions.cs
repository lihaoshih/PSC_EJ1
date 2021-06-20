using System;
using System.Runtime.Serialization;

namespace Library.Exceptions
{
    public class LoginExceptions : Exception, ISerializable
    {
        public LoginExceptions() : base("登入失敗") { }

        public LoginExceptions(string message) : base(message) { }

        public LoginExceptions(string message, Exception inner) : base(message, inner) { }

        public LoginExceptions(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
