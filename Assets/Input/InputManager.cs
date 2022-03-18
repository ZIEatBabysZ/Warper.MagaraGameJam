using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public PlayerControls playerControls;
    public PlayerManager playerManager;
    public Telekinesis telekinesis;
    public Fire fire;
    public Sword sword;
    public Texture2D[] mouseTextures;
    public SkillIndicator skillIndicator;
    public Vector2 MouseAxis;
    public Vector2 MovementAxis;
    public GameObject gameManager;
    public bool isDragging = false;
    public bool isHoldingDown = false;
    public bool isGameStart = false;
     public enum skills
    {
        Sword,
        FireSkill,
        TelekinesisSkill,
        None
    }
    public skills currentSkill;






    private void Awake()
    {
        playerControls = new PlayerControls();
        telekinesis = GetComponent<Telekinesis>();
        skillIndicator = transform.GetChild(1).GetComponent<SkillIndicator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        playerManager = GetComponent<PlayerManager>();
        fire = GetComponent<Fire>();
        sword = GetComponent<Sword>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    void Start()
    {
        playerControls.Mouse.MouseClick.started += ctx => OnClickStarted();
        playerControls.Mouse.MouseClick.canceled += ctx => OnClickEnded();
        playerControls.Mouse.MouseRightClick.performed += ctx => OnRightClick();
        playerControls.Skill.Sword.performed += ctx => SkillChange(skills.Sword);
        playerControls.Skill.Fire.performed += ctx => SkillChange(skills.FireSkill);
        playerControls.Skill.Telekinesis.performed += ctx => SkillChange(skills.TelekinesisSkill);
        playerControls.Create.Knife.performed += ctx => CreateObject("knife");
        playerControls.Interact.Interact.performed += ctx => MakeInteraction();


        if (LocationManager.Instance.hasSword)
        {
            sword.isLocked = false;
        }
        if (LocationManager.Instance.hasFire)
        {
            fire.isLocked = false;
        }
        if (LocationManager.Instance.hasTelekinesis)
        {
            telekinesis.isLocked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart) { 
        MovementAxis = playerControls.Movement.MovementAxis.ReadValue<Vector2>();
        MouseAxis = playerControls.Mouse.Mouse.ReadValue<Vector2>();
        }

    }

    void OnClickStarted()
    {
        switch (currentSkill)
        {
            case skills.Sword:
                sword.OnClick();
                break;
            case skills.FireSkill:
                fire.OnClickStarted();
                break;
            case skills.TelekinesisSkill:
                telekinesis.OnClickStarted();
                return;
            case skills.None:
                return;
            default:
                break;
        }
    }

    void OnClickEnded()
    {
        isHoldingDown = false;
       // isDragging = false;
    }

    void OnRightClick()
    {
        if(currentSkill == InputManager.skills.TelekinesisSkill) { 
        telekinesis.Shoot();
        }
    }

    void SkillChange(skills skill)
    {
        
        if(skill == skills.Sword)
        {
            if (sword.isLocked == true) return;
            currentSkill = skill;
        }else if(skill == skills.FireSkill)
        {
            if (fire.isLocked == true) return;
            currentSkill = skill;
        }else if(skill == skills.TelekinesisSkill)
        {
            if (telekinesis.isLocked == true) return;
            currentSkill = skill;
        }



        skillIndicator.changeSkillLight(skill);
        switch (currentSkill)
        {
            case skills.Sword:
                if (sword.isLocked == true) return;
                Cursor.SetCursor(mouseTextures[0], Vector2.zero,CursorMode.Auto);
                break;
            case skills.FireSkill:
                if (fire.isLocked == true) return;
                Cursor.SetCursor(mouseTextures[1], Vector2.zero, CursorMode.Auto);
                break;
            case skills.TelekinesisSkill:
                if (telekinesis.isLocked == true) return;
                Cursor.SetCursor(mouseTextures[2], Vector2.zero, CursorMode.Auto);
                break;
            default:
                break;
        }

    }

    void MakeInteraction()
    {
        transform.GetChild(8).GetComponent<Interact>().interact();
    }

    void CreateObject(string objectName)
    {
        if(currentSkill == InputManager.skills.TelekinesisSkill && playerManager.stamina >= 10 && telekinesis.isLocked == false) { 
        gameManager.GetComponent<ObjectCreation>().CreateTrigger(objectName);
        }
        else
        {
            Debug.Log("Wrong Skill");
        }
    }
}
