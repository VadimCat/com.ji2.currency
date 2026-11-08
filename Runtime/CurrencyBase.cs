using System;
using System.Collections.Generic;
using Ji2Core.Reactive;
using Newtonsoft.Json.Linq;
using Services.Saves;

namespace Game.Currency
{
    public abstract class CurrencyBase : ICurrency, ISave
    {
        public CurrencyId Id { get; }
        protected readonly ReactiveProperty<int> current = new(0);
        public IReactiveProperty<int> Current => current;
        public virtual string SaveKey => Id.name;
        public event Action DataUpdated;

        protected CurrencyBase(CurrencyId id)
        {
            Id = id;
            current.ValueChanged += HandleCurrentChanged;
        }

        protected void SetValue(int value)
        {
            current.Value = value;
        }

        public void Load(Dictionary<string, object> saveData)
        {
            if (!saveData.TryGetValue(SaveKey, out var value))
            {
                return;
            }

            LoadSaveData(value);
        }

        public object GetSave()
        {
            return GetSaveData();
        }

        protected virtual CurrencySaveData GetSaveData()
        {
            return new CurrencySaveData
            {
                Current = Current.Value
            };
        }

        protected virtual void LoadSaveData(object value)
        {
            var data = ((JObject)value).ToObject<CurrencySaveData>();
            SetValue(data.Current);
        }

        protected void NotifyDataUpdated()
        {
            DataUpdated?.Invoke();
        }

        private void HandleCurrentChanged(int _)
        {
            NotifyDataUpdated();
        }

        protected class CurrencySaveData
        {
            public int Current;
        }
    }
}
