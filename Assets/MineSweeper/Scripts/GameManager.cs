using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool endingExplosion = false;

    public int minas;
    public int score = 0;
    static public bool endingWin = false;
    // Start is called before the first frame update
    void Start()
    {
        endingExplosion = false;

        GameObject[] bloques;
        bloques = GameObject.FindGameObjectsWithTag("Bloque");

        foreach (GameObject bloque in bloques)
        {

            if (bloque.GetComponent<Bloque>().mina)
            {
                minas++;
            }
        }
        //minas = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(minas == score)
        {
            endWin();
        }
    }

    public static void endExplosion()
    {
        endingExplosion = true;
        endingWin = false;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public static void endWin()
    {
        endingExplosion = true;
        endingWin = true;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
