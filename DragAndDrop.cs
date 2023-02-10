using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour{
    
    bool moveAllowed;
    Collider2D col;
    GameMaster gm;

    [Header("Particles")]
    [SerializeField] GameObject selectionEffect;

    void Start() {
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate() {
        
        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began){

                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if( col ==  touchedCollider){
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
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

            gm.GameOver();
            Destroy(gameObject);
        }
    }
}