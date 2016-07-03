using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using Orleans.Concurrency;
using Orleans.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GF.Unity.Common;

namespace Fishing
{
    // 玩家无状态服务
    [Reentrant]
    [StatelessWorker]
    public class GrainCellPlayerService : Grain, ICellPlayerService
    {
        //---------------------------------------------------------------------
        public Logger Logger { get { return GetLogger(); } }

        //---------------------------------------------------------------------
        // 玩家昵称是否已存在
        async Task<bool> ICellPlayerService.playerNickNameExist(string nick_name)
        {
            bool exist = false;

            return exist;
        }

        //---------------------------------------------------------------------
        // 玩家ID是否已存在
        async Task<bool> ICellPlayerService.playerIdExist(ulong player_id)
        {
            return false;
        }

        //---------------------------------------------------------------------
        // 根据玩家Guid获取指定玩家信息
        async Task<PlayerInfo> ICellPlayerService.getPlayerInfo(string player_etguid)
        {
            string query = string.Format(@"SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} FROM Fishing
                   WHERE entity_type='EtPlayer' and {9}=$1 LIMIT 1;"
               , "entity_guid"
               , "list_component[0].def_propset.ActorId"
               , "list_component[0].def_propset.NickName"
               , "list_component[0].def_propset.Level"
               , "list_component[0].def_propset.Icon"
               , "list_component[0].def_propset.IndividualSignature"
               , "list_component[0].def_propset.Chip"
               , "list_component[0].def_propset.Gold"
               , "list_component[0].def_propset.ProfileSkinTableId"
               , "entity_guid");

            PlayerInfo player_info = new PlayerInfo();
            player_info.player_etguid = "";
            return player_info;
        }

        //---------------------------------------------------------------------
        // 根据玩家Guid获取指定玩家信息
        async Task<PlayerInfoFriend> ICellPlayerService.getPlayerInfoFriend(string et_player_guid)
        {
            string query = string.Format(@"SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10} FROM Fishing
               WHERE entity_type='EtPlayer' and {11}=$1 LIMIT 1;"
               , "entity_guid"
               , "list_component[0].def_propset.ActorId"
               , "list_component[0].def_propset.NickName"
               , "list_component[0].def_propset.Level"
               , "list_component[0].def_propset.Experience"
               , "list_component[0].def_propset.Icon"
               , "list_component[0].def_propset.IpAddress"
               , "list_component[0].def_propset.IndividualSignature"
               , "list_component[0].def_propset.Chip"
               , "list_component[0].def_propset.Gold"
               , "list_component[0].def_propset.ProfileSkinTableId"
               , "entity_guid");

            PlayerInfoFriend player_info_ex = new PlayerInfoFriend();
            return player_info_ex;
        }

        //---------------------------------------------------------------------
        // 根据玩家Guid获取指定玩家信息
        async Task<PlayerInfoOther> ICellPlayerService.getPlayerInfoOther(string et_player_guid)
        {
            string query = string.Format(@"SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12} FROM Fishing as PlayerInfoOther
               WHERE entity_type='EtPlayer' and {13}=$1 LIMIT 1;"
               , "entity_guid"
               , "list_component[0].def_propset.ActorId"
               , "list_component[0].def_propset.NickName"
               , "list_component[0].def_propset.Icon"
               , "list_component[0].def_propset.Level"
               , "list_component[0].def_propset.Experience"
               , "list_component[0].def_propset.Chip"
               , "list_component[0].def_propset.Gold"
               , "list_component[0].def_propset.IndividualSignature"
               , "list_component[0].def_propset.ProfileSkinTableId"
               , "list_component[0].def_propset.IpAddress"
               , "list_component[0].def_propset.IsVIP"
               , "list_component[0].def_propset.VIPPoint"
               , "entity_guid");

            PlayerInfoOther player_info = new PlayerInfoOther();
            return player_info;
        }

        //---------------------------------------------------------------------
        // 获取在线玩家数
        async Task<int> ICellPlayerService.getOnlinePlayerNum()
        {
            string query = string.Format(@"SELECT COUNT(player_server_state) FROM Fishing;");

            return 0;
        }

        //---------------------------------------------------------------------
        // 随机获取一组在线玩家
        async Task<List<PlayerInfo>> ICellPlayerService.getOnlinePlayers(string except_player_etguid)
        {
            List<PlayerInfo> list_playerinfo = new List<PlayerInfo>();

            return list_playerinfo;
        }

        //---------------------------------------------------------------------
        // 搜索玩家，根据玩家Id或昵称的部分匹配
        async Task<List<PlayerInfo>> ICellPlayerService.findPlayers(string find_info)
        {
            List<PlayerInfo> list_playerinfo = new List<PlayerInfo>();

            return list_playerinfo;
        }

        //---------------------------------------------------------------------
        // 获取筹码排行榜
        async Task<List<RankingChip>> ICellPlayerService.getChipRankingList()
        {
            List<RankingChip> list_rankingchip = new List<RankingChip>();

            return list_rankingchip;
        }

        //---------------------------------------------------------------------
        // 获取积分排行榜
        async Task<List<RankingVIPPoint>> ICellPlayerService.getVIPPointRankingList()
        {
            List<RankingVIPPoint> list_rankingvippoint = new List<RankingVIPPoint>();

            return list_rankingvippoint;
        }
    }
}
