using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toiletAppear : MonoBehaviour
{
    public GameObject toiletPrefab;
    public float respawnTime = 0.02f;
    private Vector2 screenBounds;




    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(toiletTrigger());    
    }

  
    private void spawnToilet()
    {
        GameObject a = Instantiate(toiletPrefab) as GameObject;
        a.transform.position = new Vector2(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator toiletTrigger()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnToilet();
        }
    }

}
