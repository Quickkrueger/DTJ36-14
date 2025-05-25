using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadGivenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
