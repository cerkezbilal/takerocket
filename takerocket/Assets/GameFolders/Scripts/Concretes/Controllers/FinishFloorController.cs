using System.Collections;
using System.Collections.Generic;
using takerocket.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace takerocket.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {

        [SerializeField] GameObject _finishFireWorks;
        [SerializeField] GameObject _finisLight;


        //Roket finishFloor a tepeden değdiğinde efektler çalışacak.

        private void OnCollisionEnter(Collision collision)
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player == null) return;

            //İlk değdiği demek oluyor tepeden ya da ya da aşağıda değebilir. tepeden aşağıya demek bu 
            if (collision.GetContact(0).normal.y == -1)
            {
                //Efektleri göster demek
                _finishFireWorks.gameObject.SetActive(true);
                _finisLight.gameObject.SetActive(true);
            }
            else
            {
                //GameOver işlemi
                GameManager.Instance.GameOver();
            }
            
        }










    }//class
}

