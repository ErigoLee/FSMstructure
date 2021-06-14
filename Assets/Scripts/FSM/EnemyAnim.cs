using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Running",false);
        anim.SetBool("Attacking",false);
    }

    public void SetRunning()
    {
        if(anim==null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Running",true);
        anim.SetBool("Attacking",false);
    }

    public void SetAttacking()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Attacking",true);
        anim.SetBool("Running",false);
    }

    public void SetIdle()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("Attacking",false);
        anim.SetBool("Running",false);
    }

}
