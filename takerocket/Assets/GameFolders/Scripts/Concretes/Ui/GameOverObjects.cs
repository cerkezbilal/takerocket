using System.Collections;
using System.Collections.Generic;
using takerocket.Managers;
using UnityEngine;

namespace takerocket.Ui
{
    public class GameOverObjects : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;

        private void Awake()
        {
            if (_gameOverPanel.activeSelf)
            {
                _gameOverPanel.SetActive(false);//Eğer panel açık ise kapat.
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnGameOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnGameOver;
        }

        public void HandleOnGameOver()
        {
            //Panel açık değilse aç
            if (!_gameOverPanel.activeSelf)
            {
                _gameOverPanel.SetActive(true);
            }
        }










    }//class

    
}

