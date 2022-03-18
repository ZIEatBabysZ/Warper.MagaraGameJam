using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InteractableTelekinesis : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnParticle;
    public GameObject newSkillText;
    public GameObject informationBox;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      //  newSkillText = GameObject.FindGameObjectWithTag("NewSkillText");
    }

    public void Interact()
    {
        Debug.Log("test");
        string Info = "You can create a dagger and throw it with your new telekinesis skill!";
        player.GetComponent<Telekinesis>().isLocked = false;
        LocationManager.Instance.hasTelekinesis = true;
        var newParticle = Instantiate(spawnParticle, transform.position, Quaternion.identity);
        newSkillText.GetComponent<TextMeshProUGUI>().text = "Telekinesis Skill Unlocked (Press '3')";
        newSkillText.GetComponent<TextMeshProUGUI>().enabled = true;
        informationBox.GetComponent<TextMeshProUGUI>().SetText(Info);
        informationBox.gameObject.SetActive(true);
        informationBox.GetComponent<informationBox>().hide();
        newSkillText.GetComponent<SkillText>().hide();
        Destroy(newParticle, 2f);
        Destroy(gameObject);
    }
}
