using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexLayout {
    public float radius;
    
    private static readonly float sqrt3 = Mathf.Sqrt(3);
    public Vector3 HexCenter(HexPosition pos) {
        var x = radius * (3f/2 * pos.x);
        var y = radius * (sqrt3/2 * pos.x + sqrt3 * pos.z);
        
        return new Vector3(x, y, 0);
    }

    public HexPosition ScreenToHex(int x, int y) {
        var q = (2f/3 * x) / radius;
        var r = (-1f/3 * x + sqrt3/3 * y) / radius;

        return HexPosition.Rounded(q, -q-r, r);
    }
}
