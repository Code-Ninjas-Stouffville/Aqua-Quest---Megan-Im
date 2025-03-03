using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MoveFish : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            GetComponent<Rigidbody2D>().velocity = new UnityEngine.Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }
}
