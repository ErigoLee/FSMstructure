using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClearText : MonoBehaviour
{
    private Text text;
    private Color color;
    
    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    
    public void SetClear()
    {
        color.a = 1.0f;
        text.color = color;
    }
}
