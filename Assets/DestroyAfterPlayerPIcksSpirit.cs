using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlayerPIcksSpirit : MonoBehaviour
{
    public ScoreCounter score;

    // Update is called once per frame
    void Update()
    {
        if(score.Score > 0){
            Destroy(this.gameObject);
        }
    }
}
