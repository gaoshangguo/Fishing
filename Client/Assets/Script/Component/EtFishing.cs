using System;
using System.Collections.Generic;
using GF.Unity.Common;

namespace Fishing
{
    public class EtFishing : EntityDef
    {
        //-------------------------------------------------------------------------
        public override void declareAllComponent(byte node_type)
        {
            // Client
            if (node_type == (byte)NodeType.Client)
            {
                declareComponent<DefSound>();
                declareComponent<DefDataEye>();
                declareComponent<DefSysNotice>();
                declareComponent<DefNetMonitor>();
            }
        }
    }
}
