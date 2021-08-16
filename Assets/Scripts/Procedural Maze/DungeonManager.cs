using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public Maze[] mazes;
    public int width = 30;
    public int depth = 30;

    public GameObject stairWell;

    // Start is called before the first frame update
    void Start()
    {
        int level = 0;
        foreach (Maze m in mazes)
        {
            m.width = width;
            m.depth = depth;
            m.level = level++;
            m.levelDistance = 1.5f;
            m.Build();
        }

        width += 6;
        depth += 6;

        for (int mazeIndex = 0; mazeIndex < mazes.Length - 1; mazeIndex++)
        {
            if (PlaceStairs(mazeIndex, 0, Maze.PieceType.DeadToLeft, Maze.PieceType.DeadToRight, stairWell)) continue;
            if (PlaceStairs(mazeIndex, 90, Maze.PieceType.DeadEnd, Maze.PieceType.DeadUpsideDown, stairWell)) continue;
            if (PlaceStairs(mazeIndex, 180, Maze.PieceType.DeadToRight, Maze.PieceType.DeadToLeft, stairWell)) continue;
            PlaceStairs(mazeIndex, -90, Maze.PieceType.DeadUpsideDown, Maze.PieceType.DeadEnd, stairWell);
        }

        for (int mazeIndex = 0; mazeIndex < mazes.Length - 1; mazeIndex++)
        {
            mazes[mazeIndex + 1].gameObject.transform.Translate(mazes[mazeIndex + 1].xOffset * mazes[mazeIndex + 1].scale,
                                                                    0,
                                                                mazes[mazeIndex + 1].zOffset * mazes[mazeIndex + 1].scale);
        }

    }

    bool PlaceStairs(int mazeIndex, float rotAngle, Maze.PieceType bottomType, Maze.PieceType upperType, 
          GameObject stairPrefab)
    {
        List<MapLocation> startingLocations = new List<MapLocation>();
        List<MapLocation> endingLocations = new List<MapLocation>();

        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (mazes[mazeIndex].piecePlaces[x, z].piece == bottomType)
                    startingLocations.Add(new MapLocation(x, z));

                if (mazes[mazeIndex + 1].piecePlaces[x, z].piece == upperType)
                    endingLocations.Add(new MapLocation(x, z));
            }

        if (startingLocations.Count == 0 || endingLocations.Count == 0) return false;

        MapLocation bottomOfStairs = startingLocations[UnityEngine.Random.Range(0, startingLocations.Count)];
        MapLocation topOfStairs = endingLocations[UnityEngine.Random.Range(0, endingLocations.Count)];

        mazes[mazeIndex + 1].xOffset = bottomOfStairs.x - topOfStairs.x + mazes[mazeIndex].xOffset;
        mazes[mazeIndex + 1].zOffset = bottomOfStairs.z - topOfStairs.z + mazes[mazeIndex].zOffset;

        Vector3 stairPosBottom = new Vector3(bottomOfStairs.x * mazes[mazeIndex].scale,
                                                    mazes[mazeIndex].scale * mazes[mazeIndex].level
                                                            * mazes[mazeIndex].levelDistance,
                                                    bottomOfStairs.z * mazes[mazeIndex].scale);
        Vector3 stairPosTop = new Vector3(topOfStairs.x * mazes[mazeIndex + 1].scale,
                                                    mazes[mazeIndex + 1].scale * mazes[mazeIndex + 1].level
                                                            * mazes[mazeIndex + 1].levelDistance,
                                                    topOfStairs.z * mazes[mazeIndex + 1].scale);

        Destroy(mazes[mazeIndex].piecePlaces[bottomOfStairs.x, bottomOfStairs.z].model);
        Destroy(mazes[mazeIndex + 1].piecePlaces[topOfStairs.x, topOfStairs.z].model);

        GameObject stairs = Instantiate(stairPrefab, stairPosBottom, Quaternion.identity);
        stairs.transform.Rotate(0, rotAngle, 0);
        mazes[mazeIndex].piecePlaces[bottomOfStairs.x, bottomOfStairs.z].model = stairs;
        mazes[mazeIndex].piecePlaces[bottomOfStairs.x, bottomOfStairs.z].piece = Maze.PieceType.Manhole;

        mazes[mazeIndex + 1].piecePlaces[topOfStairs.x, topOfStairs.z].model = null;
        mazes[mazeIndex + 1].piecePlaces[topOfStairs.x, topOfStairs.z].piece = Maze.PieceType.Manhole;

        stairs.transform.SetParent(mazes[mazeIndex].gameObject.transform);
        return true;
    }






    // Update is called once per frame
    void Update()
    {

    }
}
