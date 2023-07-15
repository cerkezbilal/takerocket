using System.Collections;
using System.Collections.Generic;
using takerocket.Inputs;
using UnityEngine;

namespace takerocket.Controllers//Klasörleme mantığı oyunun_adi.bulunduğu klasör adı
{
    public class PlayerController : MonoBehaviour
    {

        Rigidbody _rigidbody;
        DefaultInput _input;
        bool _isForceUp;
        [SerializeField] float force;
        

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _input = new DefaultInput();
        }

        //Input işlemleri
        private void Update()
        {
            Debug.Log(_input.IsForceUp);
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
                _rigidbody.AddForce(Vector3.up * force * Time.deltaTime );
            }
        }




       

    }//class

}
