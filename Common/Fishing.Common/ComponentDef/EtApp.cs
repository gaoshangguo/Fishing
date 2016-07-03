using System;
using System.Collections.Generic;
using GF.Unity.Common;

namespace Fishing
{
    public class EtApp : EntityDef
    {
        //---------------------------------------------------------------------
        public override void declareAllComponent(byte node_type)
        {
            declareComponent<DefApp>();
        }
    }
}
