using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Vector3 cameraOffset = new Vector3(0, 50, -50);

    Quaternion offsetRotation;
   
    // you might also have some rotation speed variable
    private void Start()
    {
       offsetRotation = transform.rotation * Quaternion.Inverse(player.transform.rotation);
    
    }


    void FixedUpdate()
    {   
       
        transform.position = player.transform.position + cameraOffset;
   
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.EulerAngles(player.transform.rotation.x-0.01f, player.transform.rotation.y - 0.01f,
            player.transform.rotation.z - 0.01f) * offsetRotation, 0.03f);
       
    }
}

