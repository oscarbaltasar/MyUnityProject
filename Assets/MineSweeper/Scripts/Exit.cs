using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Exit : MonoBehaviour
{
    public GameObject exitTimer;
    public float timeRemaining = 5;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        exitTimer.SetActive(true);
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining > 0)
                exitTimer.GetComponent<TMP_Text>().text = timeRemaining.ToString("F2") + "";
        }
        else
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        exitTimer.SetActive(false);
        timeRemaining = 5;
    }
}
