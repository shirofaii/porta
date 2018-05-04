using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HexPosition {
    public static readonly Direction[] AllDirections = (Direction[])Enum.GetValues(typeof(Direction));
    public int x, y, z;

    public HexPosition(int x, int y, int z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public HexPosition(HexPosition src) {
        this.x = src.x;
        this.y = src.y;
        this.z = src.z;
    }

    public HexPosition TowardsDirection(Direction dir) {
        return this + dir.AsHexPosition();
    }
    public HexPosition TowardsDirection(Direction dir, int step) {
        return this + (dir.AsHexPosition() * step);
    }

    public int DistanceTo(HexPosition b) {
        var a = this;
        return (Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y) + Math.Abs(a.z - b.z)) / 2;
    }

    public static HexPosition operator+(HexPosition a, HexPosition b) {
        var result = new HexPosition(a);
        a.x += b.x;
        a.y += b.y;
        a.z += b.z;
        return result;
    }

    public static HexPosition operator-(HexPosition a, HexPosition b) {
        var result = new HexPosition(a);
        a.x -= b.x;
        a.y -= b.y;
        a.z -= b.z;
        return result;
    }

    public static HexPosition operator*(HexPosition a, int k) {
        var result = new HexPosition(a);
        a.x *= k;
        a.y *= k;
        a.z *= k;
        return result;
    }

    public List<HexPosition> AreaInRadius(int radius) {
        var result = new List<HexPosition>() { this };
        var k = 1;
        while(k <= radius) {
            result.AddRange(Ring(k));
            k++;
        }
        return result;
    }

    public List<HexPosition> Ring(int radius) {
        if(radius == 0) return new List<HexPosition>() { this };

        var result = new List<HexPosition>();
        var cursor = TowardsDirection(Direction.se, radius);
        for(var i = 0; i < AllDirections.Length; i++) {
            for(var j = 0; j < radius; j++) {
                result.Add(cursor);
                cursor = TowardsDirection((Direction)i);
            }
        }
        return result;
    }

    public static bool operator==(HexPosition a, HexPosition b) {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }
    public static bool operator!=(HexPosition a, HexPosition b) {
        return !(a == b);
    }
    public override bool Equals(object obj) {
        if(!(obj is HexPosition)) return false;
        return Equals((HexPosition)obj);
    }
    public bool Equals(HexPosition pos) {
        return this == pos;
    }
    
    public override int GetHashCode() {
        unchecked {
            var hash = 17;
            hash *= 23 + x;
            hash *= 23 + y;
            hash *= 23 + z;
            return hash;
        }
    }
}
