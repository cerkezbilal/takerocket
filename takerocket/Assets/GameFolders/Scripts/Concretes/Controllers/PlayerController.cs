using System.Collections;
using System.Collections.Generic;
using takerocket.Inputs;
using takerocket.Movements;
using UnityEngine;

namespace takerocket.Controllers//Klasörleme mantığı oyunun_adi.bulunduğu klasör adı
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;
        DefaultInput _input;
        bool _isForceUp;
        Mover _mover;

        float _leftRight;
        Rotator _rotator;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;




        private void Awake()
        {
           
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
        }

        //Input işlemleri
        private void Update()
        {
            
            if (_input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }

            _leftRight = _input.LeftRight;
        }

        //Fizik işlemleri
        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
            }

            _rotator.FixedTick(_leftRight);

        }




       

    }//class

}
