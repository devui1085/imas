using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;
using IMAS.Common.Enum;

namespace IMAS.PresentationModel.Model.Advertisment
{
    public class CncLathePM : MachineryPM
    {
        [LocalizedName]
        public HealthStatus ControlStatus { get; set; }
        [LocalizedName]
        public LatheType LatheType { get; set; }
        [LocalizedName]
        public RailType RailType { get; set; }
        [LocalizedName]
        public HavingEnum HasXAxis { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string XAxisMovementFeed { get; set; }
        [LocalizedName]
        public TableType XAxisTableType { get; set; }

        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string XAxisSpeed { get; set; }
        [LocalizedName]
        public HavingEnum HasYAxis { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string YAxisMovementFeed { get; set; }
        [LocalizedName]
        public TableType YAxisTableType { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string YAxisSpeed { get; set; }
        [LocalizedName]
        public HavingEnum HasZAxis { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string ZAxisMovementFeed { get; set; }
        [LocalizedName]
        public TableType ZAxisTableType { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string ZAxisSpeed { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 100)]
        public string SpindleEnginePower { get; set; }
        [LocalizedName]
        public string SpindleRoundPerMinute { get; set; }
        [LocalizedName]
        public HavingEnum SpindleHasGearbox { get; set; }
        [LocalizedName]
        public HavingEnum HasAcEngine { get; set; }
        [LocalizedName]
        public HavingEnum HasDcEngine { get; set; }
        [LocalizedName]
        public HavingEnum HasOtherEngine { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 200)]
        public string EngineMarks { get; set; }
        [LocalizedName]
        [StringLengthRange(0, 200)]
        public string DriveMarks { get; set; }
        [LocalizedName]
        public ToolChangerType ToolChangerType { get; set; }
        [LocalizedName]
        public int? ToolsNumber { get; set; }
        [LocalizedName]
        public int? AliveToolsNumber { get; set; }
        [LocalizedName]
        public HavingEnum HasSoapAndWaterSystem { get; set; }
    }
}
