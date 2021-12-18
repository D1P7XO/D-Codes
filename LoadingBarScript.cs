using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingBarScript : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    void Start()
    {
        loadingText.text = "Loading...";
        StartCoroutine(LoadNewScene(PlayerPrefs.GetString("NextSnc")));
    }
    IEnumerator LoadNewScene(string sceneName)
    {

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadingText.text = (progress * 100f).ToString("0") + "%";
            yield return null;

        }

    }

}
