// Copyright (c) Cragon. All rights reserved.

namespace Fishing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
    using Orleans;

    public interface ICellPlayerObserver : IGrainObserver
    {
        //---------------------------------------------------------------------
        void s2cNotify(MethodData method_data);
    }
}
