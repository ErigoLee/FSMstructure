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

    public ClearText cleartext;

    //generator stop
    private bool generatorStop;
    public ChanceText chanceText;
    public StageText stageText;

    void Start()
    {
        elapsedTime = 0.0f;
        Timer = 10.0f;
        interval = 0.0f;
        interval2 = 0.0f;
        interval3 = 0.0f;

        stage = 1;
        Enemys = new List<GameObject>();
        nextStage = false;
        //explainText 코드 사용시 true로 만들세요!
        generatorStop = true;
        
    }

    public void GeneratorStopTurnOff()
    {
        generatorStop = false;
    }
    public void GeneratorStopTurnOn()
    {
        generatorStop = true;
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

    public void DiePlayer()
    {
        generatorStop = true;
        nextStage = false;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i=0;i<Enemys.Count;i++)
        {
            GameObject enemy = Enemys[i];
            Destroy(enemy);
        }
        Enemys.Clear();
        for(int i=0;i<bullets.Length;i++)
        {
            Destroy(bullets[i]);
        }
        
        chanceText.AlertWindow(stage);
        
        elapsedTime = 0.0f;
        interval = 0.0f;
        interval2 = 0.0f;
        interval3 = 0.0f;
        generatorStop = false;
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().GiveChance();
    }
    
    void FixedUpdate()
    {
        if (generatorStop)
        {
            return;
        }
            
        
        if (stage > 3)
        {
            cleartext.SetClear();
            return;
        }
            

        if(nextStage && (Enemys.Count==0))
        {
            Debug.Log("nextPage!");
            nextStage = false;
            stage++;
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Player>().setStage(stage);
            player.GetComponent<Player>().isShootTurnOff();
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
                if(elapsedTime == 0.0f)
                {
                    stageText.StageTextStart(stage);
                    
                }
                if (elapsedTime > 2.0f)
                {
                    stageText.StageTextEnd();
                    GameObject player = GameObject.FindWithTag("Player");
                    player.GetComponent<Player>().isShootTurnOn();
                }
                if (interval > 2.5)
                {
                    float x = Random.Range(-20.0f, 20.0f);
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
            stageText.StageTextStart(stage);
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
                if (elapsedTime == 0.0f)
                {
                    stageText.StageTextStart(stage);
                    
                }
                if (elapsedTime > 2.0f)
                {
                    stageText.StageTextEnd();
                    GameObject player = GameObject.FindWithTag("Player");
                    player.GetComponent<Player>().isShootTurnOn();
                }
                if (interval > 2.5)
                {
                    float x = Random.Range(-20.0f, 20.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance = Instantiate(Enemy,spawn, transform.rotation);
                    Enemys.Add(instance);
                    interval = 0.0f;
                }
                if(interval2 > 2.7)
                {
                    float x = Random.Range(-20.0f, 20.0f);
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
                if (elapsedTime == 0.0f)
                {
                    stageText.StageTextStart(stage);
                    
                }
                if (elapsedTime > 2.0f)
                {
                    stageText.StageTextEnd();
                    GameObject player = GameObject.FindWithTag("Player");
                    player.GetComponent<Player>().isShootTurnOn();
                }

                if (interval > 2.5)
                {
                    float x = Random.Range(-20.0f, 20.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance = Instantiate(Enemy, spawn, transform.rotation);
                    Enemys.Add(instance);
                    interval = 0.0f;
                }
                if (interval2 > 2.7)
                {
                    float x = Random.Range(-20.0f, 20.0f);
                    float z = Random.Range(-10.0f, 10.0f);
                    Vector3 spawn = transform.position;
                    spawn.x += x;
                    spawn.z += z;
                    GameObject instance2 = Instantiate(Enemy2, spawn, transform.rotation);
                    Enemys.Add(instance2);
                    interval2 = 0.0f;
                }
                if(interval3 > 2.9)
                {
                    float x = Random.Range(-20.0f, 20.0f);
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
