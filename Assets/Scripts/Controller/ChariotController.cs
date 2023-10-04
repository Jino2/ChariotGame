using System.Collections;
using System.Collections.Generic;
using Controller;
using Domain.GameRules;
using Domain.Models;
using UnityEngine;

public class ChariotController : MonoBehaviour
{
    public float speed = 30f;
    public float rotateSpeed = 50f;
    public float patience = 0.5f;
    public int anger = 0;
    public int sloth = 0;
    public GameObject user;

    private Chariot _chariot;

    private GetChariotTranslation _getChariotTranslation;
    private GetChariotRotation _getChariotRotation;

    private GameManager _gameManager;

    private float _time;

    void Start()
    {
        _gameManager = GameManager.GetInstance();
        _chariot = new Chariot(speed, patience, anger, sloth);
        _getChariotRotation = new GetChariotRotation();
        _getChariotTranslation = new GetChariotTranslation();
        _time = Time.time;
    }

    void Update()
    {
        if (_gameManager.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            WhipHorse();
        }
        MoveHorse();
        UpdateHorseState();
    }

    private void UpdateHorseState()
    {
        var nextTime = Time.time;
        if (nextTime - _time >= 1f)
        {
            _time = nextTime;
            _chariot.Anger--;
            _chariot.Sloth += 2;
        }

        _gameManager.SetAngerPoint(_chariot.Anger);
        _gameManager.SetSlothPoint(_chariot.Sloth);
    }

    private void MoveHorse()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        transform.Translate(_getChariotTranslation.Handle(this,_chariot, verticalInput, Time.deltaTime));
        transform.Rotate(_getChariotRotation.Handle(this, _chariot, rotateSpeed, horizontalInput, Time.deltaTime));
    }

    private void WhipHorse()
    {
        _chariot.Sloth /= 2;
        _chariot.Anger += 10;
    }
}