using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        // if (!PlayerPrefs.HasKey("Money")) {
            PlayerPrefs.SetFloat("Money", 0);
            PlayerPrefs.SetFloat("Fish", 0);
            PlayerPrefs.SetFloat("FishCount", 0);
            PlayerPrefs.SetFloat("Fish_com", 0);
            PlayerPrefs.SetFloat("Fish_comCount", 0);
            PlayerPrefs.SetFloat("Fish_3", 0);
            PlayerPrefs.SetFloat("Fish_3Count", 0);
            PlayerPrefs.SetFloat("Fish_5", 0);
            PlayerPrefs.SetFloat("Fish_5Count", 0);
            PlayerPrefs.SetFloat("Timer", 0.0f);
            

            PlayerPrefs.SetFloat("RodLevel", 1);
            // PlayerPrefs.SetFloat("FishingSessionsRemaining", 5);
        // }


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
