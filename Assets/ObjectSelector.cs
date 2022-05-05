using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] float _wireLength = 1f;
    [SerializeField] GameObject _ui;
    [SerializeField] GameObject _mechanic;
    [SerializeField] GameObject _player;
    [SerializeField] LayerMask _object;
    [SerializeField] GameObject _objects;

    Collider m_Collider;
    [SerializeField] GameObject _indicator;
    [SerializeField]GameObject _canIndicator;
    public States state;

    public enum States
    {
        Look, InProgress, PickPull
    }
    // Start is called before the first frame update
    void Start()
    {
        state = States.Look;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case States.Look:
                lookingFor();
                break;
            case States.InProgress:
                break;

            case States.PickPull:
                action();
                break;
        }

    }
    private void lookingFor()
    {
        Button_Mash button_Mash = _mechanic.GetComponent<Button_Mash>();
        Character_Movement character_Movement = _player.GetComponent<Character_Movement>();
        Vector3 rayStartPos = transform.position;
        Vector3 rayDirection = transform.forward;

        Debug.DrawRay(rayStartPos,
            rayDirection * _wireLength, Color.cyan);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayStartPos, rayDirection, out hitInfo, _wireLength, _object))
        {
            _indicator.SetActive(true);
        }
        else
        {
            _indicator.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(rayStartPos, rayDirection, out hitInfo, _wireLength, _object))
        {
            _ui.SetActive(true);
            button_Mash.On();
            character_Movement.cantmove();

        }
    }

    public void action()
    {
        Pick_And_Throw pick_ = _player.GetComponent<Pick_And_Throw>();
      
        _indicator.SetActive(false);
        Vector3 rayStartPos = transform.position;
        Vector3 rayDirection = transform.forward;

        Debug.DrawRay(rayStartPos,
            rayDirection * _wireLength, Color.cyan);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayStartPos, rayDirection, out hitInfo, _wireLength, _object))
        {
            _canIndicator.SetActive(true);
        }
        else
        {
            _canIndicator.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _objects.transform.parent = _player.transform;

            _objects.transform.position = _player.transform.position + new Vector3(0, 2, 0);
            pick_.ItsTime();
            _canIndicator.SetActive(false);
        }
    }

    public void Normal()
    {
        state = States.Look;
    }

    public void CanAction()
    {
        state = States.PickPull;
    }

    public void inprog()
    {
        state = States.InProgress;
    }
}
