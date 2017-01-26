using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	private Tile[10,10] board;
	public Board() {
		foreach (Tile tile in board)
		{
			tile = new Tile();
		}
	}
}
