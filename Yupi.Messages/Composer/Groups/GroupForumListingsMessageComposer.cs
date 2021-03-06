﻿// ---------------------------------------------------------------------------------
// <copyright file="GroupForumListingsMessageComposer.cs" company="https://github.com/sant0ro/Yupi">
//   Copyright (c) 2016 Claudio Santoro, TheDoctor
// </copyright>
// <license>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
//
//   The above copyright notice and this permission notice shall be included in
//   all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//   THE SOFTWARE.
// </license>
// ---------------------------------------------------------------------------------
namespace Yupi.Messages.Groups
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using Yupi.Model.Domain;
    using Yupi.Protocol.Buffers;
    using Yupi.Util;

    public class GroupForumListingsMessageComposer : Yupi.Messages.Contracts.GroupForumListingsMessageComposer
    {
        #region Fields

        private const int TotalPerPage = 20;

        #endregion Fields

        #region Methods

        public override void Compose(Yupi.Protocol.ISender session, int selectType, int startIndex)
        {
            using (ServerMessage message = Pool.GetMessageBuffer(Id))
            {
                message.AppendInteger(selectType);

                throw new NotImplementedException();

                /*
                List<Group> groupList = new List<Group>();

                // TODO Refactor
                switch (selectType)
                {
                case 0:
                case 1:
                    using (IQueryAdapter dbClient = Yupi.GetDatabaseManager().GetQueryReactor())
                    {
                        dbClient.SetQuery("SELECT count(id) FROM groups_forums_data WHERE forum_messages_count > 0");

                        int qtdForums = dbClient.GetInteger();

                        dbClient.SetQuery(
                            "SELECT group_id FROM groups_forums_data WHERE forum_messages_count > 0 ORDER BY forum_messages_count DESC LIMIT @startIndex, @totalPerPage;");

                        dbClient.AddParameter("startIndex", startIndex);
                        dbClient.AddParameter("totalPerPage", TotalPerPage);

                        DataTable table = dbClient.GetTable();

                        groupList.AddRange(from DataRow rowGroupData in table.Rows
                            select uint.Parse(rowGroupData["group_id"].ToString())
                            into groupId
                            select Yupi.GetGame().GetGroupManager().GetGroup(groupId));

                        message.AppendInteger(qtdForums == 0 ? 1 : qtdForums);
                        message.AppendInteger(startIndex);

                        message.AppendInteger(table.Rows.Count);

                        SerializeForumRoot(message, groupList);
                    }
                    break;

                case 2:
                    groupList.AddRange(
                        session.GetHabbo()
                        .UserGroups.Select(groupUser => Yupi.GetGame().GetGroupManager().GetGroup(groupUser.GroupId))
                        .Where(aGroup => aGroup != null && aGroup.Forum.Id != 0));

                    message.AppendInteger(groupList.Count == 0 ? 1 : groupList.Count);

                    groupList =
                        groupList.OrderByDescending(x => x.Forum.ForumMessagesCount).Skip(startIndex).Take(20).ToList();

                    message.AppendInteger(startIndex);
                    message.AppendInteger(groupList.Count);

                    SerializeForumRoot(message, groupList);
                    break;

                default:
                    message.AppendInteger(1);
                    message.AppendInteger(startIndex);
                    message.AppendInteger(0);
                    break;
                }

                session.Send (message);
                */
            }
        }

        private void SerializeForumRoot(ServerMessage message, List<Group> groupList)
        {
            foreach (Group group in groupList)
            {
                message.AppendInteger(group.Id);
                message.AppendString(group.Name);
                message.AppendString(string.Empty);
                message.AppendString(group.Badge);
                message.AppendInteger(0);
                message.AppendInteger((int) Math.Round(group.Forum.ForumScore));
                message.AppendInteger(group.Forum.GetMessageCount());
                message.AppendInteger(0);
                message.AppendInteger(0);
                message.AppendInteger(group.Forum.GetLastPost().Poster.Id);
                message.AppendString(group.Forum.GetLastPost().Poster.Name);
                message.AppendInteger((int) group.Forum.GetLastPost().Timestamp.ToUnix().SecondsSinceEpoch);
            }
        }

        #endregion Methods
    }
}