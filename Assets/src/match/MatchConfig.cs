using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchConfig : ScriptableObject {
    public List<MatchConfig_Player> players;
    public HexGrid grid;
}

public class MatchConfig_Player : ScriptableObject {
    public Player player;
    public Deck deck;
}