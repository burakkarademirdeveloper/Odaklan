using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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

    [Header("Colors")]
    public Color Red;
    public Color Green;
    public Color Blue;
    public Color Yellow;
    public Color White;
    public Color Pink;
    public Color Orange;
    public Color Purple;
    
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
    
    public void ButtonActiveSlef(bool state)
    {
        _button1.SetActive(state);
        _button2.SetActive(state);
        _button3.SetActive(state);
        _button4.SetActive(state);
    }
}
