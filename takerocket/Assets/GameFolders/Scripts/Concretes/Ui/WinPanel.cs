using System.Collections;
using System.Collections.Generic;
using takerocket.Managers;
using UnityEngine;

namespace takerocket.Ui
{
    public class WinPanel : MonoBehaviour
    {


        public void YesClicked()
        {
            //Bir sonraki leveli yükle
            GameManager.Instance.LoadLevelScene(1);
        }





    }
}

