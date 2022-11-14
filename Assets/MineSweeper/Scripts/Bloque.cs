using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

        if (mina)
        {
            //Cargar mina
            Instantiate(minaPrefav, transform.position, Quaternion.identity);
        }
        else
        {
            int num = 0;
            mVecinos.ForEach(bloque => {
                if (bloque.mina) num += 1;
            });
            Instantiate(numerosPrefav[num], transform.position, Quaternion.Euler(-90, 0, 0));
        }

    }

    //Detectar colisión con pala
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pala")
        {
            MostrarContenido();
            this.gameObject.SetActive(false);
        }
    }
}
