using System;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExt {
	public static Color ShiftHSV(this Color color, float dh, float ds, float dv) {
        float h,s,v;
        Color.RGBToHSV(color, out h, out s, out v);
        h += dh;
        s += ds;
        v += dv;
        return Color.HSVToRGB(h, s, v);
	}
}