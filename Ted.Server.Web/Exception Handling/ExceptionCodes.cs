﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ted.Server.Web
{
    public enum ExceptionCodes : int
    {
        Generic = 0,

        Authentication = 100,
        NotSuperUser=101,

    }
}
