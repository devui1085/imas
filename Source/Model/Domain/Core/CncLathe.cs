namespace IMAS.Model.Domain.Core
{
    using IMAS.Common.Enum;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.CncLathe")]
    public partial class CncLathe : Machinery
    {
        public HealthStatus ControlStatus { get; set; }

        public LatheType LatheType { get; set; }

        public RailType RailType { get; set; }

        public HavingEnum HasXAxis { get; set; }

        [StringLength(100)]
        public string XAxisMovementFeed { get; set; }

        public TableType XAxisTableType { get; set; }

        [StringLength(100)]
        public string XAxisSpeed { get; set; }

        public HavingEnum HasYAxis { get; set; }

        [StringLength(100)]
        public string YAxisMovementFeed { get; set; }

        public TableType YAxisTableType { get; set; }

        [StringLength(100)]
        public string YAxisSpeed { get; set; }

        public HavingEnum HasZAxis { get; set; }

        [StringLength(100)]
        public string ZAxisMovementFeed { get; set; }

        public TableType ZAxisTableType { get; set; }

        [StringLength(100)]
        public string ZAxisSpeed { get; set; }

        [StringLength(100)]
        public string SpindleEnginePower { get; set; }

        public string SpindleRoundPerMinute { get; set; }

        public HavingEnum SpindleHasGearbox { get; set; }

        public HavingEnum HasAcEngine { get; set; }

        public HavingEnum HasDcEngine { get; set; }

        public HavingEnum HasOtherEngine { get; set; }

        [StringLength(200)]
        public string EngineMarks { get; set; }

        [StringLength(200)]
        public string DriveMarks { get; set; }

        public ToolChangerType ToolChangerType { get; set; }

        public int? ToolsNumber { get; set; }

        public int? AliveToolsNumber { get; set; }

        public HavingEnum HasSoapAndWaterSystem { get; set; }

        //public virtual Machinery Machinery { get; set; }
    }
}
