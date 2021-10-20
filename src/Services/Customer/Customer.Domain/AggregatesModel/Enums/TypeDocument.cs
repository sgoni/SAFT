using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.Enums
{
    public class TypeDocument 
        : Enumeration
    {
        public static TypeDocument IdentNumber = new(1, nameof(IdentNumber));
        public static TypeDocument Passport = new(2, nameof(Passport));
        public static TypeDocument DIMEX = new(3, nameof(DIMEX));
        public static TypeDocument SocialRasonNumber = new(3, nameof(SocialRasonNumber));

        public TypeDocument(int id, string name)
            : base(id, name)
        {
        }
    }
}
