using System.Collections;
using System.Collections.Generic;
using takerocket.Managers;
using UnityEngine;

namespace takerocket.Ui
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene();//Neden levelIndex vermedin aynı level i oynucak çünkü

        }
        public void NoClicked()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}

