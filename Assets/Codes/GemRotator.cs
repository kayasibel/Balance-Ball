using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotator : MonoBehaviour {

    public float x, y = 25, z;
   

    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}
