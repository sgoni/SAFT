using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.BankingAggregate
{
    public class Bank : Entity, IAggregateRoot
    {
        private string _description;
        private string _phone;

        public string Name { get; private set; }

        public Bank() { }

        public Bank(string bankName, string description, string phone) : this()
        {
            Name = bankName;
            _description = description;
            _phone = phone;
        }

        public void SetName(string value)
        {
            this.Name = value;
        }

        public void SetPhone(string value)
        {
            this._phone = value;
        }

        public void SetDescription(string value)
        {
            this._description = value;
        }
    }
}
