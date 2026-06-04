using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{
    public Button button;
    public string sceneName;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(NextScene);
    }
    void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
