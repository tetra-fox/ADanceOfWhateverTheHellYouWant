using MelonLoader;

namespace ADanceOfWhateverTheHellYouWant
{
    public static class Settings

    {
        private static string identifier = "Colors";
        public static string Red { get; set; } = "FF17F3";
        public static string Blue { get; set; } = "0AFCFC";

        public static void Register()
        {
            MelonPreferences.CreateCategory(identifier, BuildInfo.Name);
            MelonPreferences.CreateEntry(identifier, "Red", "FF17F3", "Red");
            MelonPreferences.CreateEntry(identifier, "Blue", "0AFCFC", "Blue");
        }

        public static void Apply()
        {
            Red = MelonPreferences.GetEntryValue<string>(identifier, "Red");
            Blue = MelonPreferences.GetEntryValue<string>(identifier, "Blue");
        }
    }
}