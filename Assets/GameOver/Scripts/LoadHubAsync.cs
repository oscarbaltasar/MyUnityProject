using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHubAsync : MonoBehaviour
{
    private float time = 0;
    public float timeToStartLoading = 3;

    private bool loadedOnce = false;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!loadedOnce && time >= timeToStartLoading)
        {
            loadedOnce = true;
            StartCoroutine(LoadYourAsyncScene());
        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Hub");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
