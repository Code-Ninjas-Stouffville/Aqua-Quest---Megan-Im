using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnButtonClicked()
    {
        
         SceneManager.LoadScene("Fish and Wish");

        
    }

    /*void OnStartButtonClick()
    {
        SceneManager.LoadScene("Fish and Wish");
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
