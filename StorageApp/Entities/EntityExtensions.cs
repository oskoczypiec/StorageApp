using System.Text.Json;

namespace StorageApp.Entities
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Copying by serializing and deserializing object
        /// IEntity type ensures that this method can be called only for items of IEntity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemToCopy"></param>
        /// <returns></returns>
        public static T? Copy<T>(this T itemToCopy) where T: IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
