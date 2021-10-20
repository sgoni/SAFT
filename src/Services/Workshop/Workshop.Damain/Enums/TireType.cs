using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class TireType
        : Enumeration
    {
        public static TireType Autoportante = new(1, nameof(Autoportante));
        public static TireType Diagonals = new(1, nameof(Diagonals));
        public static TireType NotNeumatic = new(1, nameof(NotNeumatic));
        public static TireType SemiNeumatic = new(1, nameof(SemiNeumatic));
        public static TireType Radial = new(1, nameof(Radial));
        public static TireType Tubetype = new(1, nameof(Tubetype));

        public TireType(int id, string name) : base(id, name) { }
    }
}
