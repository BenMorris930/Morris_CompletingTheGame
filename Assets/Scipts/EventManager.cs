using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [System.Serializable] public class TargetDestroyed : UnityEvent<int> { }
    public TargetDestroyed targetDestroyed;
    public UnityEvent gameOverEvent;
    [System.Serializable] public class StartGameEvent : UnityEvent<float> { }
    public StartGameEvent startGameEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
