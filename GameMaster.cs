using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour{
    
    public GameObject restarPanel;

    void Start() {
        restarPanel.SetActive(false);
    }

    public void GameOver(){
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