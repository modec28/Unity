using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Snake_Gene : MonoBehaviour
{
    public GameObject[] sample = new GameObject[24];
    float temp_x;
    int index_2nd, index_1st;
    float temp_line_x;
    float rank_x;
    Timer timer;
    public GameObject line1st;
    public Material red;
    public Material blue;
    public Material skin;
    int _rank1 = 23;
    int _rank2 = 23;
    // Start is called before the first frame update
    void Start()
    {
        index_1st = 0;
        timer = GameObject.Find("Ground").GetComponent<Timer>();
        temp_x = -40f;
        temp_line_x = -40f;
        rank_x = -40f;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < 24; i++)
        {
            if (sample[i].GetComponent<Snake>().Live)
            {
                if (sample[i].transform.position.x > temp_line_x)
                {
                    //_rank2 = _rank1;
                    temp_line_x = sample[i].transform.position.x;
                    _rank1 = i;
                }
            }
        }

        for (int i = 0; i < 24; i++)
        {
            if(i!=_rank1)
            {
                if(sample[i].transform.position.x>rank_x)
                {
                    rank_x = sample[i].transform.position.x;
                    _rank2 = i;
                }
            }
        }
        for (int i = 0; i<24; i++)
        {
            if((i!=_rank1)&&(i!=_rank2))
            {
                sample[i].GetComponent<MeshRenderer>().material = skin;
                for(int j=0; j<15; j++)
                {
                    sample[i].transform.GetChild(j).GetComponent<MeshRenderer>().material = skin;
                }
            }
            
            if(i==_rank1)
            {
                sample[_rank1].GetComponent<MeshRenderer>().material = red;
                for (int j = 0; j < 15; j++)
                {
                    sample[i].transform.GetChild(j).GetComponent<MeshRenderer>().material = red;
                }
            }
            if(i==_rank2)
            {
                sample[_rank2].GetComponent<MeshRenderer>().material = blue;
                for (int j = 0; j < 15; j++)
                {
                    sample[i].transform.GetChild(j).GetComponent<MeshRenderer>().material = blue;
                }
            }
            
        }
        

        line1st.transform.position = new Vector3(temp_line_x, line1st.transform.position.y, line1st.transform.position.z);
    }
    public void survive()
    {
        for (int i = 0; i < 24; i++)
        {
            if (sample[i].GetComponent<Snake>().Live)
            {
                if (sample[i].transform.position.x > temp_x)
                {
                    index_2nd = index_1st;
                    temp_x = sample[i].transform.position.x;

                    index_1st = i;
                }
            }
        }
        
        
        for (int i = 0; i < 24; i++)
        {
            if((i!=index_1st)&&(i!=index_2nd))
            {
                int count = 0;
                int xes = UnityEngine.Random.Range(0, 2);
                for(int j=3; j<14; j++)
                {
                    if(xes == 1)
                    {
                        sample[i].GetComponent<Snake>()._array[j] = sample[index_1st].GetComponent<Snake>()._array[j];
                        count++;
                    }
                    if((count>4)||(xes == 0))
                    {
                        sample[i].GetComponent<Snake>()._array[j] = sample[index_2nd].GetComponent<Snake>()._array[j];
                    }
                    //mutant
                    if(UnityEngine.Random.Range(0,1000)==5)
                    {
                        sample[i].GetComponent<Snake>()._array[j] = UnityEngine.Random.Range(0, 2);
                        //Debug.Log(i + "번째 돌연변이 발생");
                    }
                }
                
            }
        }
    }
}
