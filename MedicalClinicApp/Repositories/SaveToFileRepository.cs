using MedicalClinicApp.Entities;

namespace MedicalClinicApp.Repositories
{
    public class SaveToFileRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        private readonly List<T> _items = new();
        const string FileName = "Lista.txt";
        const string AuditFileName = "ListaAudit.txt";
        DateTime actualTime = DateTime.UtcNow;
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T? GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove (T item)
        {
            _items.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }
        public void EventAdd(T item)
        {
            ItemAdded?.Invoke(this, item);
        }

        public void Save()
        {
            using (var writer = File.AppendText($"{FileName}"))
            {
                foreach (var item in _items)
                {
                    writer.WriteLine(item);
                }
            using (var writer2 = File.AppendText($"{AuditFileName}"))
            {
                foreach (var item in _items)
                {
                    writer2.WriteLine($"{actualTime}{EventAdd}{item}");
                }
            }
            }
        }
        public void Display()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        //public void DisplayFromFile()
        //{
        //    using (var reader = File.OpenText($"{FileName}"))
        //    {
        //        _items.Clear();
        //        var line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            var item = line;
        //            _items.Add(item);
        //            line = reader.ReadLine();
        //        }
        //    }
        //}
    }
}
