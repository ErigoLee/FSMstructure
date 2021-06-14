using System.Collections;
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


    void Start()
    {
        health = 100;
        blurEnabled = false;
        color = panel.color;
        color.a = 0.0f;
    }

    
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Transform spwanPoint = transform.GetChild(0).transform;
            GameObject bullet = Instantiate(attackTool, gun.transform.position, gun.transform.rotation);
            bullet.GetComponent<Bullet2>().SetForward(gun.transform.right);
        }
        */

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
    
    public void LeftHandGun()
    {
        
        GameObject bullet = Instantiate(attackTool, leftGun.transform.position, leftGun.transform.rotation);
        
        bullet.GetComponent<Bullet2>().SetForward(leftGun.transform.forward); 
    }

    public void RightHandGun()
    {

        GameObject bullet = Instantiate(attackTool, rightGun.transform.position, rightGun.transform.rotation);
        
        bullet.GetComponent<Bullet2>().SetForward(rightGun.transform.forward);
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
        }
    }

}
