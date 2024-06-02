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
    
    private List<GameObject> _buttons = new List<GameObject>();
    public List<Color> _colors = new List<Color>();

    public List<GameObject> _blackPanels;
    
    public bool IsGameOver;
    public bool IsButtonCliclked;
    
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private CounterController _counterController;
    
    private void Start()
    {
        SetButtonImages();
        
        _buttons.Add(_button1);
        _buttons.Add(_button2);
        _buttons.Add(_button3);
        _buttons.Add(_button4);
        
        _colors.Add(Red);
        _colors.Add(Green);
        _colors.Add(Blue);
        _colors.Add(Yellow);
        _colors.Add(White);
        _colors.Add(Pink);
        _colors.Add(Orange);
        _colors.Add(Purple);
    }
    
    private void SetButtonImages()
    {
        _button1Image = _button1.GetComponent<Image>();
        _button2Image = _button2.GetComponent<Image>();
        _button3Image = _button3.GetComponent<Image>();
        _button4Image = _button4.GetComponent<Image>();
    }
    
    public void ButtonsActive(bool state)
    {
        foreach (var btn in _buttons)
        {
            btn.SetActive(state);
        }

        foreach (var pnl in _blackPanels)
        {
            pnl.SetActive(state);
        }
        
    }
    public void ButtonsActive(bool state, string materialName)
    {
        foreach (var btn in _buttons)
        {
            btn.SetActive(state);
        }

        foreach (var pnl in _blackPanels)
        {
            pnl.SetActive(state);
        }
        
        SetButtonColor(materialName);
    }

    private void SetButtonColor(string materialName)
    {
        var randomButton = UnityEngine.Random.Range(0, _buttons.Count);
        
        List<GameObject> buttons = new List<GameObject>(_buttons);
        List<Color> colors = new List<Color>(_colors);
        
        var btn = buttons[randomButton];
        var mat = GetColor(materialName);

        btn.GetComponent<Image>().color = mat;
        btn.GetComponent<ButtonController>().IsTrueButton = true;
        
        buttons.Remove(btn);
        colors.Remove(mat);
        
        for (int i = 0; i < buttons.Count; i++)
        {
            var randomIndex = UnityEngine.Random.Range(0, colors.Count);
            var button = buttons[i];
            var material = colors[randomIndex];
            
            button.GetComponent<Image>().color = material;
            button.GetComponent<ButtonController>().IsTrueButton = false;
            
            colors.RemoveAt(randomIndex);
        }
    }
    
    private Color GetColor(string materialName)
    {
        return materialName switch
        {
            "Red" => Red,
            "Green" => Green,
            "Blue" => Blue,
            "Yellow" => Yellow,
            "White" => White,
            "Pink" => Pink,
            "Orange" => Orange,
            "Purple" => Purple,
            _ => Color.white
        };
    }
    
    private string GetMaterialName(Material material)
    {
        return material.name switch
        {
            "Red (Instance)" => "Red",
            "Green (Instance)" => "Green",
            "Blue (Instance)" => "Blue",
            "Yellow (Instance)" => "Yellow",
            "White (Instance)" => "White",
            "Pink (Instance)" => "Pink",
            "Orange (Instance)" => "Orange",
            "Purple (Instance)" => "Purple",
            _ => "White"
        };
    }
    
    public void GameOver()
    {
        _cameraController.CameraMoveForward();
    }

    public void RetryGame()
    {
        _counterController.ResetText();
        _cameraController.CameraMoveBack();
    }
}
