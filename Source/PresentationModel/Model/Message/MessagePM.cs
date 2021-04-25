using System;
using System.Web.Script.Serialization;
using IMAS.Common.Globalization;
using IMAS.Common.Enum;

namespace IMAS.PresentationModel.Model
{
    public class MessagePM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }

        [ScriptIgnore]
        public string SenderFirstName { get; set; }

        [ScriptIgnore]
        public string SenderLastName { get; set; }

        [ScriptIgnore]
        public string ReceiverFirstName { get; set; }

        [ScriptIgnore]
        public string ReceiverLastName { get; set; }


        [ScriptIgnore]
        public DateTime CreateDate { get; set; }


        public string SenderFullName => $"{SenderFirstName} {SenderLastName}";
        public string ReceiverFullName => $"{ReceiverFirstName} {ReceiverLastName}";

        public string CreateDateString => CreateDate.ToPersianDate("g");
    }
}
