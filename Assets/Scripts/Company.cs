using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct CompanyData
{
  public string Name;
  public int Money;
  public List<GameObject> Ships;
}

public class Company : MonoBehaviour
{
  public CompanyData m_CompanyData;

  public Text m_TextName;
  public Text m_TextMoney;
  public Text m_TextShips;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void LateUpdate()
  {
    UpdateTextAssets();
  }

  public void UpdateTextAssets()
  {
    m_TextName.text = m_CompanyData.Name;
    m_TextMoney.text = "Money: " + m_CompanyData.Money + " SEK";
    m_TextShips.text = "Ships: " + m_CompanyData.Ships.Count;
  }
}
