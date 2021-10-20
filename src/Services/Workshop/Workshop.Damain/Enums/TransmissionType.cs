using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class TransmissionType
        : Enumeration
    {
        public static TransmissionType FullTraction = new(1, nameof(FullTraction));
        public static TransmissionType FrontWheel = new(2, nameof(FrontWheel));
        public static TransmissionType RearWheel = new(3, nameof(RearWheel));

        public TransmissionType(int id, string name) : base(id, name) { }
    }
}
