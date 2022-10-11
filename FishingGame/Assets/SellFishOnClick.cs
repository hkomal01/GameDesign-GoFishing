using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellFishOnClick : MonoBehaviour
{
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
        float current_fish = PlayerPrefs.GetFloat("Fish");
        if (current_fish > 0) {
            PlayerPrefs.SetFloat("Fish", current_fish - 1);
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 15);
        } else {
            Debug.Log("You have no more fish to sell!!!!");
        }
    }
}
