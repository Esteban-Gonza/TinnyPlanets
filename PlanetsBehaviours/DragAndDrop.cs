using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour{
    
    bool moveAllowed;
    bool isOnPlayScreen;
    Scene currentScene;
    Collider2D col;
    GameMaster gm;
    AudioSource audioSource;

    [Header("Particles")]
    [SerializeField] GameObject selectionEffect;
    [SerializeField] GameObject deathEffect;

    void Start() {
        
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
        currentScene = SceneManager.GetActiveScene();
    }

    void FixedUpdate() {
        
        /*if(currentScene.buildIndex != 0){
            isOnPlayScreen = true;
        }else{
            isOnPlayScreen = false;
        }*/

        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began){

                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if( col ==  touchedCollider){
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    audioSource.Play();
                    moveAllowed = true;
                }
            }
            if(touch.phase == TouchPhase.Moved){

                if(moveAllowed){
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended){

                moveAllowed = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colision) {
        
        if(colision.tag == "Planet"){

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gm.GameOver();
            Destroy(gameObject);
        }
    }
}