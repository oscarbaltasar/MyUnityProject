using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public float vida;
    public float puntuacion;
    public TextMeshProUGUI roundText;

    private float vidaInicial;

    void Start()
    {
        vidaInicial = vida;
    }

    private void Update()
    {
        if(vida <= 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        roundText.text = ((int)vida).ToString();
    }

    public void ResetHealth()
    {
        vida = vidaInicial;
    }
}
