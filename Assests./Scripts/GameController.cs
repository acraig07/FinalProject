using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject _instrucions;
    bool _active = false;
    Scene _currentScene;
    string _sceneName;

    public int _totalStrokes;

    //BallController _ballCont;

    public Text _totalStrokeText;
    private void Awake() 
    {
        //_ballCont = FindObjectOfType<BallController>();    
    }
    private void Update() 
    {
        _currentScene = SceneManager.GetActiveScene();
        _sceneName = _currentScene.name;
        
        _totalStrokeText.text = "Total Strokes: " + _totalStrokes.ToString();

        if(Input.anyKeyDown && _active)
        {
            _instrucions.SetActive(false);
            _active = false;
        }
    }
    
    public void ListInstructions()
    {
        _instrucions.SetActive(true);
        _active = true;
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("Level01");
    }

    public void AddStroke()
    {
        _totalStrokes++;
    }


    public void NextLevel()
    {
        if(_sceneName == "Level01")
        {
            SceneManager.LoadScene("Level02");
        }
        
        if(_sceneName == "Level02")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
