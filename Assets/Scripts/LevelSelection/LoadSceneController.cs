using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelSelection
{
    public class LoadSceneController : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        private bool _clickable;

        private void OnMouseDown()
        {
            if (_clickable) return;
            _clickable = true;
            DoorAnimationController.OnLoadLevelAction += LoadLevel;
            DoorAnimationController.CloseDoor();
        }
        
        private void LoadLevel()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
