﻿using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IMAS.Common.Enum;
using IMAS.Common.Globalization;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model
{
    public class NotificationPM
    {
        public int Id { get; set; }

        public bool IsRead { get; set; }

        [ScriptIgnore]
        public DateTime CreateDate { get; set; }

        [ScriptIgnore]
        public NotificationType Type { get; set; }

        public string CreateDateString => CreateDate.ToPersianDate("g");

        public string Message { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}
