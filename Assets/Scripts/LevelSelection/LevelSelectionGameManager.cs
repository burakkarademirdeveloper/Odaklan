using System;
using UnityEngine;

namespace LevelSelection
{
    public class LevelSelectionGameManager : MonoBehaviour
    {
        [SerializeField] private TextMesh _easyLevelBestScoreText;
        [SerializeField] private TextMesh _hardLevelBestScoreText;
        private void Awake()
        {
            _easyLevelBestScoreText.text = PlayerPrefs.GetInt("EasyLevelBestScore", 0).ToString();
            _hardLevelBestScoreText.text = PlayerPrefs.GetInt("HardLevelBestScore", 0).ToString();
        }
    }
}
