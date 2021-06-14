﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState1 : FSMState
{

    //attackTool

    public GameObject attackTool;
    //enemy colleagues
    private GameObject[] friends;
    private float friendPull;

    //attack 변수
    //private float attackRate;
    //private float elapsedTime; //Timer

    public AttackState1(GameObject gameObject)
    {
        curSpeed = 10.0f;
        curRotSpeed = 5.0f;

        destPos = new Vector3();
        destPos = Vector3.zero;

        attackTool = gameObject;
        friendPull = 1.0f;
    }

    public override void Reason(Transform player, Transform npc, GameObject npc_obj)
    {
        //y값을 고려하지 않기 위해서
        destPos = player.position;
        destPos.y = npc.position.y;

        float dist = Vector3.Distance(npc.position, destPos);

        if(dist >= 20.0f)
        {
            npc_obj.GetComponent<NpcFSM>().TranslateState(1); // curState -> chase로 변경
        }
        if(dist <= 1.0f)
        {
            npc_obj.GetComponent<NpcFSM>().AttackingAnim();
            npc_obj.GetComponent<NpcFSM>().TranslateState(3);
            player.gameObject.GetComponent<Player>().Attacked();
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //y값을 고려하지 않기 위해서
        destPos = player.position;
        destPos.y = npc.position.y;


        //npc는 player의 위치로 가려고 할 것임.
        //Vector3 direct = destPos - npc.position;
        //float dist = Vector3.Distance(npc.position, destPos);
        //direct = direct / dist; //단위 벡터화 시킴.


        //npc와의 간격을 띠우기
        Vector3 direct = Vector3.zero;
        friends = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0;i<friends.Length;i++)
        {
            if(friends[i] != npc.gameObject)
            {
                float distance = Vector3.Distance(friends[i].transform.position,npc.position);
                if (distance <= 1.0f)
                {
                    Vector3 avoidDist = npc.position - friends[i].transform.position;
                    //direct += avoidDist;
                    direct += avoidDist/(avoidDist.sqrMagnitude);
                    //avoidDist = avoidDist / (avoidDist.sqrMagnitude);
                    //npc.Translate(avoidDist * friendPull);
                }
            }
        }
        destPos += direct;
        //방향 회전
        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
        //Vector3 direction = Vector3.forward + direct;
        //direction = direction.normalized;
        //npc.Translate(direction * curSpeed * Time.deltaTime);
        //npc.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed + direct * friendPull * Time.deltaTime);
    }
    public override void Attacking(GameObject npc_obj)
    {
        //nothing
        //GameObject instance = Instantiate(attackTool, attackSpawnPoint.position, attackSpawnPoint.rotation);
        //instance.GetComponent<Bullet>().npcStage = 1;
    }



    
}
