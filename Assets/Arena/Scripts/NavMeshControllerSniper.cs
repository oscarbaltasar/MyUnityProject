using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControllerSniper : MonoBehaviour
{
    public Transform startPoint;
    public GameObject jugador;
    public PlayerManager player_manager;
    public float danyo;
    public Transform objetivo;
    public LineRenderer laser;
    public float distanciaMaximaRandom;
    public float tiempoEntreDisparos;
    public float velocidadDeDisparo;

    private NavMeshAgent agente;
    private RaycastHit hit;
    private bool viendoaObjetivo;
    private bool hasShot;
    private int shotInterval;

    private float shotTimer;
    private int layermask;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        shotInterval = 1;
        layermask = LayerMask.GetMask("Default");

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasShot)
        {
            Vector3 direction = jugador.transform.position - startPoint.position;
            agente.SetDestination(objetivo.position);
            if (Physics.Raycast(startPoint.position, direction, out hit, Mathf.Infinity, layermask))
            {  
                if (hit.transform == jugador.transform)
                {
                    agente.isStopped = true;
                    
                    this.transform.LookAt(jugador.transform);
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
                    if (shotTimer <= velocidadDeDisparo - shotInterval + 1 - (velocidadDeDisparo / (velocidadDeDisparo * shotInterval) * (shotInterval - 1)))
                    {
                        laser.enabled = false;
                    }
                    if (shotTimer <= velocidadDeDisparo - shotInterval + 1 - (velocidadDeDisparo / (velocidadDeDisparo * shotInterval) * shotInterval))
                    {
                        laser.enabled = true;
                        shotInterval += 1;
                        
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
                    player_manager.vida -= danyo;
                    //seleccionamos una posicion random
                    Vector3 newDirection = new Vector3(UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom), UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom), UnityEngine.Random.Range(-distanciaMaximaRandom, distanciaMaximaRandom));
                    newDirection += startPoint.position;
                    agente.destination = newDirection;
                    agente.isStopped = false;
                    shotTimer = tiempoEntreDisparos; //Tiempo para el siguiente disparo
                    shotInterval = 1;
                    viendoaObjetivo = false;
                    hasShot = true;
                }
            }
            else
            {
                shotInterval = 1;
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
