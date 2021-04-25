using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.CncMilling")]
    public partial class CncMilling : Machinery
    {
        public int? AxisNumber { get; set; }
        public int? TableWidth { get; set; }
        public int? TableHeight { get; set; }
        public TableType TableType { get; set; }
        public BodyType BodyType { get; set; }
        public int? MainEngingePower { get; set; }
        public HavingEnum SpindleGearbox { get; set; }
        public int? SpindleRound { get; set; }
        public HavingEnum HasACAxisEngine { get; set; }
        public HavingEnum HasDCAxisEngine { get; set; }
        public string EnginesMark { get; set; }
        public string EngineDriversMark { get; set; }
        public HavingEnum HasBalanceWeight { get; set; }
        public HavingEnum HasHydraulicBalanceSystem { get; set; }
        public ToolsHolderType ToolsHolderType { get; set; }
        public int? ToolsCountSimultaneousChange { get; set; }
        public HavingEnum HasSoapWaterSystem { get; set; }
        public HavingEnum HasToolCenterSoapWater { get; set; }
        public HavingEnum HasFourthAxis { get; set; }
        public HavingEnum HasClamp { get; set; }
        public HavingEnum HasComputer { get; set; }
        public HavingEnum HasAirPump { get; set; }
    }
}
