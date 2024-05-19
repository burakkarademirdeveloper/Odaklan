using System;
using UnityEngine;
using DG.Tweening;

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
        
        [SerializeField] private Ease _easeType;

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
            transform.DOMoveX(_startXValue, _closeTime).SetEase(_easeType);
        }
        
        private void CloseDoorAnimation()
        {
            transform.DOMoveX(_endXValue, _closeTime).SetEase(_easeType)
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
