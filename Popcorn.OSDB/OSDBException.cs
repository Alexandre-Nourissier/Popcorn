using System;

namespace Popcorn.OSDB
{
    /// <summary>
    /// OSDB exception
    /// </summary>
    [Serializable]
    public class OsdbException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public OsdbException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public OsdbException(string message) : base(message)
        {
        }
    }
}