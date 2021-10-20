using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class NumOfSeats
        : Enumeration
    {
        public static NumOfSeats TwoSeats = new(1, nameof(TwoSeats));
        public static NumOfSeats ThreeSeats = new(2, nameof(ThreeSeats));
        public static NumOfSeats FourSeats = new(3, nameof(FourSeats));
        public static NumOfSeats FiveSeats = new(4, nameof(FiveSeats));
        public static NumOfSeats SixSeats = new(4, nameof(SixSeats));
        public static NumOfSeats EightSeats = new(4, nameof(EightSeats));
        public static NumOfSeats MultipleSeats = new(4, nameof(MultipleSeats));

        public NumOfSeats(int id, string name) : base(id, name) { }
    }
}
