﻿// Copyright (c) Maila. All rights reserved.
// Licensed under the GNU AGPLv3

using System;
using System.Text.Json;

namespace Maila.Cocoa.Beans.Models.Events
{
    public class NudgeEvent : Event
    {
        public long FromId { get; }
        public long Target { get; }
        public long SubjectId { get; }
        public SubjectKind SubjectKind { get; }
        public string Action { get; }
        public string Suffix { get; }

        private NudgeEvent(long fromId, long target, long subjectId, SubjectKind subjectKind, string action, string suffix) : base("NudgeEvent")
        {
            FromId = fromId;
            Target = target;
            SubjectId = subjectId;
            SubjectKind = subjectKind;
            Action = action;
            Suffix = suffix;
        }

        internal new static NudgeEvent? Parse(JsonElement body)
        {
            try
            {
                return new(body.GetProperty("fromId").GetInt64(),
                           body.GetProperty("target").GetInt64(),
                           body.GetProperty("subjectId").GetInt64(),
                           Enum.Parse<SubjectKind>(body.GetProperty("subjectKind").GetString() ?? string.Empty),
                           body.GetProperty("action").GetString() ?? string.Empty,
                           body.GetProperty("suffix").GetString() ?? string.Empty);
            }
            catch { return null; }
        }
    }

    public enum SubjectKind
    {
        Group,
        Friend
    }
}
