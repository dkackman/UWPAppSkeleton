namespace Sunlight.Model
{
    /// <summary>
    /// App settings
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// The app theme. Must be Light or Dark
        /// </summary>
        string Theme { get; set; }

        /// <summary>
        /// retreives a setting
        /// </summary>
        /// <typeparam name="T">The type of the setting</typeparam>
        /// <param name="key">The setting key</param>
        /// <param name="defaultValue">The value to return if no setting is stored or an error occurs</param>
        /// <returns></returns>
        T GetValue<T>(string key, T defaultValue);

        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="key">The setting key</param>
        /// <param name="value">The value to store</param>
        void SetValue(string key, object value);
    }
}
