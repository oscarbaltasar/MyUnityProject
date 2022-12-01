using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControllerPawn : MonoBehaviour
{
    public Transform objetivo;
    public PlayerManager player_manager;
    public float attackCooldown;
    public float danyo;

    private NavMeshAgent agente;
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        attackTimer = attackCooldown;


    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = objetivo.position;

        attackTimer -= Time.deltaTime;
        if (agente.velocity == Vector3.zero)
        {
            if (attackTimer <= 0)  //Si ha pasado el tiempo entre disparos
            {
                player_manager.vida -= danyo;
                attackTimer = attackCooldown;
            }
        } else
        {
            attackTimer = attackCooldown;
        }
    }
}
