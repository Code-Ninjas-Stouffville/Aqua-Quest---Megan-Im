using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text GameTimerText;
    public float GameTimer = 30.0f;
    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (pause == false)
        {
            GameTimer -= Time.deltaTime;
        }
        GameTimerText.text = "" +((int)GameTimer).ToString() ;
        if (GameTimer <= 0.0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
