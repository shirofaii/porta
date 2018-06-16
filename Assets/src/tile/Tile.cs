using Sirenix.OdinInspector;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public enum Type { Hero, Unit, Action, Upgrade, Floor };

    [EnumToggleButtons, HideLabel] public Type type;
    private Sector[] sectors = new Sector[6];
    [DrawWithUnity] public GameObject[] sectorLocators;
    public GameObject sectorPrefab;

    [Button] public void SetupSectors() {
        for(var i = 0; i < sectorLocators.Length; i++) {
            var parent = sectorLocators[i].transform;
            foreach(Transform child in parent) {
                DestroyImmediate(child.gameObject);
            }
            var prefab = Instantiate(sectorPrefab, parent);
            sectors[i] = prefab.GetComponent<Sector>();
        }
    }

    public Sector this[Direction dir] { get {
        return sectors[(int)dir];
    } }

    public bool isHero { get { return type == Type.Hero; } }
}
