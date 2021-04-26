using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Next : MonoBehaviour
{
    public TextMeshProUGUI highscoretext;
    // Update is called once per frame
    private void Awake() {
        string msg = "Highscore :" + PlayerPrefs.GetInt("highscore").ToString();
        if(PlayerPrefs.GetInt("highscore") < 1){
            highscoretext.enabled = false;
        }else{
            highscoretext.enabled = true;
            highscoretext.SetText(msg) ;
        }
    }

    public void GoNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
