using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
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

    public void Load()
    {
      Debug.Log("Player had $" + PlayerPrefs.GetFloat("Money"));
      PlayerPrefs.SetFloat("RodLevel", PlayerPrefs.GetFloat("RodLevel") + 1);
      PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 15);
      Debug.Log("Player now has $" + PlayerPrefs.GetFloat("Money"));
      Debug.Log("Player's rod level is now " + PlayerPrefs.GetFloat("RodLevel"));
    }
    public void OnMouseDown()
    {
      
      Debug.Log("clicked " + gameObject.tag);
      // Load();
      gameHandlerObj.BuyRod(gameObject.tag);
    }
}

