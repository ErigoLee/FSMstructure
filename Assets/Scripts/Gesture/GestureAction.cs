using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureAction : MonoBehaviour
{
    public float speed = 1.0f;

    public GameObject player;
    public GameObject centerCam;

    private Vector3 centerCamDir;

    //attackTool
    public GameObject attackTool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoStraight()
    {
        Vector3 centerCamDir = centerCam.transform.forward;
        centerCamDir.y = 0;
        centerCamDir.Normalize();

        player.transform.Translate(centerCamDir * speed * Time.deltaTime);
    }

    public void GoBack()
    {
        Vector3 centerCamDir = -centerCam.transform.forward;
        centerCamDir.y = 0;
        centerCamDir.Normalize();

        player.transform.Translate(centerCamDir * speed * Time.deltaTime);
    }
    
    public void AttackAction(string handName)
    {

        if (handName.Equals("leftHand"))
        {
            player.GetComponent<Player>().LeftHandGun();
        }

        if(handName.Equals("rightHand"))
        {
            player.GetComponent<Player>().RightHandGun();
        }


        /*
        //centerCam.transform.position-player.transform.position;
        Vector3 centerCamDir = centerCam.transform.forward;
        //centerCamDir.y = 0.0f;

        Vector3 playerDir = player.transform.forward;
        //playerDir.y = 0.0f;

        float centerDist = Vector3.Magnitude(centerCamDir);
        float playerDist = Vector3.Magnitude(playerDir);

        Vector3 direct = centerCamDir + (playerDir - centerCamDir) * centerDist / (centerDist + playerDist);
        direct.Normalize();

        Vector3 spawnPoint = hand.transform.position;
        //spawnPoint.y = 0.25f; //이건 상황에 따라 변동될 수 있는 값.

        GameObject bullet = Instantiate(attackTool, spawnPoint, hand.transform.rotation);
        bullet.GetComponent<Bullet2>().SetForward(direct);
        */
    }
}
