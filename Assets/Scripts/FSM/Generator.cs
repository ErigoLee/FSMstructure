using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    private float elapsedTime;
    private float Timer;
    private int stage;
    private bool nextStage;
    private float interval;
    private float interval2;
    private float interval3;

    private List<GameObject> Enemys;

    void Start()
    {
        elapsedTime = 0.0f;
        Timer = 5.0f;
        interval = 0.0f;
        interval2 = 0.0f;
        interval3 = 0.0f;

        stage = 1;
        Enemys = new List<GameObject>();
        nextStage = false;
    }

    public void deleteEnemy(GameObject enemy)
    {
        for(int i=0;i<Enemys.Count;i++)
        {
            if(enemy == Enemys[i])
            {
                Enemys.RemoveAt(i);
                return;
            }
        }
    }
    
    void FixedUpdate()
    {
        
        if (stage > 3)
            return;

        if(nextStage && (Enemys.Count==0))
        {
            Debug.Log("nextPage!");
            nextStage = false;
            stage++;
        }
        


        if(stage == 1)
        {
           
            if (elapsedTime > Timer)
            {
                elapsedTime = 0.0f;
                interval = 0.0f;
                nextStage = true;
                
            }
            else
            {
                if (nextStage)
                    return; 
                if(interval > 1.0)
                {
                    float x = Random.Range(-40.0f, 40.0f);
                    float z = Random.Range(-10.0f,10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance = Instantiate(Enemy,spawn , transform.rotation);
                    
                    Enemys.Add(instance);
                    interval = 0.0f;
                }
                
                elapsedTime += Time.deltaTime;
                interval += Time.deltaTime;
                
            }
            
        }

        if(stage == 2)
        {
           
            if (elapsedTime > Timer)
            {
                elapsedTime = 0.0f;
                interval = 0.0f;
                interval2 = 0.0f;
                nextStage = true;

            }
            else
            {
                if (nextStage)
                    return;
                if (interval > 1.0)
                {
                    float x = Random.Range(-40.0f, 40.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance = Instantiate(Enemy,spawn, transform.rotation);
                    Enemys.Add(instance);
                    interval = 0.0f;
                }
                if(interval2 > 1.1)
                {
                    float x = Random.Range(-40.0f, 40.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;

                    GameObject instance2 = Instantiate(Enemy2,spawn ,transform.rotation );
                    Enemys.Add(instance2);
                    interval2 = 0.0f;
                }

                elapsedTime += Time.deltaTime;
                interval += Time.deltaTime;
                interval2 += Time.deltaTime;
            }
        }

        if(stage == 3)
        {
            
            if (elapsedTime > Timer)
            {
                elapsedTime = 0.0f;
                interval = 0.0f;
                interval2 = 0.0f;
                interval3 = 0.0f;
                nextStage = true;

            }
            else
            {
                if (nextStage)
                    return;

                if (interval > 1.0)
                {
                    float x = Random.Range(-40.0f, 40.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance = Instantiate(Enemy, spawn, transform.rotation);
                    Enemys.Add(instance);
                    interval = 0.0f;
                }
                if (interval2 > 1.1)
                {
                    float x = Random.Range(-40.0f, 40.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance2 = Instantiate(Enemy2, spawn, transform.rotation);
                    Enemys.Add(instance2);
                    interval2 = 0.0f;
                }
                if(interval3 > 1.2)
                {
                    float x = Random.Range(-40.0f, 40.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance3 = Instantiate(Enemy3, spawn, transform.rotation);
                    Enemys.Add(instance3);
                    interval3 = 0.0f;
                }
                
                elapsedTime += Time.deltaTime;
                interval += Time.deltaTime;
                interval2 += Time.deltaTime;
                interval3 += Time.deltaTime;
            }
        }
        
    }
}
