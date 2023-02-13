using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour{
    
    Animator transitionAnim;

    void Start() {
        transitionAnim = GetComponent<Animator>();
    }

    //Transitions and animations methods

    public void TransitionShowLevels(){
        transitionAnim.SetTrigger("ShowLevels");
    }

    public void TransitionShowCredits(){
        transitionAnim.SetTrigger("ShowCredits");
    }

    public void TransitionBackFromLevels(){
        transitionAnim.SetTrigger("BackFromLevels");
    }

    public void TransitionBackFromCredits(){
        transitionAnim.SetTrigger("BackFromCredits");
    }

    public void TransitionToGame(){
        transitionAnim.SetTrigger("ToGame");
    }

    //Change Scenes methods

    public void ChangeScene(string sceneName){
        LevelLoader.LoadLevel(sceneName);
    }

    public void ChangeLevel(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Go to a web page out of the game
    public void GoToPage(string enlace){

        Application.OpenURL(enlace);
    }
}