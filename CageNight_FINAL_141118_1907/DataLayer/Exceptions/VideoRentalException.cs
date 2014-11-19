using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Exceptions
{
    public class VideoRentalException : ApplicationException
    {
        public IItem ErrorSource { get; set; }

        public VideoRentalException(string errorMessage) : base(errorMessage) { }

        public VideoRentalException(IItem errorSource, string errorMessage): base(errorMessage)
        {
            ErrorSource = errorSource;
        }
    }
}
