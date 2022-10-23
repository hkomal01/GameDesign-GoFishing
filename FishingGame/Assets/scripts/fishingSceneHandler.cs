using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fishingSceneHandler : MonoBehaviour
{
    public GameObject fishText;
    public GameObject moneyText;
    public GameObject rodText;
    public GameObject optMenu;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFish();
        UpdateMoney();
        UpdateRod();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")){
                Application.Quit();
                QuitGame();
        }

        if (Input.GetKeyDown("o")) {
            if (optMenu.activeInHierarchy) {
                optMenu.SetActive(false);
                resumeGame();
            } else {
                optMenu.SetActive(true);
                pauseGame(); 
            }
        }  
        if (Input.GetKeyDown("q")) {
            SceneManager.LoadScene("menu");
        }

        if (Input.GetKeyDown("h")) {
            SceneManager.LoadScene("Game");
        }
        
    }

    public void CatchFish(string tag) {
        if (tag == "fish")
            PlayerPrefs.SetFloat("Fish", PlayerPrefs.GetFloat("Fish") + 1);
        if (tag == "fish_common")
            PlayerPrefs.SetFloat("Fish_com", PlayerPrefs.GetFloat("Fish_com") + 1);
        if (tag == "fish_3")
            PlayerPrefs.SetFloat("Fish_3", PlayerPrefs.GetFloat("Fish_3") + 1);

        UpdateFish();
    }


    void UpdateFish() {
        Text fishTextB = fishText.GetComponent<Text>();
        fishTextB.text = "" + (PlayerPrefs.GetFloat("Fish") + PlayerPrefs.GetFloat("Fish_com")
                                + PlayerPrefs.GetFloat("Fish_3"));
    }

    void UpdateMoney() {
        Text moneyTextB = moneyText.GetComponent<Text>();
        moneyTextB.text = "" + PlayerPrefs.GetFloat("Money");
    }

    void UpdateRod() {
        Text rodTextB = rodText.GetComponent<Text>();
        rodTextB.text = "" + PlayerPrefs.GetFloat("RodLevel");
    }

    public void QuitGame(){
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }

    void pauseGame() {
        Time.timeScale = 0;
    }

    public void resumeGame() {
        Time.timeScale = 1;
    }
}
