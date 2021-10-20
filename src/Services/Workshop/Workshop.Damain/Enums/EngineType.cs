using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class EngineType
        : Enumeration
    {
        public static EngineType Diesel = new(1, nameof(Diesel));
        public static EngineType Electrico = new(3, nameof(Electrico));
        public static EngineType Gasolina = new(2, nameof(Gasolina));
        public static EngineType Hidrogeno = new(4, nameof(Hidrogeno));

        public EngineType(int id, string name) : base(id, name) { }
    }
}