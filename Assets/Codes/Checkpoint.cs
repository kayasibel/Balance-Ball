using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public HealthManager theHealthMan;

	void Start () {
        theHealthMan = FindObjectOfType<HealthManager>();
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            theHealthMan.SetSpawnPoint(transform.position);//CHECKPOİNT NOKTASI
        }
    }
}
