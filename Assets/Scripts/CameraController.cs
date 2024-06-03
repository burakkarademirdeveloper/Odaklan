using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    
    [SerializeField] private TMPro.TextMeshProUGUI _counterText;
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
                var score = int.Parse(_counterText.text);

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    var currentScore = PlayerPrefs.GetInt("EasyLevelBestScore");
                    
                    if (score > currentScore)
                    {
                        PlayerPrefs.SetInt("EasyLevelBestScore", score);
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    var currentScore = PlayerPrefs.GetInt("HardLevelBestScore");
                    
                    if (score > currentScore)
                    {
                        PlayerPrefs.SetInt("HardLevelBestScore", score);
                    }
                }
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
