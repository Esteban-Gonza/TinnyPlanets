using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour{
    
    [Space][Header("Boundaries")]
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    [Space][Header("Speed")]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    float speed;

    [Space][Header("Difficulty")]
    [SerializeField] float secondsToMaxDifficulty;

    Vector2 targetPosition;

    void Start() {

        targetPosition = GetRandomPosition();
    }

    void Update() {
        
        if((Vector2)transform.position != targetPosition){

            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }else{
            targetPosition = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition(){

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    float GetDifficultyPercent(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}