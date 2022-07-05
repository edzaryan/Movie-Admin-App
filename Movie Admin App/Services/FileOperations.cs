using Movie_Admin_App.Data.enums;
using WMPLib;

namespace Movie_Admin_App.Services
{
    public class FileOperations
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileOperations(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }


        public void UploadFile(IFormFile? file, string? name, FileCategory category)
        {
            if (file == null)
            {
                throw new Exception("The file is not found");
            }

            string uploadsFolder = $"{webHostEnvironment.WebRootPath}\\{category.ToString()}\\";

            string filePath = Path.Combine(uploadsFolder, name);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }


        public void DeleteFile(string? fileName, FileCategory category)
        {
            if (fileName == null) return;

            string filePath = $"{webHostEnvironment.WebRootPath}\\{category.ToString()}\\{fileName}";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        public int GetVideoFileDuration(string fileName)
        {
            var player = new WindowsMediaPlayer();

            var clip = player.newMedia($"{webHostEnvironment.WebRootPath}\\Video\\{fileName}");

            return (int)TimeSpan.FromMinutes(clip.duration).TotalMinutes / 60;
        }

    }
}
