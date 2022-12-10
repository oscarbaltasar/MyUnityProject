using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPositiontoModel : MonoBehaviour
{
    public Transform RightHandVR;
    public Transform RightHandModel;
    public Vector3 RightHandPositionOffset;
    public Quaternion RightHandRotationOffset;

    public Transform LeftHandVR;
    public Transform LeftHandModel;
    public Vector3 LeftHandPositionOffset;
    public Quaternion LeftHandRotationOffset;

    public Transform HeadVR;
    public Transform HeadModel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RightHandModel.position = RightHandVR.position + RightHandPositionOffset;
        RightHandModel.rotation = RightHandVR.rotation * RightHandRotationOffset;

        LeftHandModel.position = LeftHandVR.position + LeftHandPositionOffset;
        LeftHandModel.rotation = LeftHandVR.rotation * LeftHandRotationOffset;
        HeadModel.position = HeadVR.position;
        HeadModel.rotation = HeadVR.rotation;
    }
}
