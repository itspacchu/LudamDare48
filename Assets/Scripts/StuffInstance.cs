/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffInstance : MonoBehaviour
{
    public float size;
    public Vector2 regionSize = Vector2.one;
    public int rejectSamples = 30;

    public GameObject Treefab;
    //public GameObject Grassfab;

    List<Vector2> points;
    void Start()
    {
        size = this.gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    private void OnValidate() {
        points = DiskSampler.GeneratePoints(size/2,regionSize);
        if(points!=null){
            foreach(Vector2 point in points){
                Instantiate(Treefab,new Vector3(point.x , 0 , point.y),Quaternion.identity);
            }
        }
        
    }
}
*/