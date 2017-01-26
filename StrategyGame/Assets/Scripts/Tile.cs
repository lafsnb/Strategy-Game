using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	private bool traversible;

	public Tile() {
		traversible = true;
	}

	public void occupy() {
		traversible = false;
	}
}
