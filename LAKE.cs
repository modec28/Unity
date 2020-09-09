using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEditorInternal;
using UnityEngine;

public class LAKE : MonoBehaviour
{
    public GameObject[] stage = new GameObject[16];
    
    int current_stage;
    int temp_stage;
    bool explo;
    int dir;
    int[,] state_array = new int[16,4];
    float time;
    int gene_length;
    Vector3 start_pos;
    // Start is called before the first frame update
    void Start()
    {
        gene_length = 0;
        explo = false;
        current_stage = 0;
        time = 0;
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        temp_stage = current_stage;

        while(true)
        {
            //페널티에 못가게함
            dir = Random.Range(0, 4);
            if (state_array[current_stage, dir] != -1)
                break;
        }
        for (int i=0; i<4; i++)
        {
            if (state_array[current_stage, i] == 1)
            {
                dir = i;
                //Debug.Log(current_stage + " & " + i);
                if(current_stage ==0)
                {
                    //Debug.Log("end");
                    explo = true;
                }
            }
        }
        if(!explo)
        {
            switch (dir)
            {
                case 0:
                    transform.Translate(Vector3.forward * 5, Space.World);
                    current_stage = current_stage - 4;
                    break;
                case 1:
                    transform.Translate(Vector3.forward * -5, Space.World);
                    current_stage = current_stage + 4;
                    break;
                case 2:
                    transform.Translate(Vector3.right * 5, Space.World);
                    current_stage = current_stage + 1;
                    break;
                case 3:
                    transform.Translate(Vector3.right * -5, Space.World);
                    current_stage = current_stage - 1;
                    break;
            }
        }
        else
        {
            time += Time.deltaTime;
            if(time>0.5)
            {
                time = 0;
                int Adir = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (state_array[current_stage, i] == 1)
                    {
                        Adir = i;
                        break;
                    }
                }
                switch (Adir)
                {
                    case 0:
                        transform.Translate(Vector3.forward * 5, Space.World);
                        current_stage = current_stage - 4;
                        break;
                    case 1:
                        transform.Translate(Vector3.forward * -5, Space.World);
                        current_stage = current_stage + 4;
                        break;
                    case 2:
                        transform.Translate(Vector3.right * 5, Space.World);
                        current_stage = current_stage + 1;
                        break;
                    case 3:
                        transform.Translate(Vector3.right * -5, Space.World);
                        current_stage = current_stage - 1;
                        break;
                }
                gene_length++;
            }
        }
        decide_fall();

        for(int i=0; i<4; i++)
        {
            if (state_array[current_stage, i] == 1)
            {
                state_array[temp_stage, dir] = 1;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ICE")
            fallen();
        else if (other.tag == "Finish")
            set_reward();
    }
    void GotoHome()
    {
        transform.position = start_pos;
        current_stage = 0;
    }
    void fallen()
    {
        state_array[temp_stage, dir] = -1;
        
        GotoHome();
    }
    
    void set_reward()
    {

        if (!explo)
        {
            state_array[temp_stage, dir] = 1;
        }
        else
        {
            gene_length = 0;
        }
            
        GotoHome();
        //goal_in = true;
        //reward = 1;
    }
    void decide_fall()
    {
        if ((transform.position.z > start_pos.z) || (transform.position.x < start_pos.x) || (transform.position.z < start_pos.z-15) || (transform.position.x > start_pos.x+15))
        {
            fallen();
        }
    }
}
