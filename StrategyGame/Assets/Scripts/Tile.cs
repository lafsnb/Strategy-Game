using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	private bool traversible;
    private bool occupied;

	public Tile() {
		traversible = true;
        occupied = false;
	}

	public void occupy() {
		traversible = false;
        occupied = true;
	}

    public bool getOccupied()
    {
        return occupied;
    }
}
