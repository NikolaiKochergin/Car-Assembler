using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarAssembler
{
    public class SceneLoader : MonoBehaviour
    {
        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            LoadNextLevel();
            yield break;
#endif

            // Always wait for it if invoking something immediately in the first scene.
            yield return YandexGamesSdk.Initialize(LoadNextLevel);

            while (true) yield return new WaitForSecondsRealtime(0.25f);
        }

        private void LoadNextLevel()
        {
            var sceneIndex = Storage.Load().Level;

            if (sceneIndex == SceneManager.sceneCountInBuildSettings)
                sceneIndex = 1;
        
            SceneManager.LoadScene(sceneIndex);
        }
    }
}