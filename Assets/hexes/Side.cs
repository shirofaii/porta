using System;
using UnityEngine;

[Flags]
public enum Side {
    none = 0,
    n    = 1,
    ne   = 2,
    se   = 4,
    s    = 8,
    sw   = 16,
    nw   = 32,
    all  = 63
}

public enum Direction { n, ne, se, s, sw, nw }

public static class DirectionExt {
    private static HexPosition[] vectors = {
        new HexPosition(0, 1, -1),
        new HexPosition(1, 0, -1),
        new HexPosition(1, -1, 0),
        new HexPosition(0, -1, 1),
        new HexPosition(-1, 0, 1),
        new HexPosition(-1, 1, 0)
    };
    public static HexPosition AsHexPosition(this Direction dir) {
        return vectors[(int)dir];
    }

    public static Direction Opposite(this Direction dir) {
        return dir.Rotate(3);
    }

    public static Direction Rotate(this Direction dir, int step) {
        if(step == 0) return dir;
        if(step > 0) return RotateRight(dir, step);
        if(step < 0) return RotateLeft(dir, -step);
        throw new InvalidOperationException();
    }
    public static Direction RotateRight(this Direction dir, int step = 1) {
        Debug.Assert(step > 0);

        step = step % 6;
        var result = (int)dir + step;
        if(result >= 6) {
            result -= 6;
        }
        return (Direction)result;
    }
    public static Direction RotateLeft(this Direction dir, int step = 1) {
        Debug.Assert(step > 0);

        step = step % 6;
        var result = (int)dir - step;
        if(result < 0) {
            result += 6;
        }
        return (Direction)result;
    }
}
