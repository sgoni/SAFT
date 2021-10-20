using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class GearBoxType
        : Enumeration
    {
        public static GearBoxType FourCylinders = new(1, nameof(FourCylinders));
        public static GearBoxType FiveCylinders = new(2, nameof(FiveCylinders));
        public static GearBoxType FiveEcon = new(3, nameof(FiveEcon));
        public static GearBoxType FiveOverdr = new(4, nameof(FiveOverdr));
        public static GearBoxType SixCylinders = new(5, nameof(SixCylinders));
        public static GearBoxType SixEcon = new(6, nameof(SixEcon));
        public static GearBoxType SixOverdr = new(7, nameof(SixOverdr));
        public static GearBoxType SevenCylinders = new(8, nameof(SevenCylinders));
        public static GearBoxType Automatic = new(9, nameof(Automatic));
        public static GearBoxType DSG = new(10, nameof(DSG));
        public static GearBoxType SemiAutomatic = new(11, nameof(SemiAutomatic));
        public static GearBoxType Overdry = new(12, nameof(Overdry));

        public GearBoxType(int id, string name) : base(id, name) { }
    }
}

