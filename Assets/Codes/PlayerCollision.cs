using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public GameMngr mngr;

    public int damageToGive = 1;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pick Up")
        {
            //add time
            Destroy(other.gameObject);
            mngr.timeLeft += 5;
            mngr.EkZaman();
        }

 

        if (other.transform.root.tag == "Finished")
        {
            mngr.WinLevel();

        }

        if (other.gameObject.tag == "Hurt")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Hurt")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);

        }
    }

}
