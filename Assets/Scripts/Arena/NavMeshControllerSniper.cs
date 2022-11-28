using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControllerSniper : MonoBehaviour
{
    public Transform startPoint;
    public GameObject objetivo;
    public LineRenderer laser;
    public float distanciaMaximaRandom;
    public float tiempoEntreDisparos;
    public float velocidadDeDisparo;

    private NavMeshAgent agente;
    private RaycastHit hit;
    private bool viendoaObjetivo;
    private bool hasShot;
    private int i;

    private float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        i = 1;


    }

    // Update is called once per frame
    void Update()
    {
        if (!hasShot)
        {
            Vector3 direction = objetivo.transform.position - startPoint.position;
            agente.SetDestination(objetivo.transform.position);
            if (Physics.Raycast(startPoint.position, direction, out hit))
            {
                if (hit.transform == objetivo.transform)
                {
                    agente.isStopped = true;
                    this.transform.LookAt(objetivo.transform);
                    viendoaObjetivo = true;
                }
                else
                {
                    agente.isStopped = false;
                    viendoaObjetivo = false;
                }
            }
            if (viendoaObjetivo)
            {
                shotTimer -= Time.deltaTime;
                if (shotTimer > 1)
                {
                    if (shotTimer <= velocidadDeDisparo - i + 1 - (velocidadDeDisparo / (velocidadDeDisparo * i) * (i - 1)))
                    {
                        laser.enabled = false;
                        Debug.Log(i);
                    }
                    if (shotTimer <= velocidadDeDisparo - i + 1 - (velocidadDeDisparo / (velocidadDeDisparo * i) * i))
                    {
                        laser.enabled = true;
                        i += 1;
                        
                    }
                }
                else if (shotTimer <= 1)
                {
                    laser.enabled = true;
                }
                if (shotTimer <= 0)
                {
                    //Una vez disparado
                    laser.enabled = false;
                    //seleccionamos una posicion random
                    Vector3 newDirection = new Vector3(UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom), UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom), UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom));
                    newDirection += startPoint.position;
                    agente.destination = newDirection;
                    agente.isStopped = false;
                    shotTimer = tiempoEntreDisparos; //Tiempo para el siguiente disparo
                    i = 1;
                    hasShot = true;

                }
                /*if (shotTimer <= 5)
                    laser.enabled = false;
                if (shotTimer <= 4)
                    laser.enabled = true;
                if (shotTimer <= 3.5)
                    laser.enabled = false;
                if (shotTimer <= 3)
                    laser.enabled = true;
                if (shotTimer <= 2.5)
                    laser.enabled = false;
                if (shotTimer <= 2)
                    laser.enabled = true;
                if (shotTimer <= 1.75)
                    laser.enabled = false;
                if (shotTimer <= 1.5)
                    laser.enabled = true;
                if (shotTimer <= 1.25)
                    laser.enabled = false;
                if (shotTimer <= 1)
                    laser.enabled = true;
                if (shotTimer <= 0)
                {
                    //Una vez disparado
                    laser.enabled = false;
                    //seleccionamos una posicion random
                    Vector3 newDirection = new Vector3(UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom), UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom), UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom));
                    newDirection += startPoint.position;
                    agente.destination = newDirection;
                    agente.isStopped = false;
                    shotTimer = tiempoEntreDisparos; //Tiempo para el siguiente disparo
                    hasShot = true;

                
                }*/
            }
            else
            {
                shotTimer = velocidadDeDisparo; //5 segundos que tarda en disparar
                laser.enabled = false;
            }
        } else
        {
            shotTimer -= Time.deltaTime;
            if (shotTimer <= 0)  //Si ha pasado el tiempo entre disparos
            {
                hasShot = false;
                shotTimer = velocidadDeDisparo;
            }
        }
    }
}
