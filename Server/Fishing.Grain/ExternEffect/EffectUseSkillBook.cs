using System;
using System.Collections.Generic;
using System.Text;
using GF.Unity.Common;

namespace Fishing
{
    // 使用技能书
    public class EffectUseSkillBook : Effect
    {
        //-------------------------------------------------------------------------
        public override object excute(EffectMgr effect_mgr, EffectContext effect_context, string[] predefine_param, string[] effect_param)
        {
            Item item = effect_context.item;
            Entity et = effect_context.EtActor;

            return null;
        }
    }
}
