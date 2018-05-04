using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid {
    Dictionary<HexPosition, HexSlot> map = new Dictionary<HexPosition, HexSlot>();

    public static HexGrid CreateMapWithRadius(uint radius) {
        var result = new HexGrid();

        return result;
    }

    public HexSlot CreateSlot(HexPosition atPos) {
        var newSlot = new HexSlot(atPos, this);
        map[atPos] = newSlot;
        return newSlot;
    }

    public HexSlot this[HexPosition pos] { get {
        if(!map.ContainsKey(pos)) return null;
        return map[pos];
    } set {
        map[pos] = value;
    } }


}
