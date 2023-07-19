using System.Collections;
using System.Collections.Generic;
using takerocket.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace takerocket.Ui
{
    public class FuelSlider : MonoBehaviour
    {
        Slider _slider;
        Fuel fuel;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            fuel = FindObjectOfType<Fuel>();
        }


        private void Update()
        {
            //0-1 arasında değişiyor değer. Bu veri bize Fuel den gelecek.currenFuel gelmeli bize
            _slider.value = fuel.CurrentFuel;
        }








    }//class

}
