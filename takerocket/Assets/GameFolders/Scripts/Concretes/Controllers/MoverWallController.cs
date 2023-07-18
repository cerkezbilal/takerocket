using System.Collections;
using System.Collections.Generic;
using takerocket.Abstract.Controllers;
using UnityEngine;

namespace takerocket.Controllers
{
    public class MoverWallController : WallController
    {
        [SerializeField] Vector3 _direction;//Yön

        [Range(0f,1f)]
        [SerializeField] float _faktor;//Sınır verecek bize 0 ile 1 arasında gidip gelecek

        Vector3 _startPosition;//Başlangıç pozisyonu

        private void Awake()
        {
            //Başlangıçta olduğu pozisyonu bu değişkene ata
            //Amacımız gidip gelen bir duvar yapmak.
            _startPosition = transform.position;
        }

        private void Update()
        {
            //yönü aldık gelen değer ile çarptım
            Vector3 offset = _direction * _faktor;

            //gelen değer ile ilk pozisyonu toplayıp pozisyona verdim
            transform.position = offset + _startPosition;
        }


    }
}

