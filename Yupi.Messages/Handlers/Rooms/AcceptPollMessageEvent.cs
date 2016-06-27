﻿using System;
using Yupi.Emulator.Game.Polls;

namespace Yupi.Messages.Rooms
{
	public class AcceptPollMessageEvent : AbstractHandler
	{
		public override void HandleMessage (Yupi.Emulator.Game.GameClients.Interfaces.GameClient session, Yupi.Protocol.Buffers.ClientMessage request, Router router)
		{
			uint pollId = request.GetUInt32();
			// TODO Unchecked array access!
			Poll poll = Yupi.GetGame().GetPollManager().Polls[pollId];

			router.GetComposer<PollQuestionsMessageComposer> ().Compose (session, poll);
		}
	}
}
