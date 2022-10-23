using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchFish : MonoBehaviour
{
    public GameHandler gameHandlerObj;

    private bool hasFish;
    private List<GameObject> fishCaught = new List<GameObject>();

    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "fish" || other.gameObject.tag == "fish_common" 
            || other.gameObject.tag == "fish_3")
        {
            Debug.Log("Has Fish");
            hasFish = true;
            //GameObject fish = Instantiate(other.gameObject);
            fishCaught.Add(other.gameObject);
            
        }
        if (other.gameObject.tag == "waterTop" && hasFish)
        {
            Debug.Log("Catch Fish Triggered!");
            for (int i = 0; i < fishCaught.Count; i++)
            {
                gameHandlerObj.CatchFish(fishCaught[i].tag);
            }
            if (PlayerPrefs.GetFloat("FishingSessionsRemaining") > 1)
            {
                PlayerPrefs.SetFloat("FishingSessionsRemaining", PlayerPrefs.GetFloat("FishingSessionsRemaining") - 1);
            }
            else
            {
                Debug.Log("You have fished the maximum number of times! You Lose!");
                Application.Quit();
            }
            SceneManager.LoadScene("boat");
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting from CatchFish!");
        hasFish = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
