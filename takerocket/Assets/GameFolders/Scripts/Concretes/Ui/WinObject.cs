using System.Collections;
using System.Collections.Generic;
using takerocket.Managers;
using UnityEngine;

namespace takerocket.Ui
{
    public class WinObject : MonoBehaviour
    {
        [SerializeField] GameObject _winPanel;

        private void Awake()
        {
            if (_winPanel.activeSelf)
            {
                _winPanel.SetActive(false);//Açıksa kapat başlangıçta
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnMissionSucced += HandleOnMissionSucced;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnMissionSucced -= HandleOnMissionSucced;
        }


        private void HandleOnMissionSucced()
        {
            if (!_winPanel.activeSelf)
            {
                _winPanel.SetActive(true);
            }
        }






    }


}
