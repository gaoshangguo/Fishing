using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Orleans;
using GF.Unity.Common;

namespace Fishing
{
    public class CellConfig
    {
        //-------------------------------------------------------------------------
        SharpConfig.Configuration Cfg { get; set; }
        // 全局配置
        public int GlobalAFKLevelLimit { get; private set; }// 挂机等级限制
        // 任务配置信息
        public List<int> ListTaskStoryStartTaskId { get; private set; }

        //-------------------------------------------------------------------------
        public CellConfig()
        {
            SharpConfig.Configuration.ValidCommentChars = new char[] { '#', ';' };
            string cfg_file = ServerPath.getPathMediaRoot() + "Fishing\\Config\\CellConfig.cfg";
            Cfg = SharpConfig.Configuration.LoadFromFile(cfg_file);

            _parse();
        }

        //-------------------------------------------------------------------------
        void _parse()
        {
            // 全局配置
            var global = Cfg["Global"];
            GlobalAFKLevelLimit = global["GlobalAFKLevelLimit"].IntValue;

            // 任务配置信息
            var task = Cfg["Task"];

            ListTaskStoryStartTaskId = new List<int>();
            string[] tasks = task["ListTaskStoryStartTaskId"].StringValue.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var i in tasks)
            {
                ListTaskStoryStartTaskId.Add(int.Parse(i));
            }
        }
    }
}
