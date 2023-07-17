using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace takerocket.Managers
{
    public class GameManager : MonoBehaviour
    {

        //Eventler oluşturcaz şimdi

        //GameOver Eventi 
        public event System.Action OnGameOver;

        //Bu sınıfa ulaşmak isteyenler burdan çağıracak ve static olacak değişmez olacak(tekil)
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            SingletonThisGameObject();
        }

      //Bu yazdıklarımız standart bunu hep kullanacaksınız şablon gibi

        private void SingletonThisGameObject()
        {
            //Bu prop hiç oluşmadıysa oluştur bu sınıfı ver ve yok etme sakın
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);//Bunu asla yok etme
            }
            else
            {
                //Eğer bu Instace oluşturulduysa önceden ikinciyi oluşturma yok et
                Destroy(this.gameObject);
            }
        }

        public void GameOver()
        {

            OnGameOver?.Invoke(); //Aşağıdakinin kısa kullanımı ? null kontrolü Invoke ise içinde bulunduğu fonksiyonu çalıştır demek.
           
        }

        //eventler bu şekilde çalışır. Şimdi bu fonksiyonu nerde tetikleyecepiz. FinisFloorController a gidip GameOver olduğu yerde bu eventi tetikleyeceğiz
       









    }//class
}

