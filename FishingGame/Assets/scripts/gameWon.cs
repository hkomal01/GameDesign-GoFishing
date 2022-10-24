using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameWon : MonoBehaviour
{
    public GameObject commonText;
    private int commonCount;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("game won");
        getCommon();
    }

    public void getCommon()
    {
        Debug.Log("start of getCommon");
        commonCount = (int) PlayerPrefs.GetFloat("Fish_com");
        Debug.Log(commonCount);
        Text common = commonText.GetComponent<Text>();
        common.text = "" + commonCount;
        Debug.Log("Common count: ");
        Debug.Log(common.text);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("menu");
    }

    public void KeepPlaying() {
        SceneManager.LoadScene("Game");
    }
}
