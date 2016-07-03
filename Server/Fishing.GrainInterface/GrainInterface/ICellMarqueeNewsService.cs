// Copyright (c) Cragon. All rights reserved.

namespace Fishing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
    using Orleans;

    public interface ICellMarqueeNewsService : IGrainWithIntegerKey
    {
        //---------------------------------------------------------------------
        Task dummy();
    }
}
