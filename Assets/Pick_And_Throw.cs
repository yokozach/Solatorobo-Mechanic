using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_And_Throw : MonoBehaviour
{

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _object;
    [SerializeField] Rigidbody m_Rigidbody;
    [SerializeField] GameObject _body;
    [SerializeField] GameObject _mechanic;
    private bool groundedPlayer;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    public State state;
    public enum State
    {
        cant, can
    }

    void Start()
    {
        state = State.cant;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.can:
                LiftandThrow();
                break;
            case State.cant:
                break;
        }
    }
    public void Default()
    {
        state = State.cant;
    }
    public void LiftandThrow()
    {
        
        Button_Mash button_Mash = _mechanic.GetComponent<Button_Mash>();
        ObjectSelector objectSelector = _body.GetComponent<ObjectSelector>();
        objectSelector.inprog();
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);



        if (Input.GetMouseButtonDown(0))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _object.transform.SetParent(null);
            m_Rigidbody.AddForce(transform.forward* 400f);
            state = State.cant;
        }
        
        if (groundedPlayer)
        {
            button_Mash.reset();
            objectSelector.Normal();
            state=State.cant;

        }
    }

    public void ItsTime()
    {
        state = State.can;

    }



}
