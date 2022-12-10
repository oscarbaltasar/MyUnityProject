using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponIgnorePlayer : MonoBehaviour
{
    public GameObject user;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(user.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
