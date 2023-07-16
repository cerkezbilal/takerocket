using System.Collections;
using System.Collections.Generic;
using takerocket.Controllers;
using UnityEngine;

namespace takerocket.Movements
{
    public class Mover
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick()//Fixed Update fonskiyounu gibi benzesin diye fiziksel işlemler
        {
            //bu x y z ye göre değilde bizim direk pozisyonumuza göre kuvvet veren bir fonksiyon - //daha sonra dışardan alıcaz bu gücü
            _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * _playerController.Force);
        }
    }
}

