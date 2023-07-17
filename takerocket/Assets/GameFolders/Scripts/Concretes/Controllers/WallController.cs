using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace takerocket.Controllers
{
    public class WallController : MonoBehaviour
    {
        //Çarpma işlemi
        private void OnCollisionEnter(Collision collision)
        {
            //çarptığımız obje player controller a sahip ise bu player oluyor haliyle
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            //null değilse
            if (player != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }




















    }//class
}

