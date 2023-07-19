using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace takerocket.Movements
{
    public class Fuel : MonoBehaviour
    {

        [SerializeField] float _maxFuel = 100f;//Depo full miktarı
        [SerializeField] float _currentFuel;//O an depoda kalan miktar
        [SerializeField] ParticleSystem _partical;//Roket ateşi efekti olacak

        public bool IsEmpty => _currentFuel < 1f;//Yakıt bitmiş kontrolü

        public float CurrentFuel => _currentFuel / _maxFuel;//Değer 0-1 arasında olduğu için maxFuel zaten 100 ya 100f yazmak yerine daha dinamik maxFuel dedim



        private void Awake()
        {
            _currentFuel = _maxFuel;//Oyun ilk başladığında depodaki full depoya eşit
        }
        
        //Yakıt artış fonksiyonu
        public void FuelIncrease(float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);//şimdi burda if ile bu bunu geçemez diye kontrol etmek yerine dedik ki hangisi küçükse onu al yani _currentFuel asla 100 ü geçemicek Burada şunu da yazabilirsik ama bu da daha kısa olanı

            //Eğer yakıt artıyorsa demek ki biz w ya basmıyoruz o zaman o ateşleme efekti oynamamalı o yüzden burda diyoruz ki eğer efekt oynuyorsa onu durdur.
            if (_partical.isPlaying)
            {
                _partical.Stop();
            }
        }

        //Yakış azalış fonksiyonu

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);
            //Burada da asla 0 ın altına düşmeyecek demek oluyor en kötü 0 olacak.

            if (_partical.isStopped)
            {
                _partical.Play();

                //Burada ateşleme efekti çalışmalı çünkü güç veriyoruz.
            }
        }












    }//class
}

