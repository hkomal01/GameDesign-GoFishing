using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      if(!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetFloat("money", 0);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load()
    {
      Debug.Log("Player has $" + PlayerPrefs.GetFloat("money"));
    }
    public void OnMouseDown()
    {
      Debug.Log("clicked");
      Load();
    }
}

