using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueSystem : MonoBehaviour
{
  public Text m_QueueText;
  public List<Passenger> m_Passengers;

  public Transform m_firstSpot;
  public int m_MaxInLine;

  // Start is called before the first frame update
  void Start()
  {
    UpdateLine();
    m_MaxInLine = m_Passengers.Count;
  }

  public void UpdateLine()
  {
    foreach (Passenger inLine in GetComponentsInChildren<Passenger>())
    {
      if (!m_Passengers.Contains(inLine))
      {
        m_Passengers.Add(inLine);
      }
    }
  }

  // Update is called once per frame
  void LateUpdate()
  {
    UpdateLine();

    UpdateUI();
  }


  public void UpdateUI()
  {
    m_QueueText.text = "Kö: " + m_Passengers.Count;
  }
}
