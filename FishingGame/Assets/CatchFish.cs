using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
     public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("triggered!");
        float current_fish = PlayerPrefs.GetFloat("Fish");
        PlayerPrefs.SetFloat("Fish", current_fish + 1);
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
