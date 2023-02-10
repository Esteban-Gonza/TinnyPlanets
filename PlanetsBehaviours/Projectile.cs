using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    
    [SerializeField] float speed;
    GameObject[] planets;
    Vector2 target;
    GameMaster gm;

    void Start() {
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        planets = GameObject.FindGameObjectsWithTag("Planets");

        int random = Random.Range(0, planets.Length);
        target = planets[random].transform.position;
    }

    void Update() {
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target) < 2f){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Planet")){

            gm.GameOver();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}