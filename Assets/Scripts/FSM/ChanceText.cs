﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceText : MonoBehaviour
{
    private Text text;
    private Color color;

    //Timer variable
    private bool timeStart;
    private float elaspedTime;

    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        color.a = 0.0f;
        text.color = color;
        timeStart = false;
        elaspedTime = 0.0f;
    }

    public void AlertWindow(int stage)
    {
        text.text = stage + "Step I'll give you chance";
        color.a = 1.0f;
        text.color = color;
        timeStart = true;
    }
    
    void Update()
    {
        if(timeStart)
        {
            elaspedTime += Time.deltaTime;
            if(elaspedTime > 1.0f)
            {
                if(color.a < 0.2f)
                {
                    color.a = 0.0f;
                    text.color = color;
                    elaspedTime = 0.0f;
                    timeStart = false;
                }
                else
                {
                    color.a -= Time.deltaTime;
                    text.color = color;
                }
                
            }
        }
    }
}
