using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthController4 : MonoBehaviour
{
    public GameObject depthBoarder;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("RodLevel") >= 5)
        {
            depthBoarder.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
