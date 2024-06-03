using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCube;
    
    public bool IsTrueButton;
    
    public List<Material> MaterialList;
    
    [SerializeField] private MainCubesController _mainCubesController;
    [SerializeField] private GameController _gameController;
    
    public string MaterialName;
    
    public void ButtonClick()
    {
        _gameController.IsButtonCliclked = true;
        GetColorName();

        if (SceneManager.GetActiveScene().buildIndex == 1)
            _mainCube.GetComponent<Renderer>().material = GetMaterial(MaterialName);
        else
        {
            var buttonText = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            _mainCube.GetComponent<Renderer>().material = GetMaterialWithButtonText(buttonText);
        }
        
        if (IsTrueButton)
            _gameController.IsGameOver = false;
        else
            _gameController.IsGameOver = true;
        
        _gameController.ButtonsActive(false);
    }

    private void GetColorName()
    {
        Color color = GetComponent<Image>().color;
        var counter = 0;

        foreach (var clr in _gameController._colors)
        {
            counter++;
            
            if (clr == color)
            {
                if (counter == 1)
                {
                    MaterialName = "Red";
                }
                else if (counter == 2)
                {
                    MaterialName = "Green";
                }
                else if (counter == 3)
                {
                    MaterialName = "Blue";
                }
                else if (counter == 4)
                {
                    MaterialName = "Yellow";
                }
                else if (counter == 5)
                {
                    MaterialName = "White";
                }
                else if (counter == 6)
                {
                    MaterialName = "Pink";
                }
                else if (counter == 7)
                {
                    MaterialName = "Orange";
                }
                else if (counter == 8)
                {
                    MaterialName = "Purple";
                }
                
                break;
            }
        }
    }
    private Material GetMaterial(string materialName)
    {
        return materialName switch
        {
            "Red" => MaterialList[0],
            "Green" => MaterialList[1],
            "Blue" => MaterialList[2],
            "Yellow" => MaterialList[3],
            "Pink" => MaterialList[4],
            "Orange" => MaterialList[5],
            "Purple" => MaterialList[6],
            "White" => MaterialList[7],
            _ => MaterialList[7]
        };
    }
    
    private Material GetMaterialWithButtonText(string materialName)
    {
        return materialName switch
        {
            "Kırmızı" => MaterialList[0],
            "Yeşil" => MaterialList[1],
            "Mavi" => MaterialList[2],
            "Sarı" => MaterialList[3],
            "Pembe" => MaterialList[4],
            "Turuncu" => MaterialList[5],
            "Mor" => MaterialList[6],
            "Beyaz" => MaterialList[7],
            _ => MaterialList[7]
        };
    }
}
