using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    public GameObject user;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(user.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLISION PALA:" + collision.gameObject.name);
    }
}
