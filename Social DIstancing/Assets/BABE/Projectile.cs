using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
//   public float Xdir = 0f;
//   public float Ydir = 0f;

  public float speed;
  private Transform player;
  private Vector2 target;

  void Start()
  {
      player = GameObject.FindGameObjectWithTag("HIT1").transform;
      target = new Vector2(player.position.x, player.position.y);
  }
  void Update()
  {
   transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

   if(transform.position.x == target.x && transform.position.y == target.y)
   {
       DestroyProjectile();
   }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.CompareTag("HIT1"))
      {
          DestroyProjectile();
      }
  }
  void DestroyProjectile()
  {
      Destroy(gameObject);
  }
}
