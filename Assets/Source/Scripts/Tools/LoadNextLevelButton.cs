using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevelButton : MonoBehaviour
{
    private Button _selfButton;

    private void Awake()
    {
        _selfButton = GetComponent<Button>();
        Debug.Log("Удалить после добавления аналитики.");
    }

    private void OnEnable()
    {
        _selfButton.onClick.AddListener(LoadNextLevel);
    }

    private void OnDisable()
    {
        _selfButton.onClick.RemoveListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneIndex == SceneManager.sceneCountInBuildSettings)
            sceneIndex = 1;
        
        SceneManager.LoadScene(sceneIndex);
    }
}