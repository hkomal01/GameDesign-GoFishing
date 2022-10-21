using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        PlayerPrefs.SetFloat("Money", 0);
        PlayerPrefs.SetFloat("Fish", 0);
        PlayerPrefs.SetFloat("Fish_com", 0);
        PlayerPrefs.SetFloat("Fish_3", 0);


        PlayerPrefs.SetFloat("RodLevel", 1);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
