namespace Game.Currency
{
    public interface ICurrencyRegistry
    {
        ICurrency Get(CurrencyId id);
    }
}
