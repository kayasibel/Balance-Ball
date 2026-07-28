using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Ball;


    public class HealthManager : MonoBehaviour
    {
        public GameMngr mngr;

        public int currentHealth;
        public int maxHealth;

        private bool isRespawning;
        private Vector3 respawnPoint;
        private Rigidbody playerRb;


        public GameObject thePlayer;
        public float respawnLength;

        public GameObject[] hearts;

        void Start()
        {
            currentHealth = maxHealth;

            playerRb = thePlayer.GetComponent<Rigidbody>();

            // Ilk checkpoint'e ulasilmadan olunurse dunya merkezine degil, baslangic noktasina don.
            respawnPoint = thePlayer.transform.position;

            HeartSystem();

        }


        public void HurtPlayer(int damage)
        {
            currentHealth -= damage;

            Respawn();
            HeartSystem();

            if (currentHealth <= 0)//şimdiki can 0'a eşit olduğunda gameover metodunu çalıştır
            {
                mngr.GameOver();
            }
        }

        private void Respawn()
        {

            if (!isRespawning)
            {
                StartCoroutine("RespawnCo");
            }
        }

        public IEnumerator RespawnCo()
        {


            isRespawning = true;
            thePlayer.gameObject.SetActive(false);

            yield return new WaitForSeconds(respawnLength);//respawnLength uzunluğu kadar bekle
            isRespawning = false;

            //once konumu ayarla, sonra aktif et. Ters sirada top bir kare olum noktasinda canlaniyor.
            thePlayer.transform.position = respawnPoint;//playerı respawnpoint noktasına götür
            thePlayer.gameObject.SetActive(true);

            //SetActive(false) hizi temizlemez; olum anindaki hiz korunur. Fizik adimi gelmeden sifirla.
            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }
        }



        public void SetSpawnPoint(Vector3 newPosition)
        {
            respawnPoint = newPosition;
        }

        public void HeartSystem()
        {
            for (int i = 0; i < maxHealth; i++)
            {
                hearts[i].SetActive(false);
            }
            for (int i = 0; i < currentHealth; i++)
            {
                hearts[i].SetActive(true);
            }
        }
    }
