﻿using System;
using Yupi.Emulator.Data.Base.Adapters.Interfaces;

namespace Yupi.Messages.Groups
{
	public class GroupUpdateNameMessageEvent : AbstractHandler
	{
		// TODO Refactor
		public override void HandleMessage (Yupi.Emulator.Game.GameClients.Interfaces.GameClient session, Yupi.Protocol.Buffers.ClientMessage request, Router router)
		{
			uint num = request.GetUInt32();
			string text = request.GetString();
			string text2 = request.GetString();

			Group theGroup = Yupi.GetGame().GetGroupManager().GetGroup(num);

			if (theGroup?.CreatorId != session.GetHabbo().Id)
				return;

			using (IQueryAdapter queryReactor = Yupi.GetDatabaseManager().GetQueryReactor())
			{
				queryReactor.SetQuery(
					$"UPDATE groups_data SET group_name = @name, group_description = @desc WHERE id={num} LIMIT 1");
				queryReactor.AddParameter("name", text);
				queryReactor.AddParameter("desc", text2);

				queryReactor.RunQuery();
			}

			theGroup.Name = text;
			theGroup.Description = text2;

			router.GetComposer<GroupDataMessageComposer> ().Compose (session.GetHabbo().CurrentRoom, group, session.GetHabbo());
		}
	}
}

