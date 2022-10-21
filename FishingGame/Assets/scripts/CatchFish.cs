using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameHandler gameHandlerObj;

    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "fish" || other.gameObject.tag == "fish_common" 
            || other.gameObject.tag == "fish_3")
        {
            Debug.Log("Catch Fish Triggered!");
            gameHandlerObj.CatchFish(other.gameObject.tag);
            
        }
            
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
