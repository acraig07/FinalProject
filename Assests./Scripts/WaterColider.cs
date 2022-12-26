using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColider : MonoBehaviour
{
    public GameObject _ball;
    public Rigidbody2D _ballRigidBody;
    BallController _ballCont;

    private void Awake() 
    {
        _ballCont = FindObjectOfType<BallController>();
        _ballRigidBody = _ball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("collison");
            _ball.transform.position = _ballCont._startPosistion;
            _ballRigidBody.velocity = Vector2.zero; 
            _ballRigidBody.angularVelocity = 0f;
        }
    }
}
