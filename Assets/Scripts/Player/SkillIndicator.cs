using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SkillIndicator : MonoBehaviour
{
    public Light2D lightComponent;

    private void Awake()
    {
        lightComponent = GetComponent<Light2D>();
    }
    public void changeSkillLight(InputManager.skills skill)
    {
        switch (skill)
        {
            case InputManager.skills.Sword:
                lightComponent.color = Color.white;
                return;
            case InputManager.skills.FireSkill:
                lightComponent.color = Color.red;
                return;
            case InputManager.skills.TelekinesisSkill:
                lightComponent.color = Color.blue;
                return;
            default:
                return;
        }
    }
}
