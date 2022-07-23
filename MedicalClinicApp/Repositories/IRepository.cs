using MedicalClinicApp.Entities;

namespace MedicalClinicApp.Repositories
{
    public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T>
        where T : class, IEntity
    {
    }
}
