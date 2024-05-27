using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainCubesController : MonoBehaviour
{
    private Vector3 _initialPos;

    [SerializeField] private GameObject _cube1;
    [SerializeField] private GameObject _cube2;
    [SerializeField] private GameObject _cube3;
    [SerializeField] private GameObject _cube4;
    [SerializeField] private GameObject _cube5;
    [SerializeField] private GameObject _cube6;
    [SerializeField] private GameObject _cube7;
    
    private Vector3 _cube1InitialPos;
    private Vector3 _cube2InitialPos;
    private Vector3 _cube3InitialPos;
    private Vector3 _cube4InitialPos;
    private Vector3 _cube5InitialPos;
    private Vector3 _cube6InitialPos;
    private Vector3 _cube7InitialPos;

    private void Start()
    {
        SetCubeInitialPos();
    }
    
    private void SetCubeInitialPos()
    {
        _initialPos = transform.position;
        _cube1InitialPos = _cube1.transform.position;
        _cube2InitialPos = _cube2.transform.position;
        _cube3InitialPos = _cube3.transform.position;
        _cube4InitialPos = _cube4.transform.position;
        _cube5InitialPos = _cube5.transform.position;
        _cube6InitialPos = _cube6.transform.position;
        _cube7InitialPos = _cube7.transform.position;
    }

    public void CubesIsDown(float time)
    {
        var targetPos = new Vector3(0f,0f, transform.position.z);

        transform.DOMove(targetPos, time).SetEase(Ease.Linear)
            .OnComplete((() =>
            {
                //küp indi.
            }));
    }
}
