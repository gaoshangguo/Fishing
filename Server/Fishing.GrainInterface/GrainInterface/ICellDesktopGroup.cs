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

    public interface ICellDesktopGroup : IGrainWithGuidKey
    {
        //---------------------------------------------------------------------
        // 初始化桌子信息
        Task s2sSetupDesktop(DesktopInfo desktop_info);
    }
}
