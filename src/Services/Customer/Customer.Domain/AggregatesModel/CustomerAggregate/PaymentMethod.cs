using Customer.Domain.AggregatesModel.BankingAggregate;
using Customer.Domain.Exceptions;
using SharedKernel.Exceptions;
using SharedKernel.SeedWork;
using System;

namespace Customer.Domain.AggregatesModel.CustomerAggregate
{
    public class PaymentMethod : Entity
    {
        private int? _bankRef;
        private DateTime _expiration;

        private int _cardTypeId;
        public CardType CardType { get; private set; }

        public int ClientRef { get; set; }
        public Client Client { get; set; }

        public string CardNumber { get; set; }

        public PaymentMethod() { }

        public PaymentMethod(int cardTypeId, string cardNumber, DateTime expiration, int? bankRef)
        {
            this.CardNumber = !string.IsNullOrWhiteSpace(cardNumber) ? cardNumber : throw new BaseException(nameof(cardNumber));

            if (expiration < DateTime.UtcNow)
            {
                throw new BaseException(nameof(expiration));
            }

            _bankRef = bankRef;
            _cardTypeId = cardTypeId;
            _expiration = expiration;
        }

        public bool IsEqualTo(int cardTypeId, string cardNumber, DateTime expiration)
        {
            return _cardTypeId == cardTypeId
                && this.CardNumber == cardNumber
                && _expiration == expiration;
        }
    }
}
