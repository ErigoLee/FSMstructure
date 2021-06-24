using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainText : MonoBehaviour
{
    [SerializeField]
    private Generator generator;
    [SerializeField]
    private Player player;
    //Timer
    private float elapsedTime;
    private float endTime;
    private bool timerStop;


    void Start()
    {
        elapsedTime = 0.0f;
        endTime = 10.0f;
        timerStop = false;
    }

    
    void Update()
    {
        if (timerStop)
            return;
        elapsedTime += Time.deltaTime;
        if(elapsedTime>endTime)
        {
            generator.GeneratorStopTurnOff();
            timerStop = true;
        }
    }
}
