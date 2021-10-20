using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class BodyworkType
        : Enumeration
    {
        public static BodyworkType AutoCaravana = new(1, nameof(AutoCaravana));
        public static BodyworkType Bus = new(2, nameof(Bus));
        public static BodyworkType Cabrio = new(3, nameof(Cabrio));
        public static BodyworkType Combi = new(4, nameof(Combi));
        public static BodyworkType Crossover = new(5, nameof(Crossover));
        public static BodyworkType Coupe = new(6, nameof(Coupe));
        public static BodyworkType Fastback = new(7, nameof(Fastback));
        public static BodyworkType Hatckback = new(8, nameof(Hatckback));
        public static BodyworkType Jeep = new(9, nameof(Jeep));
        public static BodyworkType Minivan = new(10, nameof(Minivan));
        public static BodyworkType MPV = new(11, nameof(MPV));
        public static BodyworkType PickUp = new(12, nameof(PickUp));
        public static BodyworkType Roadster = new(13, nameof(Roadster));
        public static BodyworkType Sedan = new(14, nameof(Sedan));
        public static BodyworkType ShootingBrake = new(15, nameof(ShootingBrake));
        public static BodyworkType Station = new(16, nameof(Station));
        public static BodyworkType SUV = new(17, nameof(SUV));
        public static BodyworkType Tourist = new(18, nameof(Tourist));

        public BodyworkType(int id, string name) : base(id, name) { }
    }
}
