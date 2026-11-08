using Ji2Core.Reactive;

namespace Game.Currency
{
    public interface ICurrency
    {
        CurrencyId Id { get; }
        IReactiveProperty<int> Current { get; }
    }
}