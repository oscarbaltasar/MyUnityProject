using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButtonPressVR : MonoBehaviour
{
    public RoundManager roundManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Mano")
        {
            roundManager.buttonPress();
        }
    }
}
