using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioSystem audioSystem;
    public Vector2 lastCheckPointPos;

    void Start()
    {
        audioSystem = gameObject.GetComponent<AudioSystem>();      
    }

    void Update()
    {
        
    }

    public void playAudio()
    {
        audioSystem.ReturnAudio();
    }
}
