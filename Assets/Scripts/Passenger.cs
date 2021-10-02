using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Interest;

[System.Serializable]
public class Interest
{
  public enum ID
  {
    Military,
    History,
    Nature
  }

  public ID id;
  public string interest;
  public Color color;
  public string imagePath;

  public static void DelegateInterest(Interest p_interest)
  {
    switch (UnityEngine.Random.Range(0, 3))
    {
      case 0:
        p_interest.id = ID.Military;
        p_interest.interest = "Militär";
        p_interest.color = Color.blue;
        p_interest.imagePath = "2D/Military";
        break;
      case 1:
        p_interest.id = ID.History;
        p_interest.interest = "Historia";
        p_interest.color = Color.black;
        p_interest.imagePath = "2D/History";
        break;
      case 2:
        p_interest.id = ID.Nature;
        p_interest.interest = "Naturen";
        p_interest.color = Color.green;
        p_interest.imagePath = "2D/Nature";
        break;
    }
  }
}

public static class Names
{
  public static string[] SurName = { "Lisa", "Carl", "Birgit", "Oscar", "Sven", "Jan-Erik", "Charlotta" };
  public static string[] LastName = { "Carlsson", "Andersson", "Sjöberg", "Linné", "Eriksson", "Von Platen", "Svensson" };
}

[System.Serializable]
public struct PassengerData
{
  public string Name;
  public float Money;

  public int Rating;
  public bool VIP;

  public Interest Interest;
}

public class Passenger : MonoBehaviour
{
  public PassengerData m_PassengerData;
  public SpriteRenderer m_renderer;

  public Text m_TextInterestRating;

  // Start is called before the first frame update
  void Start()
  {
    string surName = Names.SurName[UnityEngine.Random.Range(0, Names.SurName.Length)];
    string lastName = Names.LastName[UnityEngine.Random.Range(0, Names.SurName.Length)];
    m_PassengerData.Name = surName + " " + lastName;
    name = m_PassengerData.Name;

    m_PassengerData.Money = UnityEngine.Random.Range(1, 6);
    m_PassengerData.Rating = 0;
    m_PassengerData.VIP = false; // UnityEngine.Random.Range(0, 2) == 1;
    
    DelegateInterest(m_PassengerData.Interest);

    m_renderer.color = m_PassengerData.VIP ? Color.yellow : m_PassengerData.Interest.color;
  }

  private void Awake()
  {

  }

  // Update is called once per frame
  void Update()
  {
    UpdateUI();
  }

  public void UpdateUI()
  {
    m_TextInterestRating.text = m_PassengerData.Rating.ToString();
  }
}
