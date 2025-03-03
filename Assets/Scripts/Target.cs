using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class Target : MonoBehaviour
{
    public float speed = 570f;
    public Rigidbody2D rb;
    public LayerMask layerMask;

    public GameObject Fish1;
    public GameObject Fish2;
    public GameObject Fish3;
    public GameObject Fish4;
    public TMP_Text text;
    public TMP_Text deduction;
    public TMP_Text minusfv;
    public TMP_Text plusfv;

    public GameObject[] fishList;

    public float timeLeft = 30;

    public Timer timer;

    public Score score;

    bool canCast = true;

    public Sprite[] rods;
    public SpriteRenderer rod;

    //[SerializeField] Sprite[] StartingFishingRodSprite;
    //[SerializeField] Sprite[] RareFishingRodSprite;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
        HideAllSprite();
        deduction.gameObject.SetActive(false);
        minusfv.gameObject.SetActive(false);
        plusfv.gameObject.SetActive(false);
        rod.sprite = rods[0];
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {

    }

    

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log("Time left: " + timeLeft);
        //Debug.DrawLine(transform.position, -Vector2.up, Color.blue, 10.0f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, layerMask);
        //Debug.Log("Hitting " + hit.collider.name);
    }
    private void Launch(){
        float x = Random.Range(0,2) == 0? -1:1;
        float y = Random.Range(0,2) == 0? -1:1;
        rb.velocity = new Vector2(speed*x , speed*y);
    }

    void FixedUpdate()
    {
        /*
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, layerMask);
        if (hit.collider.name == "Black")
        {
            deduction.gameObject.SetActive(true);
        }
        else
        {
            deduction.gameObject.SetActive(false);
        }*/
    }
    public void CatchFish()
    {
        if(text.text == "Casting" &&canCast == true ){
            timer.pause = true;
            text.text = "Wait...";
            Invoke("Reset", 1f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, layerMask);
            //Debug.DrawLine(transform.position, -Vector2.up, Color.blue, 10.0f);
            /*if (hit.collider != null)
            {
                Debug.Log ("hit Object = "+hit.collider);
            }*/
            int fishIndex = 0;
            rb.velocity = new Vector2(0 ,0);
            ///Debug.Log("Hitting " + hit.collider.name);

            if (hit.collider.name == "Pond"){
                Debug.Log ("Hitting "+hit.collider);
                fishIndex = Random.Range(0, 4);
                /*if (fishIndex == 4 || fishIndex == 3 || fishIndex == 2)
                {
                    Debug.Log("Load new screen");
                    SceneManager.LoadScene("MiniGame");
                }*/
                score.AddScore(fishIndex);
                HideAllSprite();
                fishList[fishIndex].SetActive(true);
                timer.GameTimer = timer.GameTimer - 10f;
                deduction.gameObject.SetActive(true);
            }

            if (hit.collider.name == "Light Blue")
            {
                Debug.Log ("Hitting Light Blue" + hit.collider);
                fishIndex = Random.Range(3, 7);
                if (fishIndex>0 )
                {
                    Debug.Log("Load new screen");
                    SceneManager.LoadScene("MiniGame");
                }
                score.AddScore(fishIndex);
                HideAllSprite();
                fishList[fishIndex].SetActive(true);
                timer.GameTimer = timer.GameTimer - 5f;
                minusfv.gameObject.SetActive(true);

            }

            if (hit.collider.name == "Violet"){
                Debug.Log ("Hitting Violet" + hit.collider);
                fishIndex = Random.Range(6, 10);
                if (fishIndex == 9)
                {
                    Debug.Log("Load new screen");
                    SceneManager.LoadScene("MiniGame");
                }
                score.AddScore(fishIndex);
                HideAllSprite();
                fishList[fishIndex].SetActive(true);
                
            }

            if (hit.collider.name == "Dark Blue"){
                Debug.Log ("Hitting Dark Blue" + hit.collider);
                fishIndex = Random.Range(9, 13);
                if (fishIndex == 13)
                {
                    Debug.Log("Load new screen");
                    SceneManager.LoadScene("MiniGame");
                }
                score.AddScore(fishIndex);
                HideAllSprite();
                fishList[fishIndex].SetActive(true);

            }

            if (hit.collider.name == "Deep Blue"){
                Debug.Log ("Hitting Deep Blue" + hit.collider);
                fishIndex = Random.Range(12, 15);
                if (fishIndex == 15)
                {
                    Debug.Log("Load new screen");
                    SceneManager.LoadScene("MiniGame");
                }
                score.AddScore(fishIndex);
                HideAllSprite();
                fishList[fishIndex].SetActive(true);
                timer.GameTimer = timer.GameTimer + 1f;
                plusfv.gameObject.SetActive(true);

            }
            timeLeft = timeLeft + (fishIndex * 5);
        }
        else if(text.text == "Catch again!"){
            text.text = "Casting";
            Launch();
            HideAllSprite();
            deduction.gameObject.SetActive(false);
            minusfv.gameObject.SetActive(false);
            plusfv.gameObject.SetActive(false);
        }
    }

    void HideAllSprite()
    {
        for (int i = 0; i < fishList.Length; i++)
        {
            fishList[i].SetActive(false);
        }
    }
    private void Reset()
    {
        text.text = "Catch again!";
        canCast = true;
        timer.pause = false;
    }

    
}
