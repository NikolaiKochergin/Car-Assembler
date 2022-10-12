using System.Collections;
using Agava.YandexGames;
using UnityEngine;

namespace CarAssembler
{
    public class YandexInitializator : MonoBehaviour
    {
        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif

            // Always wait for it if invoking something immediately in the first scene.
            yield return YandexGamesSdk.Initialize();

            while (true)
            {
                yield return new WaitForSecondsRealtime(0.25f);
            }
        }
    }
}