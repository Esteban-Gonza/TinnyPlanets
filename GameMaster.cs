using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour{
    
    public GameObject restarPanel;
    public TMP_Text timerDisplay;
    public float timer;
    bool hasLost;


    void Start() {
        restarPanel.SetActive(false);
    }

    void Update() {
        
        if(hasLost == false){
            timerDisplay.text = timer.ToString("F0");
        }

        if(timer < 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else{
            timer -= Time.deltaTime;
        }
    }

    public void GameOver(){
        hasLost = true;
        Invoke("Delay", 1.5f);
    }

    void Delay(){
        restarPanel.SetActive(true);
    }

    public void GoToGameScene(){
        SceneManager.LoadScene("FirstLevel");
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}