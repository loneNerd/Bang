﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCards : MonoBehaviour
{
    [SerializeField] private GameObject cardSpawn;
    [SerializeField] private Button buttonTemplate;

    //Create player card in new Zone
    private void Awake ()
    {
        foreach(Sprite sp in Player.characterInfo.hand)
        {
            Button button = Instantiate<Button>(buttonTemplate, cardSpawn.transform);
            button.image.sprite = sp;
            button.tag = GetTag(sp);
            button.name = sp.name;
        }
	}

    //Set tag to card
    string GetTag(Sprite sp)
    {
        if (sp.name.Contains("volcano") || sp.name.Contains("remington") ||
            sp.name.Contains("colt") || sp.name.Contains("carabine")) return "Gun";
        else if (sp.name.Contains("appaloosa") || sp.name.Contains("barrel") ||
            sp.name.Contains("dynamite") || sp.name.Contains("jail") ||
            sp.name.Contains("mustang") || sp.name.Contains("rage")) return "Buff";
        return "Act";
    }

    //Close(delete) zone
    public void Close()
    {
        Destroy(this.gameObject);
    }
}
