using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int Score = 0;
    public TextMeshProUGUI ScoreMesh;

    private void Awake() {
        Score = 0;
    }

    private void Update() {
        ScoreMesh.SetText(Score.ToString());
    }
}
