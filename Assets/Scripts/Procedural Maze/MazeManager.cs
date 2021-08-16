using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public Maze[] mazes;
    public int width = 30;
    public int depth = 30;

    public GameObject straightManHoleLadder;
    public GameObject straightManHoleUp;
    public GameObject deadendManHoleLadder;
    public GameObject deadendManHoleUp;


    // Start is called before the first frame update
    void Start()
    {
        int level = 0;
        foreach (Maze m in mazes)
        {
            m.width = width;
            m.depth = depth;
            m.level = level++;
            m.Build();
        }


        for (int mazeIndex = 0; mazeIndex < mazes.Length - 1; mazeIndex++)
        {
            for (int z = 0; z < depth; z++)
                for (int x = 0; x < width; x++)
                {
                    if (mazes[mazeIndex].piecePlaces[x, z].piece == mazes[mazeIndex + 1].piecePlaces[x, z].piece)
                    {
                        if (mazes[mazeIndex].piecePlaces[x, z].piece == Maze.PieceType.Vertical_Straight)
                        {
                            Destroy(mazes[mazeIndex].piecePlaces[x, z].model);
                            Destroy(mazes[mazeIndex + 1].piecePlaces[x, z].model);

                            Vector3 upManHolePos = new Vector3(x * mazes[mazeIndex].scale,
                                                                mazes[mazeIndex].scale * mazes[mazeIndex].level * 2,
                                                                z * mazes[mazeIndex].scale);
                            mazes[mazeIndex].piecePlaces[x, z].model = Instantiate(straightManHoleUp,
                                                                    upManHolePos, Quaternion.identity);

                            Vector3 ladderManHolePos = new Vector3(x * mazes[mazeIndex + 1].scale,
                                                                mazes[mazeIndex + 1].scale * mazes[mazeIndex + 1].level * 2,
                                                                z * mazes[mazeIndex + 1].scale);
                            mazes[mazeIndex + 1].piecePlaces[x, z].model = Instantiate(straightManHoleLadder, ladderManHolePos,
                                                                Quaternion.identity);

                            mazes[mazeIndex].piecePlaces[x, z].piece = Maze.PieceType.Manhole;
                            mazes[mazeIndex + 1].piecePlaces[x, z].piece = Maze.PieceType.Manhole;
                        }
                        else if (mazes[mazeIndex].piecePlaces[x, z].piece == Maze.PieceType.DeadEnd)
                        {
                            Destroy(mazes[mazeIndex].piecePlaces[x, z].model);
                            Destroy(mazes[mazeIndex + 1].piecePlaces[x, z].model);

                            Vector3 upManHolePos = new Vector3(x * mazes[mazeIndex].scale,
                                                                mazes[mazeIndex].scale * mazes[mazeIndex].level * 2,
                                                                z * mazes[mazeIndex].scale);
                            mazes[mazeIndex].piecePlaces[x, z].model = Instantiate(deadendManHoleUp,
                                                                    upManHolePos, Quaternion.identity);

                            Vector3 ladderManHolePos = new Vector3(x * mazes[mazeIndex + 1].scale,
                                                                mazes[mazeIndex + 1].scale * mazes[mazeIndex + 1].level * 2,
                                                                z * mazes[mazeIndex + 1].scale);
                            mazes[mazeIndex + 1].piecePlaces[x, z].model = Instantiate(deadendManHoleLadder, ladderManHolePos,
                                                                Quaternion.identity);

                            mazes[mazeIndex].piecePlaces[x, z].piece = Maze.PieceType.Manhole;
                            mazes[mazeIndex + 1].piecePlaces[x, z].piece = Maze.PieceType.Manhole;
                        }
                    }

                }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
