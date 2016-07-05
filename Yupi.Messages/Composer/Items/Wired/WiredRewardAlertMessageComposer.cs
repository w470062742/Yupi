﻿using System;
using Yupi.Protocol.Buffers;

namespace Yupi.Messages.Wired
{
	public class WiredRewardAlertMessageComposer : AbstractComposer<int>
	{
		public override void Compose (Yupi.Protocol.ISender session, int status)
		{
			using (ServerMessage message = Pool.GetMessageBuffer (Id)) {
				message.AppendInteger(status); // TODO Use enum
				session.Send (message);
			}
		}
	}
}
