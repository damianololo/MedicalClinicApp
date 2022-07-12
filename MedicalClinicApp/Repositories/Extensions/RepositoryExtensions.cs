using MedicalClinicApp.Entities;

namespace MedicalClinicApp.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public  static void AddBatch<T>(this IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }

        public static void WriteAllToConsole<T>(this IRepository<T> repository) 
            where T : class, IEntity
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
