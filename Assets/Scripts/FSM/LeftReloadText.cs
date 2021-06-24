using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeftReloadText : MonoBehaviour
{
    private TMP_Text text;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    public void ReloadTextStart()
    {
        color.a = 1.0f;
        text.color = color;
    }

    public void ReloadTextEnd()
    {
        color.a = 0.0f;
        text.color = color;
    }
}
