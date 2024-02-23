using TMPro;
using UnityEngine;

namespace UI
{
    public class UIGameOverMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bestScoreText;
        [SerializeField] private TextMeshProUGUI _yourScoreText;
        [SerializeField] private GameObject _closeButton;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _exitButton;
    }
}