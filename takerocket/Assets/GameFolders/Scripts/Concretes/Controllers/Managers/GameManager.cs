using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace takerocket.Managers
{
    public class GameManager : MonoBehaviour
    {

        //Eventler oluşturcaz şimdi

        //GameOver Eventi 
        public event System.Action OnGameOver;

        public event System.Action OnMissionSucced;

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

        public void MissionSucced()
        {
            OnMissionSucced?.Invoke();//Görüyorsunuz mantık değişmiyor Action oluştur fonksiyonu yaz event i uyandır.
        }

        public void LoadLevelScene(int levelIndex = 0)
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));
        }

        private IEnumerator LoadLevelSceneAsync(int levelIndex)
        {
            //Aktif sahne neyse bi üstüne geç ya da ordan gelen level index neyse ona geç de denebilir.
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+levelIndex);
        }

        public void Exit()
        {
            Debug.Log("Çıkış yapıldı");
            Application.Quit();
        }

        
       









    }//class
}

