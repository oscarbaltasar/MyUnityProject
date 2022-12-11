using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorProbePosition2 : MonoBehaviour
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
        transformHelper = new Vector3(-3f, PlayerPosition.position.y - 0.9f, PlayerPosition.position.x + 55.79501f);
        ProbePosition.localPosition = transformHelper;
    }
}
