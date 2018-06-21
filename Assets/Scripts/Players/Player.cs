﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image[] health;
    public static Image character;
    public static Image role;
    public static Image weapon;
    public static List<Sprite> hand = new List<Sprite>();
    public static List<Sprite> buffs = new List<Sprite>();

    int maxHealth = 4;
    public static int scope = 1;
    public static bool hasShield = false;
    public static bool onHorse = false;
    public static bool inJail = false;
    public static bool inRage = false;

    private void Awake()
    {
        //Find and add player character image to script
        character = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Image>();
        character.sprite = ComponentPreload.GetCharacter();

        //Find and add player role image to script
        role = character = GameObject.FindGameObjectWithTag("PlayerRole").GetComponent<Image>();
        role.sprite = ComponentPreload.GetRole();
        
        //Find and add player wepon image to script
        weapon = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<Image>();

        //Set player health
        if (character.sprite.name.Contains("paul_regred") || character.sprite.name.Contains("el_gringo")) maxHealth--;
        if (role.sprite.name.Contains("sheriff")) maxHealth++;

        for (int i = 0; i < maxHealth; i++)
        {
            health[i].gameObject.SetActive(true);
            hand.Add(PackAndDiscard.GetCard());
        }
        //For test
        hand.Add(Resources.Load<Sprite>("Images/Pack/appaloosa_ace_spades"));
        hand.Add(Resources.Load<Sprite>("Images/Pack/barrel_king_spades"));
        hand.Add(Resources.Load<Sprite>("Images/Pack/dynamite_2_hearts"));
        hand.Add(Resources.Load<Sprite>("Images/Pack/mustang_8_hearts"));
        hand.Add(Resources.Load<Sprite>("Images/Pack/rage_10_clubs"));
    }

    //Set maximum range to distance
    static int GetPlayerDistance()
    {
        string spreiteName = weapon.sprite.name;

        if (spreiteName.Contains("colt") && !spreiteName.Contains("colt_defalt")) return 2;
        else if (spreiteName.Contains("remington")) return 3;
        else if (spreiteName.Contains("carabine")) return 4;
        else if (spreiteName.Contains("volcano")) return 5;
        return 1;
    }
}
