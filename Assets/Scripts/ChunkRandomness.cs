using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkRandomness : MonoBehaviour
{
    public GameObject[] trees;
    public float no_of_trees = 2f;

    private void Awake() {
        for(int i = 0;i <= no_of_trees;i++){
            var myObj = Instantiate(trees[Random.Range(0,trees.Length)]);
            myObj.transform.parent = this.gameObject.transform;
            myObj.transform.localPosition = new Vector3(Random.Range(-4f,4f),0,Random.Range(-4f, 4f));
            var rot = myObj.transform.localRotation.eulerAngles.z;
            rot = Random.Range(0, 2 * Mathf.PI);
        }
    }
}
