using UnityEngine;

namespace Camera
{
    public class BgColorController : MonoBehaviour
    {
        private UnityEngine.Camera _mainCamera;
        [SerializeField] private float _changeInterval;

        private Color _currentColor;
        private Color _targetColor;
        private float _changeTimer;

        void Start()
        {
            if (_mainCamera == null)
                _mainCamera = UnityEngine.Camera.main;
        
            _targetColor = GetRandomColor();
            _mainCamera!.backgroundColor = _targetColor;
            _currentColor = _targetColor;
            _changeTimer = _changeInterval;
        }

        void Update()
        {
            ChangeColor();
        }

        Color GetRandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }

        private void ChangeColor()
        {
            _changeTimer -= Time.deltaTime;
        
            if (_changeTimer <= 0f)
            {
                _targetColor = GetRandomColor();
                _changeTimer = _changeInterval;
            }
        
            _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime);
            _mainCamera.backgroundColor = _currentColor;
        }
    }
}
