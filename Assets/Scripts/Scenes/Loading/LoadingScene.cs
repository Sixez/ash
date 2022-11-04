using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public int sceneID;
    public Slider loadSlider;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation openScene = SceneManager.LoadSceneAsync(sceneID);
        while(!openScene.isDone)
        {
            float progress = openScene.progress / 0.9f;
            loadSlider.value = progress;
            yield return null;
        }
    }
}
