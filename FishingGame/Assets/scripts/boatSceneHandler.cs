using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class boatSceneHandler : MonoBehaviour
{

    public GameObject fishText;
    public GameObject moneyText;
    public GameObject rodText;
    public GameObject timerText;
    public GameObject optMenu;
    public GameObject textF;
    float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        UpdateFish();
        UpdateMoney();
        UpdateRod();
        timer = PlayerPrefs.GetFloat("Timer");
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateTime();
        if (Mathf.FloorToInt(timer / 60.0f) == 15) {
            SceneManager.LoadScene("GameLose");
        }

        if (Input.GetKey("escape")){
                Application.Quit();
                QuitGame();
        }

        if (Input.GetKeyDown("o")) {
            if (optMenu.activeInHierarchy) {
                optMenu.SetActive(false);
                textF.SetActive(true);
                resumeGame();
            } else {
                optMenu.SetActive(true);
                textF.SetActive(false);
                pauseGame(); 
            }
        }  
        if (Input.GetKey("q")) {
            SceneManager.LoadScene("menu");
        }
        if (Input.GetKey("f")) {
            SceneManager.LoadScene("SamFishing");
        }
        if (Input.GetKey("h")) {
            SceneManager.LoadScene("Game");
        }
    }

    void UpdateTime() {
        PlayerPrefs.SetFloat("Timer", timer);
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        Text timerTextB = timerText.GetComponent<Text>();
        timerTextB.text = string.Format("{0:00}:{1:00}", 14 - minutes, 59 - seconds);
    }


    void UpdateFish() {
        Text fishTextB = fishText.GetComponent<Text>();
        fishTextB.text = "" + (PlayerPrefs.GetFloat("Fish") + PlayerPrefs.GetFloat("Fish_com")
                                + PlayerPrefs.GetFloat("Fish_3") + PlayerPrefs.GetFloat("Fish_5"));
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
