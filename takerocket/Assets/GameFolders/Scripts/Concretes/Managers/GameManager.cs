using System.Collections;
using System.Collections.Generic;
using takerocket.Abstract.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace takerocket.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {

        //Eventler oluşturcaz şimdi

        //GameOver Eventi 
        public event System.Action OnGameOver;

        public event System.Action OnMissionSucced;

       

        private void Awake()
        {
            SingletonThisGameObject(this);
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

        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }

        private IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
        }

        public void Exit()
        {
            Debug.Log("Çıkış yapıldı");
            Application.Quit();
        }

        
       









    }//class
}

