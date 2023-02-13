using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour{
    
    Animator transitionAnim;
    public string nextLevel;

    void Start() {
        transitionAnim = GetComponent<Animator>();
    }

    //Transitions and animations methods

    public void TransitionShowLevels(){
        transitionAnim.SetTrigger("ShowLevels");
    }

    public void TransitionBackToMenu(){
        transitionAnim.SetTrigger("BackToMenu");
    }

    public void TransitionBetweenScenes(){
        transitionAnim.SetTrigger("ToGame");
    }

    //Change Scenes methods

    public void ChangeScene(string sceneName){
        LevelLoader.LoadLevel(sceneName);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}