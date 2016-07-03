using System;
using System.Collections.Generic;
using System.Text;
using GF.Unity.Common;
using UnityEngine;

namespace Fishing
{
    public class ClientSysNotice<TDef> : Component<TDef> where TDef : DefSysNotice, new()
    {
        //-------------------------------------------------------------------------

        //-------------------------------------------------------------------------
        public override void init()
        {
        }

        //-------------------------------------------------------------------------
        public override void release()
        {
        }

        //-------------------------------------------------------------------------
        public override void update(float elapsed_tm)
        {
        }
    }
}
