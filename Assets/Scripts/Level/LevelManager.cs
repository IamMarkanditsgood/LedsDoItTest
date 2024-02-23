using System;
using Entities.Character;
using Level.InitScriptableObjects;
using Services.PoolObjectSystem.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;

        [SerializeField] private LevelData _levelData;
        [SerializeField] private SceneManager _sceneManager;
        [SerializeField] private SceneCreator _sceneCreator;

        private void Awake()
        {
            Subscribe();
        }

        private void Start()
        {
            ManagersInitializing();
            _sceneCreator.AssembleScene();
        }

        private void Update()
        {
            _sceneManager.PlayGame();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _levelData.Character.GetComponent<CharacterManager>().OnDead += EndGame;
        }
        
        private void Unsubscribe()
        {
            _levelData.Character.GetComponent<CharacterManager>().OnDead -= EndGame;
        }

        private void EndGame()
        {
            Time.timeScale = 0;
        }
        
        private void ManagersInitializing()
        {
            _sceneManager.Init(_levelConfig,_levelData);
            _sceneCreator.Init(_levelConfig,_levelData);
        }
    }
}
