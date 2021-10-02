using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[System.Serializable]
public struct ShipData
{
  public string Name;

  [Range(1, 3)]
  public int Level;
  public List<Passenger> Passengers;
  public int PassengerCapacity;
}

public class Ship : MonoBehaviour
{
  public ShipData m_ShipData;

  public Text m_TextShipName;
  public Text m_TextLevel;
  public Text m_TextShipCapacity;
  public Text m_TextPassengers;
  // Start is called before the first frame update
  void Start()
  {
    m_ShipData.Passengers = new List<Passenger>();
  }

  // Update is called once per frame
  void Update()
  {
    m_ShipData.PassengerCapacity = (int)(m_ShipData.Level * 2.5f);
  }

  public void LateUpdate()
  {
    UpdateUI();
  }

  public void UpdateUI()
  {
    m_TextShipName.text = m_ShipData.Name;
    m_TextLevel.text = m_ShipData.Level.ToString();
    m_TextPassengers.text = "Passagerare: " + m_ShipData.Passengers.Count + " / " + m_ShipData.PassengerCapacity;
  }
}
