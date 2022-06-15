namespace Movie_Admin_App.Custom
{
    public static class CustomFunctions
    {
        public static string UniqueStringGenerator(int length)
        {
            Random random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
