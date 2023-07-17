using System.Collections;
using System.Collections.Generic;
using takerocket.Managers;
using UnityEngine;

namespace takerocket.Ui
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }

        public void ExitClicked()
        {
            GameManager.Instance.Exit();
        }

    }
}

