using UnityEditor;

namespace Editor.Utils.PlayerPrefs
{
    public class PlayerPrefsUtil
    {
        [MenuItem("utils/player prefs/clear")]
        public static void Clear()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
            UnityEngine.PlayerPrefs.Save();
        }
    }
}