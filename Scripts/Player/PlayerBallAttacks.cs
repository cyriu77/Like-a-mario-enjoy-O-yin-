using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireBall;
    public Transform fireBallPoint;
    public float fireBallSpeed = 600;

    public void fireBallAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }
}
