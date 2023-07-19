using System.Collections;
using System.Collections.Generic;
using takerocket.Abstract.Controllers;
using UnityEngine;

namespace takerocket.Controllers
{
    public class MoverWallController : WallController
    {
        [SerializeField] Vector3 _direction;//Yön
        [SerializeField] float _speed = 1f;
        //[SerializeField] float _directionFaktor = 1f;

        float _faktor;//Sınır verecek bize 0 ile 1 arasında gidip gelecek

        const float FULL_CYCLE = Mathf.PI * 2f;

        Vector3 _startPosition;//Başlangıç pozisyonu

        private void Awake()
        {
            //Başlangıçta olduğu pozisyonu bu değişkene ata
            //Amacımız gidip gelen bir duvar yapmak.
            _startPosition = transform.position;
        }

        private void Update()
        {
            float cycle = Time.time / _speed;//yani zamanı biraz yavaşlatıcaz ki o hız sorunu gitsin
            float sinWave =Mathf.Sin(cycle * FULL_CYCLE);

            // _faktor = Mathf.Abs(sinWave);
            _faktor = sinWave / 2 + 0.5f; //sinwave -1 +1 arasında verdiği için 2 ye böşüp 0.5f verince dengelenmiş oluyor.

            
            //yönü aldık gelen değer ile çarptım
            Vector3 offset = _direction * _faktor ;

             //gelen değer ile ilk pozisyonu toplayıp pozisyona verdim
             transform.position = offset + _startPosition;

            

           
        }


    }
}

