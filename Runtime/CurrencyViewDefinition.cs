using UnityEngine;

namespace Game.Currency
{
    [CreateAssetMenu(menuName = "Game/Currency/View Definition", fileName = "CurrencyViewDefinition")]
    public sealed class CurrencyViewDefinition : ScriptableObject
    {
        public CurrencyId Id;
        public Sprite Icon;
    }
}
