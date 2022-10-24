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
    // Start is called before the first frame update
    void Start()
    {
        getCounts();
    }

    public void getCounts()
    {
        commonCount = (int) PlayerPrefs.GetFloat("Fish_com");
        Text common = commonText.GetComponent<Text>();
        common.text += commonCount;
        uncommonCount = (int)PlayerPrefs.GetFloat("Fish");
        Text uncommon = uncommonText.GetComponent<Text>();
        uncommon.text += uncommonCount;

        rareCount = (int)PlayerPrefs.GetFloat("Fish_3");
        Text rare = rareText.GetComponent<Text>();
        rare.text += rareCount;
        legendaryCount = (int)PlayerPrefs.GetFloat("Fish_5");
        Text legendary = legendaryText.GetComponent<Text>();
        legendary.text += legendaryCount;
    }

    public void PlayAgain() {
        SceneManager.LoadScene("menu");
    }

    public void KeepPlaying() {
        SceneManager.LoadScene("Game");
    }
}
