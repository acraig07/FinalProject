using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D _ballRigidbody;
    public Vector2 _startPosistion;
    Vector3 _mousePosistion;
    Vector2 _resetPosistion;

    AudioSource _src;
    public float _force;

    public int _strokes = 0;

    Animator _anim;

    GameController _CONT;

    private void Awake()
    {
        _CONT = FindObjectOfType<GameController>();
        _ballRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<LineRenderer>().enabled = false;
        _src = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {   GetComponent<LineRenderer>().enabled = true;
        _startPosistion = transform.position;
        //GetComponent<LineRenderer>().enabled = true;
        //_resetPosistion = transform.position;
    }

    private void Update() 
    {
        _mousePosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<LineRenderer>().SetPosition(0, _startPosistion);
        GetComponent<LineRenderer>().SetPosition(1, _mousePosistion);

        //if(_ballRigidbody.velocity.x <= 0.15f  && _ballRigidbody.velocity.y <= 0.15f)
        if(_ballRigidbody.velocity.magnitude <= 0.15f)
        {
            _anim.SetBool("rolling", false);
            _anim.speed = 1;
        }
        else
        {
            _anim.SetBool("rolling", true);
            _anim.speed = _ballRigidbody.velocity.magnitude / 2;
        }
        
    }

    private void OnMouseUp()
    {
        GetComponent<LineRenderer>().enabled = false;
        //Vector3 _mousePosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 finalMousePos = new Vector2(_mousePosistion.x, _mousePosistion.y);
        Vector2 direction = _startPosistion - finalMousePos;
        //direction.Normalize();
        //if(_ballRigidbody.velocity.x <= 0.15f && _ballRigidbody.velocity.y <= 0.15f)
        if(_ballRigidbody.velocity.magnitude <= 0.15f)
        {
            _ballRigidbody.AddForce(direction * _force);
            _ballRigidbody.angularVelocity = 1f;
            _strokes++;
            _CONT.AddStroke();
            _src.Play();
        }
        
    }
}
