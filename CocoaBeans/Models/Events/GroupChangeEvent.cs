﻿// Copyright (c) Maila. All rights reserved.
// Licensed under the GNU AGPLv3

using System;
using System.Text.Json;

namespace Maila.Cocoa.Beans.Models.Events
{
    public class GroupNameChangeEvent : Event
    {
        public string Origin { get; }
        public string Current { get; }
        public QGroupInfo Group { get; }
        public QMemberInfo Operator { get; }

        private GroupNameChangeEvent(string origin, string current, QGroupInfo group, QMemberInfo @operator) : base("GroupNameChangeEvent")
        {
            Origin = origin;
            Current = current;
            Group = group;
            Operator = @operator;
        }

        internal new static GroupNameChangeEvent? Parse(JsonElement body)
        {
            try
            {
                QGroupInfo? group = QGroupInfo.Parse(body.GetProperty("group"));
                if (group is null)
                {
                    return null;
                }

                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("operator"), group);
                if (member is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetString() ?? string.Empty,
                           body.GetProperty("current").GetString() ?? string.Empty,
                           group,
                           member);
            }
            catch { return null; }
        }
    }

    public class GroupEntranceAnnouncementChangeEvent : Event
    {
        public string Origin { get; }
        public string Current { get; }
        public QGroupInfo Group { get; }
        public QMemberInfo Operator { get; }

        private GroupEntranceAnnouncementChangeEvent(string origin, string current, QGroupInfo group, QMemberInfo @operator) : base("GroupEntranceAnnouncementChangeEvent")
        {
            Origin = origin;
            Current = current;
            Group = group;
            Operator = @operator;
        }

        internal new static GroupEntranceAnnouncementChangeEvent? Parse(JsonElement body)
        {
            try
            {
                QGroupInfo? group = QGroupInfo.Parse(body.GetProperty("group"));
                if (group is null)
                {
                    return null;
                }

                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("operator"), group);
                if (member is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetString() ?? string.Empty,
                           body.GetProperty("current").GetString() ?? string.Empty,
                           group,
                           member);
            }
            catch { return null; }
        }
    }

    public class GroupMuteAllEvent : Event
    {
        public bool Origin { get; }
        public bool Current { get; }
        public QGroupInfo Group { get; }
        public QMemberInfo Operator { get; }

        private GroupMuteAllEvent(bool origin, bool current, QGroupInfo group, QMemberInfo @operator) : base("GroupMuteAllEvent")
        {
            Origin = origin;
            Current = current;
            Group = group;
            Operator = @operator;
        }

        internal new static GroupMuteAllEvent? Parse(JsonElement body)
        {
            try
            {
                QGroupInfo? group = QGroupInfo.Parse(body.GetProperty("group"));
                if (group is null)
                {
                    return null;
                }

                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("operator"), group);
                if (member is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetBoolean(),
                           body.GetProperty("current").GetBoolean(),
                           group,
                           member);
            }
            catch { return null; }
        }
    }

    public class GroupAllowAnonymousChatEvent : Event
    {
        public bool Origin { get; }
        public bool Current { get; }
        public QGroupInfo Group { get; }
        public QMemberInfo Operator { get; }

        private GroupAllowAnonymousChatEvent(bool origin, bool current, QGroupInfo group, QMemberInfo @operator) : base("GroupAllowAnonymousChatEvent")
        {
            Origin = origin;
            Current = current;
            Group = group;
            Operator = @operator;
        }

        internal new static GroupAllowAnonymousChatEvent? Parse(JsonElement body)
        {
            try
            {
                QGroupInfo? group = QGroupInfo.Parse(body.GetProperty("group"));
                if (group is null)
                {
                    return null;
                }

                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("operator"), group);
                if (member is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetBoolean(),
                           body.GetProperty("current").GetBoolean(),
                           group,
                           member);
            }
            catch { return null; }
        }
    }

    public class GroupAllowConfessTalkEvent : Event
    {
        public bool Origin { get; }
        public bool Current { get; }
        public bool IsByBot { get; }
        public QGroupInfo Group { get; }

        private GroupAllowConfessTalkEvent(bool origin, bool current, QGroupInfo group, bool isByBot) : base("GroupAllowConfessTalkEvent")
        {
            Origin = origin;
            Current = current;
            Group = group;
            IsByBot = isByBot;
        }

        internal new static GroupAllowConfessTalkEvent? Parse(JsonElement body)
        {
            try
            {
                QGroupInfo? group = QGroupInfo.Parse(body.GetProperty("group"));
                if (group is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetBoolean(),
                           body.GetProperty("current").GetBoolean(),
                           group,
                           body.GetProperty("isByBot").GetBoolean());
            }
            catch { return null; }
        }
    }

    public class GroupAllowMemberInviteEvent : Event
    {
        public bool Origin { get; }
        public bool Current { get; }
        public QGroupInfo Group { get; }
        public QMemberInfo Operator { get; }

        private GroupAllowMemberInviteEvent(bool origin, bool current, QGroupInfo group, QMemberInfo @operator) : base("GroupAllowMemberInviteEvent")
        {
            Origin = origin;
            Current = current;
            Group = group;
            Operator = @operator;
        }

        internal new static GroupAllowMemberInviteEvent? Parse(JsonElement body)
        {
            try
            {
                QGroupInfo? group = QGroupInfo.Parse(body.GetProperty("group"));
                if (group is null)
                {
                    return null;
                }

                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("operator"), group);
                if (member is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetBoolean(),
                           body.GetProperty("current").GetBoolean(),
                           group,
                           member);
            }
            catch { return null; }
        }
    }

    public class MemberJoinEvent : Event
    {
        public QMemberInfo Member { get; }

        private MemberJoinEvent(QMemberInfo member) : base("MemberJoinEvent")
        {
            Member = member;
        }

        internal new static MemberJoinEvent? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                return new(member);
            }
            catch { return null; }
        }
    }

    public class MemberLeaveEventKick : Event
    {
        public QMemberInfo Member { get; }
        public QMemberInfo Operator { get; }

        private MemberLeaveEventKick(QMemberInfo member, QMemberInfo @operator) : base("MemberLeaveEventKick")
        {
            Member = member;
            Operator = @operator;
        }

        internal new static MemberLeaveEventKick? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                QMemberInfo? @operator = QMemberInfo.Parse(body.GetProperty("operator"), member.Group);
                if (@operator is null)
                {
                    return null;
                }

                return new(member, @operator);
            }
            catch { return null; }
        }
    }

    public class MemberLeaveEventQuit : Event
    {
        public QMemberInfo Member { get; }

        private MemberLeaveEventQuit(QMemberInfo member) : base("MemberLeaveEventQuit")
        {
            Member = member;
        }

        internal new static MemberLeaveEventQuit? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                return new(member);
            }
            catch { return null; }
        }
    }

    public class MemberCardChangeEvent : Event
    {
        public string Origin { get; }
        public string Current { get; }
        public QMemberInfo Member { get; }
        public QMemberInfo? Operator { get; }

        private MemberCardChangeEvent(string origin, string current, QMemberInfo member, QMemberInfo? @operator) : base("MemberCardChangeEvent")
        {
            Origin = origin;
            Current = current;
            Member = member;
            Operator = @operator;
        }

        internal new static MemberCardChangeEvent? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                var @operator = body.GetProperty("operator");
                return new(body.GetProperty("origin").GetString() ?? string.Empty,
                           body.GetProperty("current").GetString() ?? string.Empty,
                           member,
                           @operator.ValueKind == JsonValueKind.Null ? null : QMemberInfo.Parse(@operator, member.Group));
            }
            catch { return null; }
        }
    }

    public class MemberSpecialTitleChangeEvent : Event
    {
        public string Origin { get; }
        public string Current { get; }
        public QMemberInfo Member { get; }

        private MemberSpecialTitleChangeEvent(string origin, string current, QMemberInfo member) : base("MemberSpecialTitleChangeEvent")
        {
            Origin = origin;
            Current = current;
            Member = member;
        }

        internal new static MemberSpecialTitleChangeEvent? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                return new(body.GetProperty("origin").GetString() ?? string.Empty,
                           body.GetProperty("current").GetString() ?? string.Empty,
                           member);
            }
            catch { return null; }
        }
    }

    public class MemberPermissionChangeEvent : Event
    {
        public GroupPermission Origin { get; }
        public GroupPermission Current { get; }
        public QMemberInfo Member { get; }

        private MemberPermissionChangeEvent(GroupPermission origin, GroupPermission current, QMemberInfo member) : base("MemberPermissionChangeEvent")
        {
            Origin = origin;
            Current = current;
            Member = member;
        }

        internal new static MemberPermissionChangeEvent? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                return new(Enum.Parse<GroupPermission>(body.GetProperty("origin").GetString() ?? string.Empty),
                           Enum.Parse<GroupPermission>(body.GetProperty("current").GetString() ?? string.Empty),
                           member);
            }
            catch { return null; }
        }
    }

    public class MemberMuteEvent : Event
    {
        public int Duration { get; }
        public QMemberInfo Member { get; }
        public QMemberInfo Operator { get; }

        private MemberMuteEvent(int duration, QMemberInfo member, QMemberInfo @operator) : base("MemberMuteEvent")
        {
            Duration = duration;
            Member = member;
            Operator = @operator;
        }

        internal new static MemberMuteEvent? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                QMemberInfo? @operator = QMemberInfo.Parse(body.GetProperty("operator"), member.Group);
                if (@operator is null)
                {
                    return null;
                }

                return new(body.GetProperty("durationSeconds").GetInt32(),
                           member,
                           @operator);
            }
            catch { return null; }
        }
    }

    public class MemberUnmuteEvent : Event
    {
        public QMemberInfo Member { get; }
        public QMemberInfo Operator { get; }

        private MemberUnmuteEvent(QMemberInfo member, QMemberInfo @operator) : base("MemberUnmuteEvent")
        {
            Member = member;
            Operator = @operator;
        }

        internal new static MemberUnmuteEvent? Parse(JsonElement body)
        {
            try
            {
                QMemberInfo? member = QMemberInfo.Parse(body.GetProperty("member"));
                if (member is null)
                {
                    return null;
                }

                QMemberInfo? @operator = QMemberInfo.Parse(body.GetProperty("operator"), member.Group);
                if (@operator is null)
                {
                    return null;
                }

                return new(member, @operator);
            }
            catch { return null; }
        }
    }
}
