using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Selector : MonoBehaviour
{

    [SerializeField] LayerMask _player;
    [SerializeField] GameObject _self;

    public State state;
    Collider m_Collider;


    public enum State
    {
        Stationary, Awaiting
    }
    void Start()
    {
        state = State.Stationary;
    }

    // Update is called once per frame
    void Update()
    {

    



    }
}





