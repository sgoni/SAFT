using SharedKernel.SeedWork;

namespace Workshop.Damain.Enums
{
    public class NumOfDoors
        : Enumeration
    {
        public static NumOfDoors TwoDoors = new(1, nameof(TwoDoors));
        public static NumOfDoors ThreeDoors = new(2, nameof(ThreeDoors));
        public static NumOfDoors FourDoors = new(3, nameof(FourDoors));
        public static NumOfDoors FiveDoors = new(4, nameof(FiveDoors));

        public NumOfDoors(int id, string name) : base(id, name) { }
    }
}
