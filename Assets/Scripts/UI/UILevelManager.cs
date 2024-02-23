using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class UILevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _healthBar;
        [SerializeField] private GameObject _magnetBar;
        [SerializeField] private GameObject _nitroBar;
        [SerializeField] private GameObject _shieldBar;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _startCount;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _gameOverMenu;

    }
}
