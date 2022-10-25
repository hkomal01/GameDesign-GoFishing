using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameWon : MonoBehaviour
{
    public GameObject commonText;
    private int commonCount;
    public GameObject uncommonText;
    private int uncommonCount;
    public GameObject rareText;
    private int rareCount;
    public GameObject legendaryText;
    private int legendaryCount;
    public GameObject timeText;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = PlayerPrefs.GetFloat("Timer");
        getCounts();
    }

    public void getCounts()
    {
        commonCount = (int) PlayerPrefs.GetFloat("Fish_comCount");
        Text common = commonText.GetComponent<Text>();
        common.text += commonCount;
        uncommonCount = (int)PlayerPrefs.GetFloat("FishCount");
        Text uncommon = uncommonText.GetComponent<Text>();
        uncommon.text += uncommonCount;

        rareCount = (int)PlayerPrefs.GetFloat("Fish_3Count");
        Text rare = rareText.GetComponent<Text>();
        rare.text += rareCount;
        legendaryCount = (int)PlayerPrefs.GetFloat("Fish_5Count");
        Text legendary = legendaryText.GetComponent<Text>();
        legendary.text += legendaryCount;


        
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        Text timerTextB = timeText.GetComponent<Text>();
        timerTextB.text = string.Format("{0:00}:{1:00}", 14 - minutes, 59 - seconds);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("menu");
    }

    public void KeepPlaying() {
        float timer = 0;
        PlayerPrefs.SetFloat("Timer", timer);
        SceneManager.LoadScene("Game");
    }
}
