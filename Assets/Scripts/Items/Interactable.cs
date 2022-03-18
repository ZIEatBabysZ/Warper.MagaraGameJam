using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableSword : MonoBehaviour
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
        string Info = "You can deal damage with your new sword! (Gain 2 Mana Per Attack)";
        player.GetComponent<Sword>().isLocked = false;
        LocationManager.Instance.hasSword = true;
        var newParticle = Instantiate(spawnParticle, transform.position, Quaternion.identity);
        newSkillText.GetComponent<TextMeshProUGUI>().text = "Sword Skill Unlocked (Press '1')";
        newSkillText.GetComponent<TextMeshProUGUI>().enabled = true;
        informationBox.GetComponent<TextMeshProUGUI>().SetText(Info);
        informationBox.gameObject.SetActive(true);
        informationBox.GetComponent<informationBox>().hide();
        newSkillText.GetComponent<SkillText>().hide();
        Destroy(newParticle,2f);
        Destroy(gameObject);
    }


}
