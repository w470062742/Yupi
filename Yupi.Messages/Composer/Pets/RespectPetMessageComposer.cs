﻿using System;
using Yupi.Protocol.Buffers;

namespace Yupi.Messages.Pets
{
	public class RespectPetMessageComposer : AbstractComposer<int>
	{
		public override void Compose (Yupi.Protocol.ISender session, int entityId)
		{
			using (ServerMessage message = Pool.GetMessageBuffer (Id)) {
				message.AppendInteger(entityId);
				message.AppendBool(true);
				session.Send (message);
			}
		}
	}
}
