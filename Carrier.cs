using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour
{
    float delta_dx = 0.2f;
    int dir;
    public int[] buffer = new int[4];
    //public int buffer_count;
    public GameObject goal;
    public int tx, tz;
    
    // Start is called before the first frame update
    void Start()
    {
        //buffer_count = 4;
        buffer[0] = 0;
        buffer[1] = 0;
        buffer[2] = 0;
        buffer[3] = 0;
        tx = 0;
        tz = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(goal.GetComponent<GOAL>().time>1)
        {
            if(goal.GetComponent<GOAL>().flag)
            {
                
            }
            else
            {
                dir = UnityEngine.Random.Range(0, 4);
            }
            //buffer[buffer_count++] = dir;
            /*
            switch (dir)
            {
                case 0:
                    transform.Translate(Vector3.forward * delta_dx, Space.World);
                    tz = (goal.GetComponent<GOAL>().flag)?0:tz+1;
                    break;
                case 1:
                    transform.Translate(-1 * Vector3.forward * delta_dx, Space.World);
                    tz = (goal.GetComponent<GOAL>().flag) ? 0 : tz - 1;
                    break;
                case 2:
                    transform.Translate(-1 * Vector3.right * delta_dx, Space.World);
                    tx = (goal.GetComponent<GOAL>().flag) ? 0 : tx - 1;
                    break;
                case 3:
                    transform.Translate(Vector3.right * delta_dx, Space.World);
                    tx = (goal.GetComponent<GOAL>().flag) ? 0 : tx + 1;
                    break;
            }
            */
            float deltax = 0.5f;
            float rotate_ang = 5.0f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * deltax, Space.Self);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.forward * -deltax, Space.Self);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * rotate_ang, Space.World);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.up * rotate_ang, Space.World);
            }
            RaycastHit hit;
            Debug.DrawRay(transform.position+new Vector3(0,-0.3f,0), transform.forward * 5, Color.green);
            if(Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                Debug.Log(hit.transform.name);
                if(hit.collider.isTrigger)
                {
                    Debug.Log("gkgk");
                }
            }
        }
        
        
        /*
        Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * 5);
        Debug.DrawRay(transform.position, new Vector3(-1, 0, 0) * 5);
        Debug.DrawRay(transform.position, new Vector3(0, 0, 1) * 5);
        Debug.DrawRay(transform.position, new Vector3(0, 0, -1) * 5);
        Debug.DrawRay(transform.position, new Vector3(-1, 0, 1) * 2.5f*Mathf.Sqrt(2));
        Debug.DrawRay(transform.position, new Vector3(1, 0, -1) * 2.5f * Mathf.Sqrt(2));
        Debug.DrawRay(transform.position, new Vector3(1, 0, 1) * 2.5f * Mathf.Sqrt(2));
        Debug.DrawRay(transform.position, new Vector3(-1, 0, -1) * 2.5f * Mathf.Sqrt(2));
        */
    }
}
