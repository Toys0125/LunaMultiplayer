﻿using LunaClient.Base;
using LunaClient.Base.Interface;
using LunaClient.Network;
using LunaCommon.Message.Client;
using LunaCommon.Message.Data.ShareProgress;
using LunaCommon.Message.Interface;

namespace LunaClient.Systems.ShareScience
{
    public class ShareScienceMessageSender : SubSystem<ShareScienceSystem>, IMessageSender
    {
        public void SendMessage(IMessageData msg)
        {
            TaskFactory.StartNew(() => NetworkSender.QueueOutgoingMessage(MessageFactory.CreateNew<ShareProgressCliMsg>(msg)));
        }

        public void SendScienceMessage(float science, string reason)
        {
            var msgData = NetworkMain.CliMsgFactory.CreateNewMessageData<ShareProgressScienceMsgData>();
            msgData.Science = science;
            msgData.Reason = reason;
            System.MessageSender.SendMessage(msgData);
            LunaLog.Log($"Science changed to: {science} with reason: {reason}");
        }
    }
}
