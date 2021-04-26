using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkRandomness : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] rocks;
    public float no_of_trees = 2f;
    public float no_of_rocks = 2f;

    public GameObject Pellet;

    private void Awake() {
        for(int i = 0;i <= no_of_trees;i++){
            var myObj = Instantiate(trees[Random.Range(0,trees.Length)]);
            myObj.transform.parent = this.gameObject.transform;
            myObj.transform.localPosition = new Vector3(Random.Range(-4f,4f),0,Random.Range(-4f, 4f));
            var rot = myObj.transform.localRotation.eulerAngles;
            rot = new Vector3(0,Random.Range(0, 2 * Mathf.PI),Random.Range(0, 2 * Mathf.PI));
        }
        if(Random.Range(0,3) == 2){

        for (int i = 0; i <= no_of_rocks; i++)
        {
            var myObj1 = Instantiate(rocks[Random.Range(0, rocks.Length)]);
            myObj1.transform.parent = this.gameObject.transform;
            myObj1.transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
            var rot = myObj1.transform.localRotation.eulerAngles;
            rot = new Vector3(0, Random.Range(0, 2 * Mathf.PI), Random.Range(0, 2 * Mathf.PI));
        }
        }

        if(Random.Range(0,6) == 4){
            var MyPellet = Instantiate(Pellet);
            MyPellet.transform.parent = this.gameObject.transform;
            MyPellet.transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
            AudioSource MyPelletSrc = GetComponentInChildren<AudioSource>();
            MyPelletSrc.pitch = Random.Range(-6,6)/2f;

        }
    }
}
