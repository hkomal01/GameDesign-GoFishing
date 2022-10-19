using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{

    public string NextLevel = "Game";

    public void OnMouseDown() {
        Debug.Log("triggered!");
        SceneManager.LoadScene (NextLevel);
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
