using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject,0.1f);
    }
    
}
