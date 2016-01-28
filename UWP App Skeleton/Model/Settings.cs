using System;
using System.Diagnostics;

using Windows.Storage;

namespace Sunlight.Model
{
    sealed class Settings : ISettings
    {
        private readonly ApplicationDataContainer _container;
        public Settings(ApplicationDataContainer container)
        {
            _container = container;
        }

        public string Theme
        {
            get
            {
                return GetValue<string>("Theme", "Dark");
            }

            set
            {
                if (value != null && (value.Equals("Light", StringComparison.OrdinalIgnoreCase) || value.Equals("Dark", StringComparison.OrdinalIgnoreCase)))
                {
                    SetValue("Theme", value);
                }
                else
                {
                    Debug.Assert(false);
                }
            }
        }
        public T GetValue<T>(string key, T defaultValue)
        {
            try
            {
                if (_container.Values.ContainsKey(key))
                {
                    return (T)_container.Values[key];
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error deserializing setting {key} - {e.Message}");
            }
            return defaultValue;
        }

        public void SetValue(string key, object value)
        {
            _container.Values[key] = value;            
        }
    }
}
