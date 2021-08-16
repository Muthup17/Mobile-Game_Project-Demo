using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSignPlacement_InputData 
{
    private static NavigationSignPlacement_InputData m_instance = new NavigationSignPlacement_InputData();
    public static NavigationSignPlacement_InputData Instance => m_instance;

    private bool m_isKeyHolded;
    private bool m_printed;
    private bool m_firstOneisSelected;
    private bool m_secondOneisSelected;
    private bool m_thirdOneisSelected;
    private bool m_forthOneisSelected;

    public bool IsKeyHolded { get => m_isKeyHolded; set => m_isKeyHolded = value; }
    public bool Printed { get => m_printed; set => m_printed = value; }

    public bool FirstOneIsSelected { get => m_firstOneisSelected; set => m_firstOneisSelected = value; }
    public bool SecondOneIsSelected { get => m_secondOneisSelected; set => m_secondOneisSelected = value; }
    public bool ThirdOneIsSelected { get => m_thirdOneisSelected; set => m_thirdOneisSelected = value; }
    public bool ForthOneIsSelected { get => m_forthOneisSelected; set => m_forthOneisSelected = value; }

    public void ResetInput()
    {
        m_isKeyHolded = false;
        m_printed = false;
        m_firstOneisSelected = false;
        m_secondOneisSelected = false;
        m_thirdOneisSelected = false;
        m_forthOneisSelected = false;
    }

}
