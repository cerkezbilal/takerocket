using takerocket.Controllers;
using takerocket.Managers;
using UnityEngine;


namespace takerocket.Abstract.Controllers
{
    public abstract class WallController : MonoBehaviour
    {
        //Çarpma işlemi
        private void OnCollisionEnter(Collision collision)
        {
            //çarptığımız obje player controller a sahip ise bu player oluyor haliyle
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            //null değilse
            if (player != null && player.canMove)
            {
                GameManager.Instance.GameOver();
            }
        }




















    }//class
}

