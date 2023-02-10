using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToPlanet : MonoBehaviour{
    
    [Header("Shooting")]
    [SerializeField] Transform shotPos;
    [SerializeField] GameObject projectile;
    [SerializeField] float startTimeBtwShot;
    float timeBtwShot;

    void Update() {
        
        if(timeBtwShot <= 0){

            Instantiate(projectile, shotPos.position, Quaternion.identity);
            timeBtwShot = startTimeBtwShot;
        }else{

            timeBtwShot -= Time.deltaTime;
        }
    }
}