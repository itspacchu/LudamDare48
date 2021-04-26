using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMove : MonoBehaviour
{
    public ScoreCounter sc;

    public Canvas pausedCanvas;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float rotationSpeed = 50.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    private Vector3 move;
    public Animator animator;
    public AudioSource runsound;

    private bool lockCursor = true;
    public bool isPaused;
    public bool isDead = false;

    public DifficultyDepth difficultyDepth;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1f;
    }

    

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (PlayerPrefs.GetInt("highscore") < sc.Score)
            {
                PlayerPrefs.SetInt("highscore", sc.Score);
            }
            lockCursor = !lockCursor;
            if(isPaused){
                isPaused = false;
                Time.timeScale = 1f;
                pausedCanvas.enabled = false;
            }else{
               
                isPaused = true;
                pausedCanvas.enabled = true;
                Time.timeScale = 0.001f;
                
            }
            
        }
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravityValue * Time.deltaTime; // oof Gravity should be here
        float rot = Input.GetAxis("Horizontal")*Time.deltaTime*rotationSpeed;
        this.transform.Rotate(new Vector3(0,rot,0));
        controller.Move(playerVelocity + this.transform.forward * Time.deltaTime * playerSpeed);



        
        float speed = Mathf.Sqrt(controller.velocity.sqrMagnitude)/10f;
        // add poses in animator for still idling
        if(!isDead){
            controller.Move(playerVelocity * Time.deltaTime);
            if (PlayerPrefs.GetInt("highscore") < sc.Score)
            {
                PlayerPrefs.SetInt("highscore", sc.Score);
            }
        }
        
        animator.SetFloat("speed",speed);
        runsound.enabled = speed > 0.5;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("point")){
            sc.Score += 1;
            if(difficultyDepth.directionLight.intensity < 1.5f){
                difficultyDepth.directionLight.intensity += 0.1f;
            }
            
        }
    }

    public void ExitGame(){
        if (PlayerPrefs.GetInt("highscore") < sc.Score)
        {
            PlayerPrefs.SetInt("highscore", sc.Score);
        }
        Application.Quit();
    }

    public void RelodLevel(){
        if (PlayerPrefs.GetInt("highscore") < sc.Score)
        {
            PlayerPrefs.SetInt("highscore", sc.Score);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
