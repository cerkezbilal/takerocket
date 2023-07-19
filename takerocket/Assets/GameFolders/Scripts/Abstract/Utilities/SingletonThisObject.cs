using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace takerocket.Abstract.Utilities
{
    public abstract class SingletonThisObject<T> : MonoBehaviour
    {
        //Bu sınıfa ulaşmak isteyenler burdan çağıracak ve static olacak değişmez olacak(tekil)
        public static T Instance { get; private set; }

        //Bu yazdıklarımız standart bunu hep kullanacaksınız şablon gibi

        protected void SingletonThisGameObject(T entity)//protected ne demek hem kendi sınıfı hemde miraz verdiği sınıflarda kullanılabilir demek
        {
            //Bu prop hiç oluşmadıysa oluştur bu sınıfı ver ve yok etme sakın
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);//Bunu asla yok etme
            }
            else
            {
                //Eğer bu Instace oluşturulduysa önceden ikinciyi oluşturma yok et
                Destroy(this.gameObject);
            }
        }
    }

}
