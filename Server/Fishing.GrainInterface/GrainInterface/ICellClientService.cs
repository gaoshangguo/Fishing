// Copyright (c) Cragon. All rights reserved.

namespace Fishing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
    using Orleans;
    using GF.Unity.Common;

    // Client无状态服务
    public interface ICellClientService : IGrainWithIntegerKey
    {
        //---------------------------------------------------------------------
        // 客户端请求
        Task<MethodData> c2sRequest(MethodData method_data);
    }
}
