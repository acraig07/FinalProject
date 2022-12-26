using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    AudioSource _src;
    GameController _cont;

    private void Awake() 
    {
        _src = GetComponent<AudioSource>();    
        _cont = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _src.Play();
            Debug.Log("Goal");
            Invoke("InvokeNextLevel", 2f);
        }
    }

    private void InvokeNextLevel()
    {
        _cont.NextLevel();
    }
}
