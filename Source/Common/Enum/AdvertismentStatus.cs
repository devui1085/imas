using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMAS.Common.Enum
{
    [Flags]
    public enum AdvertismentStatus : Byte
    {
        None = 0,
        Pending = 1,
        Published = 2,
        Saled = 4,
        Deactive = 8,
        Unconfirmed= 16,
        Removed = 32,
        All = Pending | Published | Saled | Deactive | Unconfirmed | Removed
    }
}
