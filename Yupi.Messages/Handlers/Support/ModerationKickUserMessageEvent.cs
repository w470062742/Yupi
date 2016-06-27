﻿using System;
using Yupi.Emulator.Game.Support;

namespace Yupi.Messages.Support
{
	public class ModerationKickUserMessageEvent : AbstractHandler
	{
		public override void HandleMessage (Yupi.Emulator.Game.GameClients.Interfaces.GameClient session, Yupi.Protocol.Buffers.ClientMessage request, Router router)
		{
			if (!session.GetHabbo().HasFuse("fuse_kick"))
				return;

			uint userId = request.GetUInt32();
			string message = request.GetString();

			ModerationTool.KickUser(session, userId, message, false);
		}
	}
}
