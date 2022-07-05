namespace Movie_Admin_App.IServices
{
    public interface IGenericPersonService<T>
    {
        public IQueryable<T> GetById(int id);

        public IQueryable<T> FindAllByAlphabet(string ch, int page);

        public IQueryable<T> FindAllBySearch(string v, int page);

        public void Add(T entity);

        public void Delete(T entity);

        public void UpdateImage(T entity, IFormFile file);

        public void SaveChanges();
    }
}
