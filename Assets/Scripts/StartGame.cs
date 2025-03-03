using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StartGame : MonoBehaviour
{

    public GameObject Startcanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void closecanvas()
    {
        Debug.Log("Working");
        Startcanvas.SetActive(false);
    }
}
