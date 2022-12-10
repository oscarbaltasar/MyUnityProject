using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorProbePosition : MonoBehaviour
{
    public Transform ProbePosition;
    public Transform PlayerPosition;

    private Vector3 transformHelper;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transformHelper = new Vector3(-59.45f, PlayerPosition.position.y, PlayerPosition.position.z);
        Debug.Log(transformHelper);
        ProbePosition.position = transformHelper;
    }
}
