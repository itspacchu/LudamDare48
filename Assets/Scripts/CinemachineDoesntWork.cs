using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineDoesntWork : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform toFollow;
    public float lerpAmount;
    public float RotLerpAmount;
    
    public Vector3 FollowOffset;
    public Vector3 RotationOffsetEulers;


    // Update is called once per frame
    void Update()
    {
        { //for Translation

            this.transform.position = Vector3.Lerp(this.transform.position , toFollow.transform.position + FollowOffset ,Time.deltaTime * lerpAmount);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation , toFollow.transform.rotation * Quaternion.Euler(RotationOffsetEulers) , Time.deltaTime * RotLerpAmount);


        }
    }
}
