using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void SwapScene(int _sceneID)
    {
        SceneManager.LoadScene(_sceneID);
    }
}
