using GalaSoft.MvvmLight.Messaging;
using System;

namespace Popcorn.Messaging
{
    /// <summary>
    /// Used to transmis a Unhandled exception message
    /// </summary>
    public class UnhandledExceptionMessage : MessageBase
    {
        /// <summary>
        /// Unhandled exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Create an instance of <see cref="UnhandledExceptionMessage"/>
        /// </summary>
        /// <param name="exception"></param>
        public UnhandledExceptionMessage(Exception exception)
        {
            Exception = exception;
        }
    }
}