using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSlot {
    public HexGrid grid;
    public HexPosition position;
    
    public HexSlot(HexPosition position, HexGrid grid) {
        this.position = position;
        this.grid = grid;
    }
}
