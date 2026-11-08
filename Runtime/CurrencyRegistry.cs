using System.Collections.Generic;

namespace Game.Currency
{
    public sealed class CurrencyRegistry : ICurrencyRegistry
    {
        private readonly Dictionary<CurrencyId, ICurrency> _currencies = new();

        public CurrencyRegistry(IEnumerable<ICurrency> currencies)
        {
            if (currencies == null)
            {
                return;
            }

            foreach (var currency in currencies)
            {
                if (currency?.Id == null)
                {
                    continue;
                }

                _currencies[currency.Id] = currency;
            }
        }

        public ICurrency Get(CurrencyId id)
        {
            if (id == null)
            {
                return null;
            }

            return _currencies.TryGetValue(id, out var currency) ? currency : null;
        }
    }
}
