using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool endingExplosion = false;
    // Start is called before the first frame update
    void Start()
    {
        endingExplosion = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void endExplosion()
    {
        endingExplosion = true;

        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
