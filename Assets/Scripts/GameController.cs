using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Color Codes")]
    [SerializeField] private string _redCode;
    [SerializeField] private string _greenCode;
    [SerializeField] private string _blueCode;
    [SerializeField] private string _yellowCode;
    [SerializeField] private string _whiteCode;
    [SerializeField] private string _pinkCode;
    [SerializeField] private string _orangeCode;
    [SerializeField] private string _purpleCode;
    
    [Header("Materials")]
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _blueMaterial;
    [SerializeField] private Material _yellowMaterial;
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private Material _pinkMaterial;
    [SerializeField] private Material _orangeMaterial;
    [SerializeField] private Material _purpleMaterial;

    [Header("Buttons")]
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private GameObject _button3;
    [SerializeField] private GameObject _button4;
    
    private Image _button1Image;
    private Image _button2Image;
    private Image _button3Image;
    private Image _button4Image;

    private Color _red;
    private Color _green;
    private Color _blue;
    private Color _yellow;
    private Color _white;
    private Color _pink;
    private Color _orange;
    private Color _purple;
    
    
    private void Start()
    {
        SetButtonImages();
    }
    
    private void SetButtonImages()
    {
        _button1Image = _button1.GetComponent<Image>();
        _button2Image = _button2.GetComponent<Image>();
        _button3Image = _button3.GetComponent<Image>();
        _button4Image = _button4.GetComponent<Image>();
    }

    private void SetColor(Color color, string hexCode, Image buttonImage)
    {
        if (ColorUtility.TryParseHtmlString(hexCode, out color))
        {
            buttonImage.color = color;
        }
    }
    
    public void ButtonActiveSlef(bool state)
    {
        _button1.SetActive(state);
        _button2.SetActive(state);
        _button3.SetActive(state);
        _button4.SetActive(state);
        
        if (state)
        {
            SetButtonColors();
        }
    }
    
    private void SetButtonColors()
    {
        _button1Image.color = 
        _button2Image.color = GetColor(_greenCode);
        _button3Image.color = GetColor(_blueCode);
        _button4Image.color = GetColor(_yellowCode);
    }
}
