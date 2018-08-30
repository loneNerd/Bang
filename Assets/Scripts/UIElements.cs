﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    public Character Player;
    public Character[] Enemies;
    public ShowCards CardZone;
    public Sprite BackCard;
    public AudioSource audioSource;

    public static UIElements Instance;

    private void Awake()
    {
        Instance = this;
    }
}