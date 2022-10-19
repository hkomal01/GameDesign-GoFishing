using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject hook;
    //public float cameraHeight = 20.0f;

    void Update()
    {
        Vector3 pos = hook.transform.position;
        pos.z = -20;
        transform.position = pos;
    }
}
