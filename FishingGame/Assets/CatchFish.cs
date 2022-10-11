using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameHandler gameHandlerObj;
    
    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Catch Fish Triggered!");
        gameHandlerObj.CatchFish();
            
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting from CatchFish!");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
