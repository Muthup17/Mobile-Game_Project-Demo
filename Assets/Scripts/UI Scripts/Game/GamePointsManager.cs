using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

[DefaultExecutionOrder(-10)]
public class GamePointsManager : MonoBehaviour
{
    private static GamePointsManager m_instance;
    public static GamePointsManager Instance => m_instance;

    private int m_gamePoints = 30000;
    public int GamePoints => m_gamePoints;

    void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void AddGamePoint(int amount)
    {
        m_gamePoints += amount;
        MainMenu.Instance.UpdateGamePointUI(m_gamePoints);
    }
    public void DeleteGamePoint(int amount)
    {
        m_gamePoints -= amount;
        MainMenu.Instance.UpdateGamePointUI(m_gamePoints);
    }

}
