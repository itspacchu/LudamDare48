using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricFogAndMist2;
public class DifficultyDepth : MonoBehaviour
{

    public float difficultyMeter = 0;
    public Light directionLight;
    public int lives = 2;

    

    public VolumetricFogProfile vfm;

    public Color StartColor;
    public Color EndColor;

    public mainMove mainMove;

    private void Start() {
        directionLight.color = StartColor;
        directionLight.intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(difficultyMeter < 200){
            difficultyMeter += Time.deltaTime;
            lives -= 1;
        } 
        if(directionLight.intensity > 0.1f){
            directionLight.intensity -= 0.5f*Mathf.Clamp(difficultyMeter/500f,0,1)*Time.deltaTime;
        }else{
            directionLight.intensity -= 0.05f * Mathf.Clamp(difficultyMeter / 600f, 0, 1) * Time.deltaTime;
        }
        directionLight.color = Color.Lerp(directionLight.color , EndColor , Time.deltaTime*0.01f);

        if(lives == 0){
            mainMove.animator.SetTrigger("death");
            mainMove.isDead = true;
        }
    }
}
