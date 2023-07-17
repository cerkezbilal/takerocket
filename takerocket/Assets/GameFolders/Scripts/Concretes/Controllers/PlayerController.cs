using System.Collections;
using System.Collections.Generic;
using takerocket.Inputs;
using takerocket.Managers;
using takerocket.Movements;
using UnityEngine;

namespace takerocket.Controllers//Klasörleme mantığı oyunun_adi.bulunduğu klasör adı
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;
        DefaultInput _input;
        bool _isForceUp;
        Mover _mover;
        Fuel _fuel;

        float _leftRight;
        Rotator _rotator;

        bool _canMove;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;


        private void OnEnable()
        {
            //Eventlerin çağırılma şeklidir bu script oluşturulduğunda çağır anlamında 
            GameManager.Instance.OnGameOver += HandleOnEventTrigger;

            GameManager.Instance.OnMissionSucced += HandleOnEventTrigger;
        }

        

        private void OnDisable()
        {
            //Bu script bitince event i sonlandır şişme yapmaması için
            GameManager.Instance.OnGameOver -= HandleOnEventTrigger;
            GameManager.Instance.OnMissionSucced -= HandleOnEventTrigger;
        }


        private void Awake()
        {
           
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();
        }

        private void Start()
        {
            _canMove = true;
        }

        //Input işlemleri
        private void Update()
        {
            if (!_canMove) return;
            if (_input.IsForceUp && !_fuel.IsEmpty)//yani benzini varsa
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
                _fuel.FuelIncrease(0.01f);//Burası w ya basmadığım yer o yüzden artış burada olacak
            }

            _leftRight = _input.LeftRight;
        }

        //Fizik işlemleri
        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_leftRight);

        }

        public void HandleOnEventTrigger()
        {
            _canMove = false;//Yandıysak kontrol edeme
            _isForceUp = false;//yani ateş efekti falan çalışmıcak
            _leftRight = 0;//Yani duracak
            _fuel.FuelIncrease(0f);//Ateş sönecek

        }

        //Yani eventleri şu şekilde yaparsınız
        //1)Game Manager de even action tanımlanır
        //2)Eventi aktif eden fonksiyon yazılır GameManagerde.
        //3)OnGameOver?.Invoke(); şu ifade eventi çağırtmak demek yani gameOver çağırdığımız her yerde bu event çalışacak
        //4)Peki eventte ne olacağını nerde belirliyoruz onu da bu olay kimle ilgiliyse orada bu olayda ne istiyoruz player hareket edemesin ateş efekti çalışması. sağa sola gidemesin vb. onun için player controllerde eventin içini tasarlamamız lazım
        //5)Peki eventi biz nasıl tasarlıcaz OnEnable(Bazen hata verir Start da olur) ve OnDisable fonksiyonlarını kullanmalıyız
        //6)Kullanımı şu şekildedir:  GameManager.Instance.OnGameOver += HandleOnEventTrigger; yani bu şu demek GameManager de oluşturduğumu OnGameOver eventine ekle neyi bu yeni fonksiyonu. Yani o eventin içine bu fonksiyonu eklemek demek +=
        //7)O fonksiyona da ne yazarsanız GameOver çağırdığınız yerde event tetiklenir eventte bu içine yazılan fonksiyondakileri yapar






    }//class

}
