using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameHandler : MonoBehaviour
{
    public GameObject fishText;
    public GameObject moneyText;
    public GameObject errorText;
    public GameObject errorImg;

    public bool isVisible = false;



    // Start is called before the first frame update
    void Start() {
        UpdateFish();
        UpdateMoney();
        errorImg.SetActive(false);
        errorText.SetActive(false);



    }

    void Update() {
        if (isVisible) {
            StopCoroutine(DelayErrorAway());
            StartCoroutine(DelayErrorAway());
        }
        
    }

    

    public void CatchFish() {
        PlayerPrefs.SetFloat("Fish", PlayerPrefs.GetFloat("Fish") + 1);
        UpdateFish();
    }

    public void SellFish() {
        
        if (PlayerPrefs.GetFloat("Fish") > 0) {
            PlayerPrefs.SetFloat("Fish", PlayerPrefs.GetFloat("Fish") - 1);
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 15);
        } else {
            Debug.Log("Not able to sell fish");
            errorImg.SetActive(true);
            errorText.SetActive(true);
            Text errorTextB = errorText.GetComponent<Text>();
            errorTextB.text = "No more fish to sell. Go Fishing!!";
            isVisible = true;
        }

        UpdateFish();
        UpdateMoney();
    }

    public void Wait(int time) 
    {           
        System.Threading.Thread thread = new System.Threading.Thread(delegate()
        {   
            System.Threading.Thread.Sleep(time);
        });
        thread.Start();
        while (thread.IsAlive) {
        }
        // Application.DoEvents();
    }

    public void BuyRod(string rodNum) {

        switch(rodNum) {
            case "Rod2":
                if (PlayerPrefs.GetFloat("Money") >= 30) {
                    Debug.Log("able to buy rod");
                    PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 30);
                    PlayerPrefs.SetFloat("RodLevel", 2);

                    Destroy(GameObject.FindWithTag(rodNum));
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Insufficient funds to buy Level 2 Rod. Sell more Fish";
                    isVisible = true;

                }
                break;
            case "Rod3":
                if (PlayerPrefs.GetFloat("RodLevel") == 2) {
                    if (PlayerPrefs.GetFloat("Money") >= 60) {
                        Debug.Log("able to buy rod");
                        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 60);
                        PlayerPrefs.SetFloat("RodLevel", 3);

                        Destroy(GameObject.FindWithTag(rodNum));
                    } else {
                        Debug.Log("Not able to buy rod");
                        errorImg.SetActive(true);
                        errorText.SetActive(true);
                        Text errorTextB = errorText.GetComponent<Text>();
                        errorTextB.text = "Insufficient funds to buy Level 3 Rod. Sell more Fish";
                        isVisible = true;

                    }
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Must purchase Rod Level 2 first.";
                    isVisible = true;
                }
                break;
            case "Rod4":
                if (PlayerPrefs.GetFloat("RodLevel") == 3) {
                    if (PlayerPrefs.GetFloat("Money") >= 90) {
                        Debug.Log("able to buy rod");
                        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 90);
                        PlayerPrefs.SetFloat("RodLevel", 4);

                        Destroy(GameObject.FindWithTag(rodNum));
                    } else {
                        Debug.Log("Not able to buy rod");
                        errorImg.SetActive(true);
                        errorText.SetActive(true);
                        Text errorTextB = errorText.GetComponent<Text>();
                        errorTextB.text = "Insufficient funds to buy Level 4 Rod. Sell more Fish";
                        isVisible = true;

                    }
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Must purchase Rod Level 3 first.";
                    isVisible = true;
                }
                break;
            case "Rod5":
                if (PlayerPrefs.GetFloat("RodLevel") == 4) {
                    if (PlayerPrefs.GetFloat("Money") >= 120) {
                        Debug.Log("able to buy rod");
                        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 120);
                        PlayerPrefs.SetFloat("RodLevel", 5);

                        Destroy(GameObject.FindWithTag(rodNum));
                    } else {
                        Debug.Log("Not able to buy rod");
                        errorImg.SetActive(true);
                        errorText.SetActive(true);
                        Text errorTextB = errorText.GetComponent<Text>();
                        errorTextB.text = "Insufficient funds to buy Level 5 Rod. Sell more Fish";
                        isVisible = true;

                    }
                } else {
                    Debug.Log("Not able to buy rod");
                    errorImg.SetActive(true);
                    errorText.SetActive(true);
                    Text errorTextB = errorText.GetComponent<Text>();
                    errorTextB.text = "Must purchase Rod Level 4 first.";
                    isVisible = true;
                }
                break;

        }
    }

    IEnumerator DelayErrorAway() {
        yield return new WaitForSeconds(2f);
        isVisible = false;
        errorText.SetActive(false);
        errorImg.SetActive(false);

    }

    // Update is called once per frame
    void UpdateFish() {
        Text fishTextB = fishText.GetComponent<Text>();
        fishTextB.text = "" + PlayerPrefs.GetFloat("Fish");
    }

    void UpdateMoney() {
        Text moneyTextB = moneyText.GetComponent<Text>();
        moneyTextB.text = "" + PlayerPrefs.GetFloat("Money");
    }
}
