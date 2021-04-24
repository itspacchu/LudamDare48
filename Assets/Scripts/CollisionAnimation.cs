using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAnimation : MonoBehaviour
{

    public Animator Animesh;

    private void OnCollisionEnter(Collision other) {
        Animesh.SetTrigger("Invoke");
    }
}
