using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDelay : MonoBehaviour
{
    public Transform leader;
    public float followSharpness = 0.05f;

    private Vector3 positionHelper;

    void LateUpdate()
    {
        positionHelper = new Vector3(leader.position.x, transform.position.y, transform.position.z);
        transform.position += (positionHelper - transform.position) * followSharpness;
    }
}
