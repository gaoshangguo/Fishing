using System;
using System.Collections.Generic;
using GF.Unity.Common;

namespace Fishing
{
    public class UnitConsumables : Unit
    {
        //-------------------------------------------------------------------------
        public Entity EtSrc { get; set; }
        public UnitType UnitType { get { return UnitType.Consumables; } }
        public Item Item { get; set; }
        public bool IsClient { get; set; }
        public string MadeBy { get; set; }//由谁制造
        public TbDataUnitConsumables TbDataUnitConsumables { get; set; }

        //-------------------------------------------------------------------------
        public void create(Entity et_src, bool is_client, Dictionary<byte, string> map_unit_data)
        {
            EtSrc = et_src;
            TbDataUnitConsumables = EbDataMgr.Instance.getData<TbDataUnitConsumables>(Item.TbDataItem.Id);
            if (map_unit_data == null || map_unit_data.Count == 0)
            {
                if (EtSrc != null)
                {
                    MadeBy = EtSrc.getComponentDef<DefActor>().mPropNickName.get();
                }
            }
        }

        //-------------------------------------------------------------------------
        public void destroy()
        {
        }
    }

    public class UnitConsumablesFactory<T> : TUnitFactory<T> where T : UnitConsumables, new()
    {
        public UnitConsumablesFactory(bool is_client)
            : base(is_client)
        {
        }
    }
}
