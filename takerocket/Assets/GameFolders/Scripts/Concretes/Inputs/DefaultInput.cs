using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace takerocket.Inputs
{
    public class DefaultInput
    {
        DefaultAction _input;
        public bool IsForceUp { get; private set; }
        public float LeftRight { get; private set; }


        public DefaultInput()
        {
            _input = new DefaultAction();

            _input.Rocket.ForceUp.performed += context => IsForceUp = context.ReadValueAsButton();//çok satır ise {} açılır tek satırsa gerek yok burada şunu yapıyoruz diyoruz ki eğer bu aksiyon çalıştıysa burdan gelen veriyi context değişkenine ata ve IsForceUp değişkenine bu contextin buttonb valuesini ver butopna tıklandıysa button value true değilse false gelir

            _input.Rocket.LeftRight.performed += context => LeftRight = context.ReadValue<float>();

            _input.Enable();//Input un çalışması için önemli!!
        }

       

    }
}

