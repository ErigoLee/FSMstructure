using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

    //private GameObject[] Enemys;
    private float LifeTime = 3.0f;
    public float Speed = 100.0f;

    public GameObject explosionEffect;

    void Start()
    {
        Destroy(gameObject, LifeTime);
        //Enemys = GameObject.FindGameObjectsWithTag("Enemy");

    }

    public void SetForward(Vector3 setforward)
    {
        transform.forward = setforward;
        
    }
    
    void Update()
    {
        transform.position +=  transform.forward * Speed * Time.deltaTime;
        
        
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        print("detected!");
        //ContactPoint contact = collision.contacts[0];
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            other.gameObject.GetComponent<NpcFSM>().Attacked();
            Debug.Log("Attack! Enemy!!");

            Destroy(gameObject);
        }

    }
}
