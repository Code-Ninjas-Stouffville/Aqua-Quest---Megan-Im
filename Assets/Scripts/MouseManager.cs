using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    public GameObject startUI;
    public float followSpeed = 10f;
    //bool IsTouching(Collider, collider);
    public Lives live;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& !startUI.activeSelf) {
            Vector3 mousePosition = Input.mousePosition;

            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            mousePosition.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePosition, followSpeed * Time.deltaTime);


            transform.rotation = Quaternion.identity;
        }


        /*if (GetComponent<Finish>().IsTouching("Reddy"))
        {
            SceneManager.LoadScene("Fish and Wish");

        }*/
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("you lose");
        live.hearts = live.hearts - 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("GameOver Screen");
        }
    }

    
}
