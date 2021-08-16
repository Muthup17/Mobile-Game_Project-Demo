using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAP_Inventory
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject Chest;
    public Transform[] guardPlaces = new Transform[4];

    public delegate (Transform, int) ResourceDelegate(int i, Transform[] arr);
    public delegate GameObject DistanceBasedResourceDelegate(Transform[] arr, Vector3 charPos);

    private int recentlyAddedIndex = 0;
    public int RecentlyAddedIndex => recentlyAddedIndex;

    public (Transform, int) GetDestinationPoint(ResourceDelegate dele, int index, Transform[] arr)
    {
        return dele(index, arr);
    }

    public GameObject GetDistanceBasedResource(DistanceBasedResourceDelegate dele, Transform[] arr, Vector3 charPos)
    {
        return dele(arr, charPos);
    }

    public (Transform, int) ResourcePoint(int currIndex, Transform[] pointsArr)
    {
        if (currIndex == 0 || currIndex >= pointsArr.Length - 1)
        {
            int i = Random.Range(1, pointsArr.Length - 1);
            return (pointsArr[i], i);
        }
        else
        {
            int index = currIndex + 1;
            return (pointsArr[index], index);
        }
    }

    public GameObject NearestResource(Transform[] arr, Vector3 characterPos)
    {
        float distance = float.MaxValue;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            float distanceToPlace = Vector3.Distance(arr[i].position, characterPos);
            if (distanceToPlace < distance)
            {
                distance = distanceToPlace;
                index = i;
            }
        }
        return arr[index].gameObject;
    }

    public GameObject LongestResource(Transform[] arr, Vector3 characterPos)
    {
        float distance = float.MinValue;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            float distanceToPlace = Vector3.Distance(arr[i].position, characterPos);
            if (distanceToPlace > distance)
            {
                distance = distanceToPlace;
                index = i;
            }
        }
        return arr[index].gameObject;
    }
/*    public GameObject GetHidePoint(Vector3 playerPos,Vector3 targetDir)
    {
        GameObject hidePoint = null;
        float greatestDotValue = 0;
        Vector3 inverseNormalisedDir = -(targetDir.normalized);
        foreach(Transform p in hidePoints)
        {
            Vector3 directionToHidePoint = (p.transform.position - playerPos).normalized;
            float dotValue = Vector3.Dot(inverseNormalisedDir, directionToHidePoint);
            if(dotValue > greatestDotValue)
            {
                greatestDotValue = dotValue;
                hidePoint = p.gameObject;
            }
        }
        return hidePoint;
    }*/

    public void AddItem(GameObject i)
    {
        items.Add(i);
        recentlyAddedIndex = items.IndexOf(i);
    }

    public void RemoveAll(string tag)
    {
        while(true)
        {
            GameObject obj = FindItemWithTag(tag);
            if(obj != null)
            {
                RemoveItem(obj);
            }
            else
            {
                break;
            }
        }
    }

    public GameObject FindItemWithTag(string tag)
    {
        foreach (GameObject i in items)
        {
            if (i == null) continue;
            if (i.tag == tag)
            {
                return i;
            }
        }
        return null;
    }

    public GameObject FindRecentlyAddedItem()
    {
        return items[recentlyAddedIndex];
    }

    public void RemoveItem(GameObject i)
    {
        int indexToRemove = -1;
        foreach (GameObject g in items)
        {
            indexToRemove++;
            if (g == i)
            {
                break;
            }
        }
        if (indexToRemove > -1)
        {
            items.RemoveAt(indexToRemove);
        }
    }
}
