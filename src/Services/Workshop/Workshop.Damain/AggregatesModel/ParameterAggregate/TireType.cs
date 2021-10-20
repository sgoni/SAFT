using SharedKernel.SeedWork;

namespace Workshop.Damain.AggregatesModel.ParameterAggregate
{
    public class TireType : Entity, IAggregateRoot
    {
        private string _description;

        public TireType() { }

        public TireType(string description)
        {
            _description = description;
        }

        public void SetDescription(string value)
        {
            _description = value;
        }
    }
}
