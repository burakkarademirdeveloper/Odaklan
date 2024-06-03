using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameEndButtonController : MonoBehaviour
{
    [SerializeField] private Vector3 _imitialPos;
    [SerializeField] private Vector3 _targetPos;
    
    [SerializeField] private float _forwardTime;
    [SerializeField] private float _backTime;
    [SerializeField] private float _targetDistance;
    
    private bool _clickable;
    public bool _menuButton;
    
    public Ease _forwardEase;
    public Ease _backEase;
    
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameEndButtonController _menuButtonGameEndButtonController;
    private void Start()
    {
        _imitialPos = transform.position;
    }
    
    public void OnMouseDown()
    {
        if (!_clickable) return;
        
        if (_menuButton)
            _gameController.BackToMenu();
        else
            CloseAnimation();
    }
    
    public void OpenAnimation()
    {
        
        var targetPos = _imitialPos + new Vector3(_targetDistance, 0, 0);

        transform.DOMove(targetPos, _forwardTime).SetEase(_forwardEase)
            .OnComplete((() =>
            {
                transform.DOMove(_targetPos, _backTime).SetEase(_backEase)
                    .OnComplete((() =>
                    {
                        _clickable = true;
                    }));
            }));
    }
    
    public void CloseAnimation()
    {
        if (!_menuButton)
            _gameController.RetryGame();
        
        var targetPos = _imitialPos + new Vector3(_targetDistance, 0, 0);

        if (!_menuButton)
            _menuButtonGameEndButtonController.CloseAnimation();
        
        transform.DOMove(targetPos, _backTime).SetEase(_backEase)
            .OnComplete((() =>
            {
                transform.DOMove(_imitialPos, _forwardTime).SetEase(_forwardEase)
                    .OnComplete((() =>
                    {
                        _clickable = false;
                    }));
            }));
    }
}
