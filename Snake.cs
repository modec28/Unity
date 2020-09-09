using JetBrains.Annotations;
//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using TMPro.EditorUtilities;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class Snake : MonoBehaviour
{
    public float jump_force;
    public Vector3 start_position;
    public bool Live = true;
    public int[] _array = new int[15];
    Vector3[] start_pos = new Vector3[15];
    Timer timer;
    Snake_Gene SG;
    bool start_live = false;
    // Start is called before the first frame update
    void Start()
    {
        jump_force = 30;
        timer = GameObject.Find("Ground").GetComponent<Timer>();
        SG = GameObject.Find("Ground").GetComponent<Snake_Gene>();
        start_position = transform.position;
        for (int i = 0; i < 15; i++)
        {
            start_pos[i] = transform.GetChild(i).transform.position;
            _array[i] = Random.Range(0, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Timeout>0)
        {
            SG.survive();
            fallen();
            Live = true;
            timer.Timeout--;
        }
        
        if(Live)
        {
            gameObject.SetActive(true);
            if (transform.position.y < -5)
            {
                fallen();
            }
            else
            {
                //Let's Jump
                if((int)timer.time%2==0)
                {
                    transform.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * 2 ;
                    transform.GetChild(3).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[3]);
                    transform.GetChild(4).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[4]);
                    transform.GetChild(5).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[5]);
                    transform.GetChild(6).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[6]);
                    transform.GetChild(7).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[7]);
                    transform.GetChild(8).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[8]);
                    transform.GetChild(9).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[9]);
                    transform.GetChild(10).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[10]);
                    transform.GetChild(11).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[11]);
                    transform.GetChild(12).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[12]);
                    transform.GetChild(13).GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jump_force * _array[13]);
                }
                
            }
        }
                
    }
    public void fallen()
    {
        Live = false;
        gameObject.SetActive(false);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.position = start_position;        
        for(int i=0; i<15; i++)
        {
            transform.GetChild(i).transform.position = start_pos[i];
            transform.GetChild(i).transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.GetChild(i).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.GetChild(i).GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
