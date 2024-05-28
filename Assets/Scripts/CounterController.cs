using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CounterController : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _counterText;
    private Vector3 _initialScale;
    
    [SerializeField] private MainCubesController _mainCubesController;
    [SerializeField] private GameController _gameController;
    private void Start()
    {
        _initialScale = transform.localScale;
        _counterText = GetComponent<TMPro.TextMeshProUGUI>();
        CounterAnim();
    }

    private void CounterAnim()
    {
        _counterText.text = "3";
        
        var targetScale = _initialScale * 1.5f;
        
        _counterText.transform.DOScale(targetScale, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            _counterText.text = "2";
            _counterText.transform.DOScale(targetScale, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            {
                _counterText.text = "1";
                _counterText.transform.DOScale(targetScale, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
                {
                    _counterText.text = "0";
                    _counterText.transform.DOScale(targetScale, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
                    {
                        //_gameController.ButtonActiveSlef(true);
                        _mainCubesController.CubesIsDown(5f);
                    });
                });
            });
        });
    }
}
