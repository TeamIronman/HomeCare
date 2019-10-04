using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
