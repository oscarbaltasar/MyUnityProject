using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Mina : MonoBehaviour
{

    public GameObject contador;
    public int tiempoExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GameObject.Find("XR Origin").GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("Ground").GetComponent<Collider>(), GetComponent<Collider>());

        //Repetir funcion cada x segundos
        InvokeRepeating("CambiarContador", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CambiarContador()
    {
        contador.GetComponent<TMP_Text>().text = tiempoExplosion + "";
        tiempoExplosion -= 1;
    }

}
