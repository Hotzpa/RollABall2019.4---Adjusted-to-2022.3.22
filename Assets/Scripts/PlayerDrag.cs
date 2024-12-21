using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    public PlayerController playerController;
    public Rigidbody Player_rb;

    public int Drag = 500;

    private void OnCollisionEnter(Collision collision)
    {
        Player_rb.drag = Drag;
        playerController.count = 0;
        playerController.SetCountText();
    }
}
