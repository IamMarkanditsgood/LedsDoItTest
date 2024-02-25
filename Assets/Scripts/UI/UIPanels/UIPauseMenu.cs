using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIPauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;

        public event Action OnCloseButton;
        public event Action OnRestartButton;
        public event Action OnExitButton;
        
        private void Awake()
        {
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _closeButton.onClick.AddListener(Close);
            _restartButton.onClick.AddListener(Restart);
            _optionsButton.onClick.AddListener(Options);
            _exitButton.onClick.AddListener(Exit);
        }
        private void Unsubscribe()
        {
            _closeButton.onClick.RemoveListener(Close);
            _restartButton.onClick.RemoveListener(Restart);
            _optionsButton.onClick.RemoveListener(Options);
            _exitButton.onClick.RemoveListener(Exit);
        }
        private void Close()
        {
            OnCloseButton?.Invoke();
        }
        private void Restart()
        {
            OnRestartButton?.Invoke();
        }
        private void Options()
        {
        }
        private void Exit()
        {
            OnExitButton?.Invoke();
        }
        
    }
}