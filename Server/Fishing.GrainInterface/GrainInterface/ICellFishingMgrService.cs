// Copyright (c) Cragon. All rights reserved.

namespace Fishing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
    using Orleans;

    // FishingMgr管理后台无状态服务
    public interface ICellFishingMgrService : IGrainWithIntegerKey
    {
        //---------------------------------------------------------------------
        Task<string> dummy();
    }
}
