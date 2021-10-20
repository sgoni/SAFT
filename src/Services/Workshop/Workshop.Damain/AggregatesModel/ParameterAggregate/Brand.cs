using SharedKernel.SeedWork;

namespace Workshop.Damain.AggregatesModel.ParameterAggregate
{
    public class Brand : Entity, IAggregateRoot
    {
        private string _name;

        public Brand() { }

        public Brand(string name)
        {
            _name = name;
        }

        public void SetName(string value)
        {
            _name = value;
        }
    }
}
