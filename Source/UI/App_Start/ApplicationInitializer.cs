using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMAS.Mapper.Initialize;
using IMAS.Validation.Initialize;

namespace IMAS.UI
{
    public static class ApplicationInitializer
    {
        public static void Initialize()
        {
            MapperInitializer.InitializModule();
            ValidationInitializer.InitializModule();
        }
    }
}