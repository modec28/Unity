using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float time;
    private int count;
    public Text timetext;
    
    public int Timeout;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;    
    }

    // Update is called once per frame
    void Update()
    {
        if(time>30)
        {
            count++;
            time = 0;
            Timeout = 24;
        }
        if(Timeout==0)
        {
            time += Time.deltaTime;
        }
        
        timetext.text = "Generation " + count.ToString() + " : " + string.Format("{0:N2}", time);
         
    }
}
