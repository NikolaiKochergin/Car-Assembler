using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagerLesson : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
