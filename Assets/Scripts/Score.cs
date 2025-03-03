using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    public int score = 0;

    public Sprite[] rods;
    public SpriteRenderer rod;
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score; 

    }
    public void Update()
    {
        scoreText.text = score.ToString();
        if (score > 25)
        {
            rod.sprite = rods[1];
            
        }

        if (score > 40)
        {
            rod.sprite = rods[2];
            Debug.Log("Load new screen");
            SceneManager.LoadScene("MiniGame");
            
        }
    }
    public void AddScore(int addScore)
    {
        score = score + addScore;
    }


}
