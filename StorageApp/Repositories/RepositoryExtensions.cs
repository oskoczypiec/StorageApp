namespace StorageApp.Repositories
{
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Creating extension method of IWriteRepository<T> instances by adding 'this' before the first argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository"></param>
        /// <param name="items"></param>
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
