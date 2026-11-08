using Ji2Core.Reactive;

namespace Game.Currency
{
    public abstract class CurrencyBase : ICurrency
    {
        public CurrencyId Id { get; }
        protected readonly ReactiveProperty<int> current = new(0);
        public IReactiveProperty<int> Current => current;

        protected CurrencyBase(CurrencyId id)
        {
            Id = id;
        }

        protected void SetValue(int value)
        {
            current.Value = value;
        }
    }
}
