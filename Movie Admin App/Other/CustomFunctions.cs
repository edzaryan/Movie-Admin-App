namespace Movie_Admin_App.Custom
{
    public static class CustomFunctions
    {
        public static string GetUniqueFileName(int length, string extension)
        {
            Random random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            string uniqueString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            string uniquefileName = uniqueString + extension;

            return uniquefileName;
        }
    }
}
