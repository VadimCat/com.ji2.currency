using UnityEngine;

namespace Game.Currency
{
    [CreateAssetMenu(menuName = "Game/Currency/View Registry", fileName = "CurrencyViewRegistry")]
    public sealed class CurrencyViewRegistry : ScriptableObject
    {
        public CurrencyViewDefinition[] Definitions;

        public CurrencyViewDefinition Get(CurrencyId id)
        {
            if (id == null || Definitions == null)
            {
                return null;
            }

            for (int i = 0; i < Definitions.Length; i++)
            {
                var def = Definitions[i];
                if (def != null && def.Id == id)
                {
                    return def;
                }
            }

            return null;
        }
    }
}
