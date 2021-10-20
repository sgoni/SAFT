using SharedKernel.SeedWork;

namespace Workshop.Damain.AggregatesModel.ParameterAggregate
{
    public class Model : Entity, IAggregateRoot
    {
        private string _description;

        public Model() { }

        public Model(string description)
        {
            _description = description;
        }

        public void SetDescription(string value)
        {
            _description = value;
        }
    }
}
