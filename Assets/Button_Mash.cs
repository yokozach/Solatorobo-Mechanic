using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Mash : MonoBehaviour
{
    [SerializeField] GameObject _ui;
    [SerializeField] GameObject _body;
    [SerializeField] Image _bar;
    public float _starting = 0f;
    public float _endGoal = 100f;
    public State state;
    [SerializeField] GameObject _player;

    public enum State
    {
        Innactive, Active
    }

    void Start()
    {
        state = State.Innactive;
        _starting = Mathf.Clamp(0, 0, 100);
    }

    // Update is called once per frame
    void Update()
    {

        
        switch (state)
        {

            
            default:
            case State.Innactive:
                Off();
                break;
            case State.Active:
                Activate();
                break;






        }
    }

    public void Activate()
    {
        Character_Movement character_Movement = _player.GetComponent<Character_Movement>();
        ObjectSelector objectSelector = _body.GetComponent<ObjectSelector>();
        character_Movement.cantmove();
        _ui.SetActive(true);
        _starting = Mathf.Clamp(_starting, 0, 100);
        _bar.fillAmount = _starting / _endGoal;

        _starting -= 10 * Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {
            _starting += 10;

        }
        if (_starting>=95)
        {
            objectSelector.CanAction();
            _ui.SetActive(false);
            character_Movement.MechanicOver();
            Over();
        }


    }

    public void Off()
    {


        _ui.SetActive(false);

    }
    public void On()
    {
        state = State.Active;
    }
    public void Over()
    {
        state = State.Innactive;
    }
    public void reset()
    {
        _starting = 0f;
        state = State.Innactive;
    }
}
