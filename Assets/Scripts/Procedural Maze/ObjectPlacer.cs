using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] RecursiveDungeon maze;
    [SerializeField] GameObject blueDiamonds;
    [SerializeField] GameObject greenDiamonds;
    [SerializeField] GameObject pinkDiamonds;
    [SerializeField] GameObject redGoldCoins;
    [SerializeField] GameObject rock;
    [SerializeField] GameObject grenade;
    [SerializeField] float yValue;
    [SerializeField] int maxGrenade;
    [SerializeField] int maxRock;
    [SerializeField] int maxGoldCoins;
    [SerializeField] int maxBlueGems;
    [SerializeField] int maxGreenGems;
    [SerializeField] int maxPinkGems;
    [SerializeField] Transform PointsParent;
    // Start is called before the first frame update
    public void PlaceBlueDiamonds()
    {
        maze.LoadMap();
        for(int i = 0; i < maxBlueGems; i++)
        {
            int x = Random.Range(0, maze.width);
            int z = Random.Range(0, maze.depth);
            Vector3 position = new Vector3(x * maze.scale + Random.Range(-1, 2), 0.03f, z * maze.scale + Random.Range(-1, 2));
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0, 180), 0, Random.Range(0, 360)));
            GameObject diamond = Instantiate(blueDiamonds, position, rot);
            diamond.transform.SetParent(PointsParent);
        }
    }
    public void PlaceGoldCoins()
    {
        maze.LoadMap();
        for (int i = 0; i < maxGoldCoins; i++)
        {
            int x = Random.Range(0, maze.width);
            int z = Random.Range(0, maze.depth);
            Vector3 position = new Vector3(x * maze.scale + Random.Range(-1, 2), 0.03f, z * maze.scale + Random.Range(-1, 2));
            GameObject diamond = Instantiate(redGoldCoins, position, Quaternion.identity);
            diamond.transform.SetParent(PointsParent);
        }

    }
    public void PlacePinkDiamonds()
    {
        maze.LoadMap();
        for (int i = 0; i < maxPinkGems; i++)
        {
            int x = Random.Range(0, maze.width);
            int z = Random.Range(0, maze.depth);
            Vector3 position = new Vector3(x * maze.scale + Random.Range(-1, 2), 0.03f, z * maze.scale + Random.Range(-1, 2));
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0, 180), 0, Random.Range(0, 360)));
            GameObject diamond = Instantiate(pinkDiamonds, position, rot);
            diamond.transform.SetParent(PointsParent);
        }
    }
    public void PlaceGreenDiamonds()
    {
        maze.LoadMap();
        for (int i = 0; i < maxGreenGems; i++)
        {
            int x = Random.Range(0, maze.width);
            int z = Random.Range(0, maze.depth);
            Vector3 position = new Vector3(x * maze.scale + Random.Range(-1, 2), 0.03f, z * maze.scale + Random.Range(-1, 2));
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0, 180), 0, Random.Range(0, 360)));
            GameObject diamond = Instantiate(greenDiamonds, position, rot);
            diamond.transform.SetParent(PointsParent);
        }
    }
    public void PlaceRocks()
    {
        int numOfRocksPlaced = 0;
        maze.LoadMap();
        for (int z = 0; z < maze.depth; z++)
        {
            for (int x = 0; x < maze.width; x++)
            {
                if (maze.map[x, z] == 1) continue;
                if (Random.Range(0, 100) > 85 && numOfRocksPlaced <= maxRock)
                {
                    Vector3 position = new Vector3(x * maze.scale + Random.Range(-1, 2), yValue, z * maze.scale + Random.Range(-1, 2));
                    Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0, 180), 0, Random.Range(0, 360)));
                    GameObject rock = Instantiate(this.rock, position, rot);
                    rock.transform.SetParent(this.transform);
                    numOfRocksPlaced++;
                }
            }
        }
    }
}
