using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Score : MonoBehaviour
{

    public PlayerController playerController;

    public Transform Player_tans;

    private float Score_By_Distance;

    private void Start()
    {

        Score_By_Distance = 0;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Score_By_Distance = Player_tans.position.z;
     
        playerController.count += Score_By_Distance;

        playerController.SetCountText();



    }
}
