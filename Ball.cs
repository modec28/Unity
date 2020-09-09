using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody ballrb;
    float force;
    // Start is called before the first frame update
    void Start()
    {
        ballrb = GetComponent<Rigidbody>();
        force = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {                                       
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
            ballrb.AddForce(new Vector3(0, 0, 1)*force);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ballrb.AddForce(new Vector3(0, 0, -1)*force);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ballrb.AddForce(new Vector3(-1, 0, 0)*force);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ballrb.AddForce(new Vector3(1, 0, 0)*force);
        }
    }
}
