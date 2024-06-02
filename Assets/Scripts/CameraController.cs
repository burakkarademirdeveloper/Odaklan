using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private Vector3 _initialPos;
    [SerializeField] private Vector3 _targetPos;
    [SerializeField] private float _moveTime;
    public Ease _forwardEase;
    public Ease _backEase;
    [SerializeField] private CounterController _counterController;

    [SerializeField] private GameEndButtonController _gameEndButtonController1;
    [SerializeField] private GameEndButtonController _gameEndButtonController2;
    private void Start()
    {
        _initialPos = transform.position;
    }

    public void CameraMoveForward()
    {
        _gameEndButtonController1.OpenAnimation();
        _gameEndButtonController2.OpenAnimation();
        
        transform.DOMove(_targetPos, _moveTime).SetEase(_forwardEase)
            .OnComplete((() =>
            {
                // _gameEndButtonController1.OpenAnimation();
                // _gameEndButtonController2.OpenAnimation();
            }));
    }
    
    public void CameraMoveBack()
    {
        // _gameEndButtonController1.CloseAnimation();
        // _gameEndButtonController2.CloseAnimation();
        
        transform.DOMove(_initialPos, _moveTime).SetEase(_backEase).SetDelay(1f)
            .OnComplete(() =>
            {
                _counterController.CounterAnim();
            });
    }
}
