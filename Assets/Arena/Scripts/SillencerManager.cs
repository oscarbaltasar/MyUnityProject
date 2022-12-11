using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SillencerManager : MonoBehaviour
{
    public GameObject targetWeapon;
    public GameObject newPosition;

    public bool isVRHolding = false;
    private bool isAttached = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttached)
        {
            transform.position = newPosition.transform.position;
            transform.eulerAngles = newPosition.transform.eulerAngles;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = targetWeapon.transform;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(isVRHolding && collider.gameObject == targetWeapon)
        {
            targetWeapon.GetComponent<AudioSource>().enabled = false;

            isAttached = true;
            GetComponent<XRGrabInteractable>().enabled = false;
        }
    }

    public void getVRInput(bool input)
    {
        isVRHolding = input;
    }
}
