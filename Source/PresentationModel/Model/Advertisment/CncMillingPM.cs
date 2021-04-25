using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMAS.Common.Enum;
using IMAS.Localization.Attribute;
using IMAS.Validation.Attribute;

namespace IMAS.PresentationModel.Model.Advertisment
{
    public class CncMillingPM : MachineryPM
    {
        [LocalizedName]
        public int? AxisNumber { get; set; }
        [LocalizedName]
        public int? TableWidth { get; set; }
        [LocalizedName]
        public int? TableHeight { get; set; }
        [LocalizedName]
        public TableType TableType { get; set; }
        [LocalizedName]
        public BodyType BodyType { get; set; }
        [LocalizedName]
        public int? MainEngingePower { get; set; }
        [LocalizedName]
        public HavingEnum SpindleGearbox { get; set; }
        [LocalizedName]
        public int? SpindleRound { get; set; }
        [LocalizedName]
        public HavingEnum HasACAxisEngine { get; set; }
        [LocalizedName]
        public HavingEnum HasDCAxisEngine { get; set; }
        [LocalizedName]
        public string EnginesMark { get; set; }
        [LocalizedName]
        public string EngineDriversMark { get; set; }
        [LocalizedName]
        public HavingEnum HasBalanceWeight { get; set; }
        [LocalizedName]
        public HavingEnum HasHydraulicBalanceSystem { get; set; }
        [LocalizedName]
        public ToolsHolderType ToolsHolderType { get; set; }
        [LocalizedName]
        public int? ToolsCountSimultaneousChange { get; set; }
        [LocalizedName]
        public HavingEnum HasSoapWaterSystem { get; set; }
        [LocalizedName]
        public HavingEnum HasToolCenterSoapWater { get; set; }
        [LocalizedName]
        public HavingEnum HasFourthAxis { get; set; }
        [LocalizedName]
        public HavingEnum HasClamp { get; set; }
        [LocalizedName]
        public HavingEnum HasComputer { get; set; }
        [LocalizedName]
        public HavingEnum HasAirPump { get; set; }
    }
}
