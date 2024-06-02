using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace LevelSelection
{
    public class DoorAnimationController : MonoBehaviour
    {
        [SerializeField] private float _startXValue;
        [SerializeField] private float _endXValue;
        [SerializeField] private float _closeTime;

        public static event Action OnOpenDoorAction;
        public static event Action OnCloseDoorAction;
        public static Action OnLoadLevelAction;

        [SerializeField] private bool _levelLoader;

        private void OnEnable()
        {
            OnOpenDoorAction += OpenDoorAnimation;
            OnCloseDoorAction += CloseDoorAnimation;
        }

        private void Start()
        {
            OpenDoor();
        }

        private void OnDisable()
        {
            OnOpenDoorAction -= OpenDoorAnimation;
            OnCloseDoorAction -= CloseDoorAnimation;
        }

        private void OpenDoorAnimation()
        {
            transform.DOMoveX(_startXValue, _closeTime).SetEase(Ease.InSine);
        }
        
        private void CloseDoorAnimation()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                var vector3 = transform.position;
                vector3.z = 58.610687f;
                
                vector3.y = _levelLoader ? 7.1f : 7.031573f;
                
                transform.position = vector3;
            }
            
            transform.DOMoveX(_endXValue, _closeTime).SetEase(Ease.OutSine)
                .OnComplete((() =>
                {
                    if (_levelLoader)
                    {
                        OnLoadLevelAction?.Invoke();
                    }
                
                }));
        }
        
        public static void OpenDoor()
        {
            OnOpenDoorAction?.Invoke();
        }
        
        public static void CloseDoor()
        {
            OnCloseDoorAction?.Invoke();
        }
    }
}
