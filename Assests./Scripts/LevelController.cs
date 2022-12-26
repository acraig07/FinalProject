using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject _goal;
    public GameObject _ball;
    public Rigidbody2D _ballRigidBody;
    BallController _ballCont;
    public float _maxY, _maxX;

    public Text _levelStokes;

    private void Awake() 
    {
        _ballCont = FindObjectOfType<BallController>();
        _ballRigidBody = _ball.GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        _levelStokes.text = "Stokes: " + _ballCont._strokes.ToString();
        if(_ball.transform.position.y > _maxY || _ball.transform.position.x > _maxX)
        {
            _ball.transform.position = _ballCont._startPosistion;
            _ballRigidBody.velocity = Vector2.zero;
            _ballRigidBody.angularVelocity = 0f;
        }
    }
}
