using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score = 0;

    private void Awake() {
        Score = 0;
    }
}
