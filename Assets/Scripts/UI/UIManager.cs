using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI healthText;
    public PlayerManager playerManager;
    public InputManager inputManager;
    public GameObject itemCreateWrapper;
    public GameObject monsterCountText;
    public GameLogic gameLogic;

    private void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        gameLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameLogic>();

    }

    private void Update()
    { 
        healthSlider.value = Mathf.Lerp(healthSlider.value, playerManager.health, Time.fixedDeltaTime);
        staminaSlider.value = Mathf.Lerp(staminaSlider.value, playerManager.stamina, Time.fixedDeltaTime);
        staminaSlider.maxValue = playerManager.maxStamina;
        healthSlider.maxValue = playerManager.maxHealth;
        healthText.text = playerManager.health.ToString() + " / " + playerManager.maxHealth.ToString();
        staminaText.text = playerManager.stamina.ToString() + " / " + playerManager.maxStamina.ToString();

        if(inputManager.currentSkill != InputManager.skills.TelekinesisSkill)
        {
            itemCreateWrapper.SetActive(false);
        }
        else
        {
            itemCreateWrapper.SetActive(true);
        }


        if(gameLogic.monsterLeft > 0)
        {
            monsterCountText.SetActive(true);
            monsterCountText.GetComponent<TextMeshProUGUI>().text = "Remaining Monsters : " + gameLogic.monsterLeft.ToString(); 
        }
        else
        {
            monsterCountText.SetActive(false);
        }

    }



    public void tryAgain()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(0);

    }
    public void quit()
    {
        Application.Quit();
    }
}
