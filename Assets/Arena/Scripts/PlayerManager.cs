using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float vida;
    public float puntuacion;

    private float vidaInicial;

    void Start()
    {
        vidaInicial = vida;
    }

    public void ResetHealth()
    {
        vida = vidaInicial;
    }
}
