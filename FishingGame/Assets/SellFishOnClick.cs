using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellFishOnClick : MonoBehaviour
{
    public GameHandler gameHandlerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked Sell Fish");
        gameHandlerObj.SellFish(gameObject.tag);
        
    }
}
