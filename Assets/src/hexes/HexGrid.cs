using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class HexGrid : MonoBehaviour {
    Dictionary<HexPosition, HexSlot> map = new Dictionary<HexPosition, HexSlot>();
    public HexLayout layout;
    public int radius = 3;
    public HexSlot slotPrefab;

    public static HexGrid board;

    void Start() {
        layout = new HexLayout() { radius = slotPrefab.GetComponent<CircleCollider2D>().radius };
        map = new Dictionary<HexPosition, HexSlot>();
        new HexPosition(0, 0, 0).AreaInRadius(radius).ForEach(x => {
            CreateSlot(x);
        });
        board = this;
    }

    public HexSlot CreateSlot(HexPosition atPos) {
        var newSlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform);
        newSlot.Init(atPos, this);
        map[atPos] = newSlot;
        return newSlot;
    }

    public HexSlot this[HexPosition pos] { get {
        if(!map.ContainsKey(pos)) return null;
        return map[pos];
    } set {
        map[pos] = value;
    }}

    public List<HexSlot> AllSlots(Func<HexSlot, bool> action = null) {
        if(action == null) return map.Values.ToList();
        return map.Values.Where(action).ToList();
    }

    public List<HexTile> AllTiles(Func<HexTile, bool> action = null) {
        var tiles = map.Values.Where(x => x.tile != null).Select(x => x.tile).ToList();
        if(action == null) return tiles;
        return tiles.Where(action).ToList();
    }
}
