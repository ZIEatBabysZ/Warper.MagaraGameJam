using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableFire : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnParticle;
    public GameObject newSkillText;
    public GameObject informationBox;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       // newSkillText = GameObject.FindGameObjectWithTag("NewSkillText");
    }

    public void Interact()
    {
        string Info = "You can deal damage with your new fire skill!";
        player.GetComponent<Fire>().isLocked = false;
        LocationManager.Instance.hasFire = true;
        var newParticle = Instantiate(spawnParticle, transform.position, Quaternion.identity);
        newSkillText.GetComponent<TextMeshProUGUI>().text = "Fire Skill Unlocked (Press '2')";
        newSkillText.GetComponent<TextMeshProUGUI>().enabled = true;
        informationBox.GetComponent<TextMeshProUGUI>().SetText(Info);
        informationBox.gameObject.SetActive(true);
        informationBox.GetComponent<informationBox>().hide();
        newSkillText.GetComponent<SkillText>().hide();
        Destroy(newParticle, 2f);
        Destroy(gameObject);
    }
}
