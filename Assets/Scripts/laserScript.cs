using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;
    RaycastHit hit;

    private LayerMask layermask = -1;
    public List<string> layerstoCollide;
    // Use this for initialization
    void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		//laserLine.SetWidth (.2f, .2f);
        laserLine.startWidth = .2f;
        laserLine.endWidth = .2f;
        if (layerstoCollide.Count > 0)
        {
            layermask = 0;
            foreach (string layer in layerstoCollide)
            {
                layermask += LayerMask.GetMask(layer);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		laserLine.SetPosition (0, startPoint.position);
		
        
		Vector3 fromPosition = startPoint.position;
        Vector3 toPosition = endPoint.position;
        Vector3 direction = toPosition - fromPosition;
        if (layermask == -1)
        {
            if (Physics.Raycast(startPoint.position, direction, out hit))
            {
                laserLine.SetPosition(1, hit.point);
                //print("ray just hit the gameobject: " + hit.collider.gameObject.name);
            }
            else
            {
                laserLine.SetPosition(1, endPoint.position);
            }
        } else
        {
            if (Physics.Raycast(startPoint.position, direction, out hit, Mathf.Infinity, layermask))
            {
                laserLine.SetPosition(1, hit.point);
                //print("ray just hit the gameobject: " + hit.collider.gameObject.name);
            }
            else
            {
                laserLine.SetPosition(1, endPoint.position);
            }
        }
    }
}
