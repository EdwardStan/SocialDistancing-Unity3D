using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Baba : MonoBehaviour
{
    public Transform player;
    private float moveSpeed;

    public float minSpeed;
    public float maxSpeed;
    public float SeccondsToMaxDifficulty;


    private Rigidbody2D rb;
    private Vector2 movement; 

    public GameObject restartPanel;
    public GameObject imageScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        moveSpeed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
        rb.MovePosition((Vector2)transform.position +(direction * moveSpeed *Time.deltaTime));

        float GetDifficultyPercent()
         {
                 return Mathf.Clamp01(Time.timeSinceLevelLoad / SeccondsToMaxDifficulty);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Babe")
        {
            restartPanel.SetActive(true);
            imageScore.SetActive(false);
            SCore2.pointIncreasePerSecond = 0f;
            SCore2.triggerDetected = true;
        }
        
        
    }
}
// if (player.getScore()%20){
//      moveSpeed *= factor;}