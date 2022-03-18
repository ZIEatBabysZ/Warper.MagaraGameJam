using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public bool isGameStarted = false;
    public GameObject postProcessing;
    private DepthOfField dof;
    public float startSpeed = 1f;
    public GameObject player;
    public GameObject mainMenu;
    public GameObject hud;
    public bool isCompleted = false;


    private void Awake()
    {
        postProcessing = GameObject.FindGameObjectWithTag("PostProcess");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void startGame()
    {
        isGameStarted = true;
        LocationManager.Instance.isAlreadyStarted = true;
    }
    private void Start()
    {
        if (LocationManager.Instance.isAlreadyStarted)
        {
            isGameStarted = true;
            if(SceneManager.GetActiveScene().buildIndex == 0) { 
            player.transform.position = LocationManager.Instance.spawnLocation + new Vector2(-1,-1);
                Camera.main.transform.position = LocationManager.Instance.CameraLocation;
            }
            mainMenu.SetActive(false);
            hud.SetActive(true);
            Camera.main.GetComponent<Camera>().orthographicSize = 7;
        }
    }

    private void Update()
    {
       
 
        if (isGameStarted && isCompleted == false) {
            Camera.main.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Camera.main.GetComponent<Camera>().orthographicSize, 7, Time.fixedDeltaTime * startSpeed);
            postProcessing.GetComponent<Volume>().profile.TryGet(out dof);
            dof.focalLength.value = Mathf.Lerp(dof.focalLength.value, 0, Time.fixedDeltaTime * startSpeed);
        }


        if(Camera.main.GetComponent<Camera>().orthographicSize < 7.1f && dof.focalLength.value < 2 && isCompleted == false)
        {
            player.GetComponent<InputManager>().isGameStart = true;
            mainMenu.SetActive(false);
            hud.SetActive(true);
            isCompleted = true;
        }

        
    }
}
