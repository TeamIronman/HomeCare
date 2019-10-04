using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
