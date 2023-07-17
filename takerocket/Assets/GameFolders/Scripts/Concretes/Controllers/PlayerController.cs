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
        Fuel _fuel;

        float _leftRight;
        Rotator _rotator;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;




        private void Awake()
        {
           
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();
        }

        //Input işlemleri
        private void Update()
        {
            
            if (_input.IsForceUp && !_fuel.IsEmpty)//yani benzini varsa
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
                _fuel.FuelIncrease(0.01f);//Burası w ya basmadığım yer o yüzden artış burada olacak
            }

            _leftRight = _input.LeftRight;
        }

        //Fizik işlemleri
        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_leftRight);

        }




       

    }//class

}
