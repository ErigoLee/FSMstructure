﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;

    //panel
    public Image panel;
    private Color color;

    //blur effect
    private bool blurEnabled;

    //attackTool
    public GameObject attackTool;

    //Gun
    public GameObject leftGun;
    public GameObject rightGun;

    //Timer
    private float elaspedTime = 0.0f;
    private float timer = 1.0f;

    //count
    private int endCount;
    private int leftCount;
    private int rightCount;

    //Particle GameObject
    public GameObject sparksEffect;

    //stage
    private int stage;


    //generator
    public Generator generator;


    void Start()
    {
        health = 100;
        blurEnabled = false;
        color = panel.color;
        color.a = 0.0f;
        endCount = 10;
        leftCount = 1;
        rightCount = 1;
        stage = 1;
    }

    
    void Update()
    {

        elaspedTime += Time.deltaTime;

        if (timer < elaspedTime)
        {
            elaspedTime = 0.0f;
            LeftHandGun();
            RightHandGun();
        }

        
        

        if (blurEnabled)
        {
            color.a += Time.deltaTime / 2;
            panel.color = color;
            if (color.a > 0.9)
            {
                blurEnabled = false;
                color.a = 0.0f;
                panel.color = color;
            }
        }

    }
    public void setStage(int inputStage)
    {
        stage = inputStage;
    }

    public void chargeLeftBullet()
    {
        if (leftCount > endCount)
        {
            leftCount = 1;
        }
        
    }

    public void chargeRightBullet()
    {
        if (rightCount > endCount)
        {
            rightCount = 1;
        }
    }

    
    public void LeftHandGun()
    {
        if(stage>1&& leftCount > endCount)
        {
            return;
        }
        GameObject bullet = Instantiate(attackTool, leftGun.transform.position, leftGun.transform.rotation);
        Instantiate(sparksEffect,leftGun.transform.position,leftGun.transform.rotation);


        bullet.GetComponent<Bullet2>().SetForward(leftGun.transform.forward);
        if (stage > 1)
        {
            leftCount++;
        }
    }

    public void RightHandGun()
    {
        if (stage > 1 && rightCount > endCount)
        {
            return;
        }
        GameObject bullet = Instantiate(attackTool, rightGun.transform.position, rightGun.transform.rotation);
        Instantiate(sparksEffect, rightGun.transform.position, rightGun.transform.rotation);
        bullet.GetComponent<Bullet2>().SetForward(rightGun.transform.forward);
        if(stage>1)
        {
            rightCount++;
        }
    }
    
    public void TurnOnBlur()
    {
        blurEnabled = true;
    }
    
    public void Attacked()
    {
        if(health > 0)
        {
            health -= 10;
            Debug.Log(health);
        }

        if(health <= 0)
        {
            Debug.Log("I'm dead");
            generator.DiePlayer();
        }
    }

    public void GiveChance()
    {
        health = 100;
    }

}
