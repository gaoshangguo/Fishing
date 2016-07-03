using System;
using System.Collections.Generic;
using System.Text;
using GF.Unity.Common;

namespace Fishing
{
    [Serializable]
    public class ItemOperateInfo
    {
        public string OperateId { get; set; }
        public string OperateName { get; set; }
        public bool IsCompoundType { get; set; }
        public EffectData EffectData { get; set; }
        public int SubOverlapNum { get; set; }
        public float CdMax { get; set; }
    }

    public class TbDataItem : EbData
    {
        //-------------------------------------------------------------------------
        public int ItemTypeId { get; private set; }
        public string UnitType { get; private set; }
        public string Name { get; private set; }
        public int MaxOverlapNum { get; private set; }
        public string Icon { get; private set; }
        public string Desc { get; private set; }
        public ItemOperateInfo MainOperateInfo { get; private set; }

        //-------------------------------------------------------------------------
        public override void load(EbPropSet prop_set)
        {
            ItemTypeId = prop_set.getPropInt("I_ItemTypeId").get();
            Name = prop_set.getPropString("T_Name").get();
            MaxOverlapNum = prop_set.getPropInt("I_MaxOverlapNum").get();
            Icon = prop_set.getPropString("T_Icon").get();
            Desc = prop_set.getPropString("T_Desc").get();
            UnitType = prop_set.getPropString("T_UnitType").get();

            int prop_int = prop_set.getPropInt("I_OperateId").get();
            if (prop_int > 0)
            {
                MainOperateInfo = new ItemOperateInfo();
                MainOperateInfo.OperateId = ((_eOperateType)prop_int).ToString();
                MainOperateInfo.EffectData = new EffectData();
                TbDataOperateType operate_type = EbDataMgr.Instance.getData<TbDataOperateType>(prop_int);
                MainOperateInfo.EffectData.EffectId = operate_type.OperateEffectId;
                MainOperateInfo.OperateName = operate_type.OperateName;
                MainOperateInfo.SubOverlapNum = prop_set.getPropInt("I_SubOverlapNum").get();
                MainOperateInfo.CdMax = prop_set.getPropFloat("R_CdMax").get();
            }
        }
    }
}
