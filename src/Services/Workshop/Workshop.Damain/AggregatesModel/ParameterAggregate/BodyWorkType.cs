using SharedKernel.SeedWork;

namespace Workshop.Damain.AggregatesModel.ParameterAggregate
{
    public class BodyWorkType : Entity, IAggregateRoot
    {
        private string _description;

        public BodyWorkType() { }

        public BodyWorkType(string description)
        {
            _description = description;
        }

        public void SetDescription(string value)
        {
            _description = value;
        }
    }
}
