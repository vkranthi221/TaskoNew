using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Common
{
    /// <summary>
    /// user exception class
    /// </summary>    
    public class UserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserException"/> class.
        /// </summary>
        public UserException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UserException(string message)
            : base(message)
        {
        }
    }
}
