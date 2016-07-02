using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using Orleans.Concurrency;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Streams;
using GF.Unity.Common;

public enum CouchbaseQueDataType
{
    None = 0,
    InvitePlayerEnterDesktop = 100,
    GivePlayerChip = 200,
    RequestAddFriend = 300,
    ResponseAddFriend = 400,
    DeleteFriend = 500,
    RecvChatFromFriend = 600,
    RecvMail = 700,
}

namespace Ps
{
    // 玩家代理Grain，有状态，可重入
    [Reentrant]
    public class GrainCellPlayerProxy : Grain, ICellPlayerProxy
    {
        //---------------------------------------------------------------------
        public Logger Logger { get { return GetLogger(); } }
        public IGrainFactory GF { get { return this.GrainFactory; } }
        IDisposable TimerHandleUpdate { get; set; }
        PlayerServerState PlayerServerState { get; set; }// 玩家在线状态

        //---------------------------------------------------------------------
        public override Task OnActivateAsync()
        {
            DelayDeactivation(TimeSpan.FromMinutes(1));

            PlayerServerState = PlayerServerState.Offline;

            TimerHandleUpdate = RegisterTimer((_) => _update(), null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(1000));

            return base.OnActivateAsync();
        }

        //---------------------------------------------------------------------
        public override Task OnDeactivateAsync()
        {
            TimerHandleUpdate.Dispose();

            Logger.Info("OnDeactivateAsync()");

            return base.OnDeactivateAsync();
        }

        //---------------------------------------------------------------------
        // 玩家在线状态改变
        Task ICellPlayerProxy.s2sPlayerServerStateChange(PlayerServerState new_state)
        {
            PlayerServerState = new_state;

            return TaskDone.Done;
        }

        //---------------------------------------------------------------------
        // 收到好友进桌邀请
        async Task ICellPlayerProxy.s2sInvitePlayerEnterDesktop(string from_friend_etguid, string desktop_etguid,
             int sb, int bb, int player_num, int seat_num)
        {
        }

        //---------------------------------------------------------------------
        // 收到玩家赠送的筹码
        async Task ICellPlayerProxy.s2sGivePlayerChip(string from_player_etguid, int chip)
        {
        }

        //---------------------------------------------------------------------
        // 请求加好友
        async Task ICellPlayerProxy.s2sRequestAddFriend(string request_player_etguid)
        {
        }

        //---------------------------------------------------------------------
        // 响应加好友
        async Task ICellPlayerProxy.s2sResponseAddFriend(string response_player_etguid, bool agree)
        {
        }

        //---------------------------------------------------------------------
        // 删除好友
        async Task ICellPlayerProxy.s2sDeleteFriend(string friend_etguid)
        {
        }

        //---------------------------------------------------------------------
        // 好友聊天
        async Task ICellPlayerProxy.s2sRecvChatFromFriend(ChatMsgRecv msg_recv)
        {
        }

        //---------------------------------------------------------------------
        async Task ICellPlayerProxy.s2sRecvMail(MailData mail_data)
        {
        }

        //---------------------------------------------------------------------
        Task _update()
        {
            return TaskDone.Done;
        }

        //---------------------------------------------------------------------
        public IStreamProvider getStreamProvider()
        {
            IStreamProvider stream_provider = GetStreamProvider(StringDef.SMSProvider);
            return stream_provider;
        }
    }
}
