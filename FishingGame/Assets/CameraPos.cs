using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject player;
    //public float cameraHeight = 20.0f;

    void Update()
    {
        Vector3 pos = player.transform.position;
        //pos.z += cameraHeight;
        pos.z = -20;
        transform.position = pos;
    }
}
