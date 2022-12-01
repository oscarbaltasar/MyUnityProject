using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayerPosition : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
