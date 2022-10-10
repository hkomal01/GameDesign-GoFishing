using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
     public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("triggered!");
        float current_money = PlayerPrefs.GetFloat("money");
        PlayerPrefs.SetFloat("money", current_money + 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting from CatchFish!");
        if(!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetFloat("money", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
