using TMPro;
using UnityEngine;


public class Mina : MonoBehaviour
{

    public GameObject contador;
    public int tiempoExplosion;
    public bool contadorOn = true;
    // Start is called before the first frame update
    void Start()
    {
        contadorOn = true;
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
        if (tiempoExplosion <= 0)
        {
            GameManager.endExplosion();
        }
        if (contadorOn) { 
            contador.GetComponent<TMP_Text>().text = tiempoExplosion + "";
            tiempoExplosion -= 1;
        }


    }

}
