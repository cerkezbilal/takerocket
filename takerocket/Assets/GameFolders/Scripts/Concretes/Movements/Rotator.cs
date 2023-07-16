using System.Collections;
using System.Collections.Generic;
using takerocket.Controllers;
using UnityEngine;

namespace takerocket.Movements
{
    public class Rotator
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;

        public Rotator(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        //Dönme işlemi için bir fonksiyon direction dediğimiz hangi yöne dönücez(sağ-sol)
        public void FixedTick(float direction)
        {
            if(direction == 0)
            {
                //Açıklama: Eğer freezeRotation false ise karakteri biz değil fizik moturu kontrol eder demek yani bir tuşa basılmadıysa direction 0 gelir kontrol bizde değil demek
                if(_rigidbody.freezeRotation) _rigidbody.freezeRotation = false;

                return;
            }

            //Ama eğer 0 dan farklı bir değerse freezeRotation true yaparak fizik mooruna diyoruz ki kontrolü bize bırak biz kontrol edicez demek ve transform Rotate ile duruma göre döndürme işlemi yapıcaz. Back yapma nedenimiz ters bir ifade var ondan
         
            if (!_rigidbody.freezeRotation) _rigidbody.freezeRotation = true;

            _playerController.transform.Rotate(Vector3.back * Time.deltaTime * direction * _playerController.TurnSpeed);
            
           
        }


    }
}

