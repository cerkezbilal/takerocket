using System.Collections;
using System.Collections.Generic;
using takerocket.Abstract.Utilities;
using UnityEngine;

namespace takerocket.Managers
{
    public class SoundManager : SingletonThisObject<SoundManager>
    {

        private void Awake()
        {
            //protected dediğimiz an ulaştık hocam<T> niye koymadık o sınıfı çağırırken kullanılır. biz burda method çağırıdk o yüzden method adını verdik paremetesini de yolladık artık bu method Awake de çalışacak haliyle direk instance yi kendi kendine oluşturcak
            SingletonThisGameObject(this);
        }






    }//class
}

