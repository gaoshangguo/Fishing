using System;
using System.Collections.Generic;
using GF.Unity.Common;

namespace Fishing
{
    public class EtLogin : EntityDef
    {
        //---------------------------------------------------------------------
        public override void declareAllComponent(byte node_type)
        {
            // All
            declareComponent<DefLogin>();
        }
    }
}
