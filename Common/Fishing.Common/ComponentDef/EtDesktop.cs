using System;
using System.Collections.Generic;
using GF.Unity.Common;

namespace Ps
{
    public class EtDesktop : EntityDef
    {
        //---------------------------------------------------------------------
        public override void declareAllComponent(byte node_type)
        {
            declareComponent<DefDesktop>();
        }
    }
}
