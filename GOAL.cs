using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GOAL : MonoBehaviour
{
    public bool success;
    bool init_state;
    public GameObject agent;
    public GameObject target;

    float spawn_x;
    float spawn_z;

    public float time = 0;
    float[] obsVector = new float[8];
    public bool flag;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        init_state = true;
        success = false;
        init_all();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            init_all();
        
        if (success)
        {
            if(time<1)
            {
                success = false;
                init_all();
            }
        }
        
        time += Time.deltaTime;
        
        
        obsVector[0] = agent.transform.position.x;
        obsVector[1] = agent.transform.position.z;
        obsVector[2] = target.transform.position.x;
        obsVector[3] = target.transform.position.z;
        obsVector[4] = transform.position.x;
        obsVector[5] = transform.position.z;
        obsVector[6] = Mathf.Sqrt(Mathf.Pow(obsVector[4] - obsVector[2], 2) + Mathf.Pow(obsVector[5] - obsVector[3], 2));
        obsVector[7] = Mathf.Sqrt(Mathf.Pow(obsVector[0] - obsVector[2], 2) + Mathf.Pow(obsVector[1] - obsVector[3], 2));

        if (time > 30)
        {
            init_all();
            
        }
        if (obsVector[7] < 3)
        {
            flag = true;
            agent.GetComponent<Carrier>().buffer[0] = agent.GetComponent<Carrier>().tx;
            agent.GetComponent<Carrier>().buffer[1] = agent.GetComponent<Carrier>().tz;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Target"))
        {
            success = true;
        }
    }
    public void init_obj(GameObject obj)
    {
        while(true)
        {
            spawn_x = Random.Range(-12.0f, 12.0f);
            spawn_z = Random.Range(-12.0f, 12.0f);

            if (!Physics.CheckBox(new Vector3(spawn_x, 1.5f, spawn_z), new Vector3(0.5f, 0.5f, 0.5f)))
            {
                if (!success)
                    break;
                else
                    success = false;
            }
        }
        switch (obj.name)
        {
            case "Target":
                obj.transform.position = new Vector3(spawn_x, 1.5f, spawn_z);
                break;
            case "Agent":
                obj.transform.position = new Vector3(spawn_x, 1, spawn_z);
                break;
            case "Goal":
                obj.transform.position = new Vector3(spawn_x, 0.5499f, spawn_z);
                break;
        }
        
    }
    private void init_all()
    {
        time = 0;
        init_state = true;
        
        init_obj(target);
        init_obj(this.gameObject);
        init_obj(agent);
    }
}
