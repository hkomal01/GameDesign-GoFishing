using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStore : MonoBehaviour
{
    public string NextLevel = "Store";

    public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("triggered!");
        if (other.gameObject.tag == "Player"){
            SceneManager.LoadScene (NextLevel);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}



      

