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

public enum Direction {
    n    = 1,
    ne   = 2,
    se   = 3,
    s    = 4,
    sw   = 5,
    nw   = 6
}

public static class DirectionExt {
    public static Direction Opposite(this Direction dir) {
        switch(dir) {
            case Direction.n: return Direction.s;
            case Direction.ne: return Direction.sw;
            case Direction.se: return Direction.nw;
            case Direction.s: return Direction.n;
            case Direction.sw: return Direction.ne;
            case Direction.nw: return Direction.se;
            default: throw new Exception();
        }
    }

    public static HexPosition AsHexPosition(this Direction dir) {
        switch(dir) {
            case Direction.n: return new HexPosition(0, 1, -1);
            case Direction.ne: return new HexPosition(1, 0, -1);
            case Direction.se: return new HexPosition(1, -1, 0);
            case Direction.s: return new HexPosition(0, -1, 1);
            case Direction.sw: return new HexPosition(-1, 0, 1);
            case Direction.nw: return new HexPosition(-1, 1, 0);
            default: throw new Exception();
        }
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
        if(result > 6) {
            result -= 6;
        }
        return (Direction)result;
    }
    public static Direction RotateLeft(this Direction dir, int step = 1) {
        Debug.Assert(step > 0);

        step = step % 6;
        var result = (int)dir - step;
        if(result <= 0) {
            result += 6;
        }
        return (Direction)result;
    }
}
