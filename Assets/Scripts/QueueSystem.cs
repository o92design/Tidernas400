using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueSystem : MonoBehaviour
{
  public Text m_QueueText;
  public List<Passenger> m_Passengers;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void LateUpdate()
  {
    foreach (Passenger inLine in GetComponentsInChildren<Passenger>())
    {
      if(!m_Passengers.Contains(inLine))
      {
        m_Passengers.Add(inLine);
      }
    }

    UpdateUI();
  }

  public void UpdateUI()
  {
    m_QueueText.text = "Kö: " + m_Passengers.Count;
  }
}
