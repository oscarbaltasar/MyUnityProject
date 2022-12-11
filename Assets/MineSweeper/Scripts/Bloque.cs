using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Bloque : MonoBehaviour
{
    public bool mina = false;

    public float radio = 0.7f;

    private List<Bloque> mVecinos;

    private bool mMostrado;

    public GameObject minaPrefav;

    public List<GameObject> numerosPrefav;

    // Start is called before the first frame update
    void Start()
    {
        EncontrarVecinos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EncontrarVecinos()
    {
        var allBloques = GameObject.FindGameObjectsWithTag("Bloque");

        mVecinos = new List<Bloque>();

        for (int i = 0; i < allBloques.Length; i++)
        {
            var bloque = allBloques[i];
            var distance = Vector3.Distance(transform.position, bloque.transform.position);
            if (0 < distance && distance <= radio)
            {
                mVecinos.Add(bloque.GetComponent<Bloque>());
            }
        }
    }

    public void MostrarContenido()
    {
        if (mMostrado) return;

        mMostrado = true;

        string name;
        Vector3 posicicion = transform.position;
        if (mina)
        {
            
            posicicion.y *= 0f;
            //Cargar mina
            Instantiate(minaPrefav, posicicion, Quaternion.identity);
        }
        else
        {
            posicicion.y *= -2f;
            int num = 0;
            mVecinos.ForEach(bloque => {
                if (bloque.mina) num += 1;
            });
            Instantiate(numerosPrefav[num], posicicion, Quaternion.Euler(-90, 0, 0));
        }

    }

    //Detectar colisión con pala
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision= " + collision.impulse.magnitude);
        if (collision.gameObject.tag == "Pala")
        {
            //Impulso
            if (collision.gameObject.GetComponent<TwoHandsGrabInteractable>().isSelected && collision.impulse.magnitude > 0.5)
            {
                MostrarContenido();
                //this.gameObject.SetActive(false);
                GameObject pala = GameObject.Find("Pala");
                pala.GetComponent<AudioSource>().Play();
                Destroy(this.gameObject);

            }
        }
    }
}
