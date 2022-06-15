using Movie_Admin_App.Data.enums;

namespace Movie_Admin_App.Custom_Functionalities
{
    public interface IFileOperations
    {
        string UploadFile(IFormFile file, FileCategory category);

        void DeleteFile(string fileName, FileCategory category);

        int GetVideoFileDuration(string fileName);
    }
}
