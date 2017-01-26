using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private int hp;
	private int movement;
	private int atk;
	private int range;
	private int x;
	private int y;
	private int lvl;

	public Character(int x, int y) {
		hp = 2;
		movement = 3;
		atk = 1;
		range = 1;
		lvl = 1;
		this.x = x; this.y = y;
	}

	public void move(int x, int y) {
		if(Math.abs(this.x - x) + Math.abs(this.y - y) <= movement) {
			this.x = x;
			this.y = y;
		}
	}

	public void attack() {

	}

	public void damage(int damage) {
		if(hp - damage >= 0) {
			hp -= damage;
		} else {
			hp = 0;
			die();
		}
	}

	public void die() {

	}

	public int getHP() {
		return hp;
	}

	public int getATK() {
		return atk;
	}

	public int getMovement() {
		return movement;
	}

	public int getRange() {
		return range;
	}

	public int getX() {
		return x;
	}

	public int getY() {
		return y;
	}

	public int getLVL() {
		return lvl;
	}

}
