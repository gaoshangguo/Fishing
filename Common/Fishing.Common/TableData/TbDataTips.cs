using System;
using System.Collections.Generic;
using GF.Unity.Common;

namespace Fishing
{
    public class TbDataTips : EbData
    {
        //-------------------------------------------------------------------------
        public string Content { get; private set; }
        public TipsType TipsType { get; private set; }

        //-------------------------------------------------------------------------
        public override void load(EbPropSet prop_set)
        {
            Content = prop_set.getPropString("Content").get();
            TipsType = (TipsType)prop_set.getPropInt("TipType").get();
        }
    }
}
