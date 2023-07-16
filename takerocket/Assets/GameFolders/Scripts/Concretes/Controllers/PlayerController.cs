using System.Collections;
using System.Collections.Generic;
using takerocket.Inputs;
using takerocket.Movements;
using UnityEngine;

namespace takerocket.Controllers//Klasörleme mantığı oyunun_adi.bulunduğu klasör adı
{
    public class PlayerController : MonoBehaviour
    {

        
        DefaultInput _input;
        bool _isForceUp;
        Mover _mover;
        

        private void Awake()
        {
           
            _input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());
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
        }

        //Fizik işlemleri
        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
            }
        }




       

    }//class

}
