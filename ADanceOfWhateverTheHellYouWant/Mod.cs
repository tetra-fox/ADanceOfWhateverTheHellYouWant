using Harmony;
using MelonLoader;
using UnityEngine;

namespace ADanceOfWhateverTheHellYouWant
{
    public class BuildInfo
    {
        public const string Name = "A Dance of Whatever the Hell You Want";
        public const string Author = "tetra";
        public const string Version = "1.0.0";
        public const string DownloadLink = "https://github.com/tetra-fox/ADanceOfWhateverTheHellYouWant/releases/download/1.0.0/ADanceOfWhateverTheHellYouWant.dll";
    }

    public class Mod : MelonMod
    {
        private static void ColorPlanet(scrPlanet planet, Color color)
        {
            //MelonLogger.Msg($"Set {(planet.isRed ? "red" : "blue")} to {color.ToHex()}");
            planet.SetCoreColor(color);
            planet.SetPlanetColor(color);
            planet.SetTailColor(color);
        }

        [HarmonyPatch(typeof(scrPlanet), "LoadPlanetColor")]
        private class LoadPlanetColorPatch
        {
            private static void Postfix(scrPlanet __instance)
            {
                __instance.EnableCustomColor();
                ColorPlanet(__instance, __instance.isRed ? Utils.HexToUnityColor(Settings.Red) : Utils.HexToUnityColor(Settings.Blue));
            }
        }

        [HarmonyPatch(typeof(scrLogoText), "UpdateColors")]
        private class UpdateColorsPatch
        {
            private static void Postfix(scrLogoText __instance)
            {
                __instance.ColorLogo(Utils.HexToUnityColor(Settings.Red), true);
                __instance.ColorLogo(Utils.HexToUnityColor(Settings.Blue), false);
            }
        }

        public override void OnApplicationStart() => Settings.Register();

        // for ez color previewing
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) => Settings.Apply();

        public override void OnPreferencesLoaded() => Settings.Apply();

        public override void OnPreferencesSaved() => Settings.Apply();
    }
}