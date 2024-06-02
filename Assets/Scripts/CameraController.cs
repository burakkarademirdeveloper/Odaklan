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
    
    public void CameraMoveForward()
    {
        transform.DOMove(_targetPos, _moveTime).SetEase(_forwardEase);
    }
    
    public void CameraMoveBack()
    {
        transform.DOMove(_initialPos, _moveTime).SetEase(_backEase);
    }
}
