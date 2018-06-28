using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerController controller;
    public string nickname;
    public Character character;
    [ColorPalette("Player colors")] public Color color;
    public Deck deck;
    public GameObject hero;
}
