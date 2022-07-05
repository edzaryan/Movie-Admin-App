using Movie_Admin_App.Custom;
using Movie_Admin_App.Data;
using Movie_Admin_App.Data.enums;
using Movie_Admin_App.IServices;
using Movie_Admin_App.Models.PersonModels;

namespace Movie_Admin_App.Services
{
    public class PersonService<T> : IGenericPersonService<T> where T : Person
    {
        private readonly ApplicationContext _context;
        private readonly FileOperations _fileOperations;

        public PersonService(ApplicationContext context, FileOperations fileOperations)
        {
            _context = context;
            _fileOperations = fileOperations;
        }


        public IQueryable<T> GetById(int id)
        {
            return _context.Set<T>()
                        .Where(p => p.Id == id);
        }

        public IQueryable<T> FindAllByAlphabet(string ch, int page)
        {
            return _context.Set<T>()
                        .Where(p => p.FirstName.StartsWith(ch))
                        .Skip(page * 16 - 16)
                        .Take(16)
                        .OrderBy(p => p.FirstName + p.LastName);
        }

        public IQueryable<T> FindAllBySearch(string v, int page)
        {
            return _context.Set<T>()
                        .Where(p => (p.FirstName + p.LastName).Contains(v))
                        .Skip(page * 16 - 16)
                        .Take(16)
                        .OrderBy(p => p.FirstName + p.LastName);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void UpdateImage(T entity, IFormFile file)
        {
            string? imageName = entity.Image;

            if (imageName != null)
            {
                _fileOperations.DeleteFile(imageName, FileCategory.Image);
            }

            imageName = CustomFunctions.GetUniqueFileName(10, Path.GetExtension(file.FileName));

            _fileOperations.UploadFile(file, imageName, FileCategory.Image);

            entity.Image = imageName;
        }

        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }

    }
}
