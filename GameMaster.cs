using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour{
    
    public GameObject restarPanel;
    public GameObject gameUI;
    public TMP_Text timerDisplay;
    public TMP_Text disclaimer;
    public float timer;
    public AudioClip gameOverMusic;

    bool hasLost;
    AudioSource audioSource;

    void Start() {
        restarPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(this.ShowDisclaimer());
    }

    void Update() {
        
        if(hasLost == false){
            timerDisplay.text = timer.ToString("F0");
        }

        if(timer < 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else{
            if(hasLost == true){
                timer = 10;
            }else{
                timer -= Time.deltaTime;
            }
        }
    }

    public void GameOver(){
        hasLost = true;
        audioSource.Stop();
        Invoke("Delay", 1.5f);
    }

    void Delay(){
        gameUI.SetActive(false);
        restarPanel.SetActive(true);
        audioSource.PlayOneShot(gameOverMusic);
    }

    IEnumerator ShowDisclaimer(){

        disclaimer.text = "Avoid planets to hit each others";
        yield return new WaitForSeconds(1.5f);
        disclaimer.text = "";
    }
}