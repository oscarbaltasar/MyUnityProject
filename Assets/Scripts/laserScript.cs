using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		//laserLine.SetWidth (.2f, .2f);
        laserLine.startWidth = .2f;
        laserLine.endWidth = .2f;
    }

    // Update is called once per frame
    void Update () {
		laserLine.SetPosition (0, startPoint.position);
		
        
		Vector3 fromPosition = startPoint.position;
        Vector3 toPosition = endPoint.position;
        Vector3 direction = toPosition - fromPosition;
		if (Physics.Raycast(startPoint.position, direction, out hit))
        {
            laserLine.SetPosition(1, hit.point);
            //print("ray just hit the gameobject: " + hit.collider.gameObject.name);
        } else
		{
            laserLine.SetPosition(1, endPoint.position);
        }
    }
}
