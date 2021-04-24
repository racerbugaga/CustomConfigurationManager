using System;
using System.Runtime.Serialization;

namespace CustomConfigurationManager.Exceptions
{
    [Serializable]
    public class CustomConfigurationException : Exception
    {
        public CustomConfigurationException()
        {
        }

        public CustomConfigurationException(string message) : base(message)
        {
        }

        public CustomConfigurationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }

        protected CustomConfigurationException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}