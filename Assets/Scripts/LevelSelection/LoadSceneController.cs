using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelSelection
{
    public class LoadSceneController : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        private void OnMouseDown()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
