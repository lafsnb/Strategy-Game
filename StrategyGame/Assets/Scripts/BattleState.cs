using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour {
    private Tile[,] board;
    private GameObject[,] cubes;
    private IList<Character> party;
    private IList<Character> enemies;
    private TurnOrder order;
    private Character current;
    private Vector3 tempPos;
    public GameObject cubePrefab;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    

    // Use this for initialization
    void Start () {
        board = new Board().getBoard();
        createParty();
        createEnemies();
        order = new TurnOrder(party, enemies);
        nextTurn();
        createBoard();
        
	}
	
	// Update is called once per frame
	void Update () {
        occupyTiles(party);
        occupyTiles(enemies);
        for (int i = 0; i < cubes.GetLength(0); i++)
        {
            for (int j = 0; j < cubes.GetLength(1); j++)
            {
                if (!board[i, j].getOccupied())
                {
                    cubes[i, j].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                }
                else if(current.getY() == i && current.x == j) // changed the getter to default
                {
                    cubes[i, j].GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                }
                else
                {
                    cubes[i, j].GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                }
            }
        }
    }

    private void createParty()
    {
        party = new List<Character>();
        party.Add(new Character(3, 2));
    }

    private void createEnemies()
    {
        enemies = new List<Character>();
        enemies.Add(new Character(1, 1));
    }

    private void createBoard()
    {
        cubes = new GameObject[board.GetLength(1), board.GetLength(0)];
        
        for (int i = 0; i < cubes.GetLength(0); i++)
        {
            for (int j = 0; j < cubes.GetLength(1); j++)
            {
                // This creates a instance of the cube prefab, we could also do this with
                // players and enemies.
                cubes[i, j] = Instantiate(cubePrefab); // different way of doing it.
                // cubes[i,j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes[i,j].transform.position = new Vector3(i, 0, j);
                cubes[i, j].transform.parent = this.transform;

                // created an enemy and player where the they are supposed to go
                // Also I think this is probably not the best way to do it.
                CreatePlayers(enemies, i, j, true);
                CreatePlayers(party, i, j, false);
            }
        }
    }

    private void CreatePlayers(IList<Character> chars, int i, int j, bool enemy) {
        foreach(Character c in chars) {
                if (c.x == i && c.getY() == j) {
                    tempPos = cubes[i, j].transform.position;
                    tempPos.y = cubes[i, j].transform.position.y + 1;
                    if(enemy)
                        Instantiate(enemyPrefab, tempPos, Quaternion.identity);
                    else
                        Instantiate(playerPrefab, tempPos, Quaternion.identity);
                }
            }
    }

    private void occupyTiles(IList<Character> list)
    {
        foreach (Character c in list)
        {
            if (c.x < board.GetLength(1) && c.getY() < board.GetLength(0))
            {
                board[c.getY(), c.x].occupy();
            }
        }
    }

    private void nextTurn()
    {
        current = order.getNext();
    }

}
