using Movie_Admin_App.Custom_Functionalities;
using Movie_Admin_App.Data.enums;
using WMPLib;

namespace Movie_Admin_App.Custom
{
    public class FileOperations : IFileOperations
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileOperations(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }


        public string UploadFile(IFormFile file, FileCategory category)
        {
            string fileName = CustomFunctions.UniqueStringGenerator(10) + Path.GetExtension(file.FileName);

            string uploadsFolder = $"{webHostEnvironment.WebRootPath}\\{category.ToString()}\\";

            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }


        public void DeleteFile(string fileName, FileCategory category)
        {
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
