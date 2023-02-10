using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlanet : MonoBehaviour{
    
    [SerializeField] Transform otherPlanet;
    
    [SerializeField] float speed;

    void Update() {
        
        transform.position = Vector2.MoveTowards(transform.position, otherPlanet.position, speed * Time.deltaTime);
    }
}