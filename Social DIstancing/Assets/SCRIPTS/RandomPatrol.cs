using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RandomPatrol : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    Vector2 targetPosition;

   /* public float minSpeed;
    public float maxSpeed;*/

    public float speed;

    /*public float SeccondsToMaxDifficulty;*/



    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        targetPosition = GetRandomPosition(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if((Vector2)transform.position != targetPosition)
        {
            /*speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());*/
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else{
            targetPosition = GetRandomPosition();
        }
    }

 

    Vector2 GetRandomPosition(){
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="planet")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   /* float GetDifficultyPercent()
    {
        *//*return Mathf.Clamp01(Time.timeSinceLevelLoad / SeccondsToMaxDifficulty);*//*
    }*/
}
