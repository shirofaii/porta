using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HexGrid {
    Dictionary<HexPosition, HexSlot> map = new Dictionary<HexPosition, HexSlot>();
    public HexLayout layout = new HexLayout() { radius = 1f };

    public static HexGrid CreateMapWithRadius(int radius) {
        var result = new HexGrid();
        new HexPosition(0, 0, 0).AreaInRadius(radius).ForEach(x => {
            result[x] = new HexSlot(x, result);
        });
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
