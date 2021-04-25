﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMAS.Common.Enum
{
    public enum HealthStatus : byte
    {
        None,
        Healthy,
        NotChecked,
        NeedToBeRepaired
    }
}