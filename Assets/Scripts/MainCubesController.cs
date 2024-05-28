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
    
    private List<GameObject> _cubes = new List<GameObject>();
    
    [SerializeField] private GameObject _mainGameCube;


    [SerializeField] private List<Material> _materialList;
    
    [SerializeField] private GameController _gameController;
    
    private void Start()
    {
        CubeAddToList();
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
        StartCoroutine(ChangeMaterial(time / 2));
        
        var targetPos = _mainGameCube.transform.position;

        transform.DOMove(targetPos, time).SetEase(Ease.Linear)
            .OnComplete((() =>
            {
                StartCoroutine(AddRbToCubes());
            }));
    }

    
    private IEnumerator AddRbToCubes()
    {
        int listCount = 0;
        
        foreach (GameObject obj in _cubes)
        {
            listCount++;
            if (obj != null && listCount != 4)
            {
                obj.AddComponent<Rigidbody>();
                obj.transform.parent = null;
            }

            if (listCount == 4)
            {
                obj.transform.parent = null;
            }

            if (listCount == _cubes.Count)
            {
                Invoke(nameof(ResetCubesPos), 2f);
            }
            
            yield return new WaitForSeconds(0.25f);
        }
    }
    
    private void RemoveRbFromCubes()
    {
        Destroy(_cube1.GetComponent<Rigidbody>());
        Destroy(_cube2.GetComponent<Rigidbody>());
        Destroy(_cube3.GetComponent<Rigidbody>());
        Destroy(_cube5.GetComponent<Rigidbody>());
        Destroy(_cube6.GetComponent<Rigidbody>());
        Destroy(_cube7.GetComponent<Rigidbody>());
    }
    
    private void ResetCubesPos()
    {
        RemoveRbFromCubes();
        _cube1.transform.position = _cube1InitialPos;
        _cube2.transform.position = _cube2InitialPos;
        _cube3.transform.position = _cube3InitialPos;
        _cube4.transform.position = _cube4InitialPos;
        _cube5.transform.position = _cube5InitialPos;
        _cube6.transform.position = _cube6InitialPos;
        _cube7.transform.position = _cube7InitialPos;
        transform.position = _initialPos;
        
        SetParent(gameObject.transform);
        
        CubesIsDown(4f);
    }
    
    private void CubeAddToList()
    {
        _cubes.Add(_cube1);
        _cubes.Add(_cube2);
        _cubes.Add(_cube3);
        _cubes.Add(_cube4);
        _cubes.Add(_cube5);
        _cubes.Add(_cube6);
        _cubes.Add(_cube7);
    }
    
    private void SetParent(Transform transform)
    {
        _cube1.transform.parent = transform;
        _cube2.transform.parent = transform;
        _cube3.transform.parent = transform;
        _cube4.transform.parent = transform;
        _cube5.transform.parent = transform;
        _cube6.transform.parent = transform;
        _cube7.transform.parent = transform;
    }

    public IEnumerator ChangeMaterial(float changeDuration)
    {
        Invoke(nameof(SetButtonActive), changeDuration + .1f);
        
        float elapsedTime = 0f;

        while (elapsedTime < changeDuration)
        {
            List<Material> shuffledMaterials = new List<Material>(_materialList);
            ShuffleList(shuffledMaterials);
            
            for (int i = 0; i < _cubes.Count; i++)
            {
                GameObject obj = _cubes[i];
                if (obj != null)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = shuffledMaterials[i];
                    }
                }
            }
            
            yield return new WaitForSeconds(0.25f);
            
            elapsedTime += 0.25f;
        }
    }
    
    /// <summary>
    /// Bu metot verilen listedeki elemanları karıştırır. Böylece her renk karıştırma aşamasında yan yana renkler gelmesinden ziyade tüm küpler materyal listesindeki renklerden rastgele bir renge sahip olur.
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, list.Count); 
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }
    
    private void SetButtonActive()
    {
        var originalMaterialName = _cube4.GetComponent<Renderer>().material.name;
        var materialName = originalMaterialName.Substring(0, originalMaterialName.Length - 11);
        
        _gameController.ButtonsActive(true, materialName);
    }
}
