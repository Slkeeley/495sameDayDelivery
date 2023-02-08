namespace SameDayDelivery.Utilities
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEditor;

    public class SceneUtility : MonoBehaviour
    {
        public static void LoadLevel(string level)
        {
            Time.timeScale = 1f;
            // Debug.Log($"Loading: {level}");
            SceneManager.LoadScene(level);
        }

        public static void LoadLevel(int levelIndex)
        {
            Time.timeScale = 1f;
            // Debug.Log($"Loading: {levelIndex.ToString()}");
            SceneManager.LoadScene(levelIndex);
        }

        public static void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public static void Pause()
        {
            Time.timeScale = 0f;
        }

        public static void Unpause()
        {
            Time.timeScale = 1f;
        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public static void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }

}