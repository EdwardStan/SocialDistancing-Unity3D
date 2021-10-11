using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    public Text high;

    // Start is called before the first frame update
    void Start()
    {
        high.text = PlayerPrefs.GetInt("highscore") + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
