using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class GOAP_World
{
    private static readonly GOAP_World instance = new GOAP_World();
    private static States world;
    private static ResourceQueue chests;
    private static ResourceQueue exitDoor;
    private static ResourceQueue exitDoorCovers;
    private static ResourceQueue searchPoints;
    private static Dictionary<string, ResourceQueue> allResources = new Dictionary<string, ResourceQueue>();
    static GOAP_World()
    {
        world = new States();

        chests = new ResourceQueue("Chest", "LockedChest", world);
        allResources.Add("LockedChests", chests);

        exitDoor = new ResourceQueue("ExitDoor", "FreeExitDoor", world);
        allResources.Add("ExitDoor", exitDoor);

        exitDoorCovers = new ResourceQueue("ExitDoorCover", "FreeExitDoorCover", world);
        allResources.Add("ExitDoorCover", exitDoorCovers);

        searchPoints = new ResourceQueue("SearchPoint", "FreeSearchPoint", world);
        allResources.Add("SearchPoint", searchPoints);
    }
    public GOAP_World()
    {

    }
    public static GOAP_World Instance { get { return instance; } }
    public States World { get { return world; } }
    public Dictionary<string, ResourceQueue> AllResources { get { return allResources; } }
    public ResourceQueue GetResourceQueue(string key)
    {
        if (allResources.ContainsKey(key))
        {
            return allResources[key];
        }
        return null;
    }
}
