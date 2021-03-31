using UnityEngine;

namespace ADanceOfWhateverTheHellYouWant
{
    internal class Utils
    {
        public static Color HexToUnityColor(string hexCode)
        {
            return ColorUtility.TryParseHtmlString("#" + hexCode, out Color color) ? color : Color.black;
        }
    }
}