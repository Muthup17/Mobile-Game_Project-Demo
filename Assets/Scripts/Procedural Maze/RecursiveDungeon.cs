using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Saving;
public class RecursiveDungeon : Maze, ISaveable
{
    public SavingSystem ss;
    public override void Generate()
    {
        this.transform.position = Vector3.zero;
        Generate(5, 5);
    }

    public override void AddRooms(int count, int minSize, int maxSize)
    {
        for (int c = 0; c < count; c++)
        {
            int startX = Random.Range(3, width - 3);
            int startZ = Random.Range(3, depth - 3);
            int roomWidth = Random.Range(minSize, maxSize);
            int roomDepth = Random.Range(minSize, maxSize);

            for (int x = startX; x < width - 3 && x < startX + roomWidth; x++)
            {
                for (int z = startZ; z < depth - 3 && z < startZ + roomDepth; z++)
                {
                    map[x, z] = 0;
                }
            }
        }
    }

    void Generate(int x, int z)
    {
        if (CountSquareNeighbours(x, z) >= 2) return;
        map[x, z] = 0;

        directions.Shuffle();

        Generate(x + directions[0].x, z + directions[0].z);
        Generate(x + directions[1].x, z + directions[1].z);
        Generate(x + directions[2].x, z + directions[2].z);
        Generate(x + directions[3].x, z + directions[3].z);
    }

    public void SaveMap()
    {
        ss.Save(this.gameObject.name, GetComponent<SaveableEntity>());
    }

    public void LoadMap()
    {
        ss.Load(this.gameObject.name, GetComponent<SaveableEntity>());
    }
    public object CaptureState()
    {
        return map;
    }

    public void RestoreState(object state)
    {
        InitialiseMap();
        map = (byte[,])state;
/*        DrawMap();*/
    }
}
