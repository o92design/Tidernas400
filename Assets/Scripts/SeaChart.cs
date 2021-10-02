using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SeaChartData
{
  public Interest Interest;
  public int rating;
}

public class SeaChart : MonoBehaviour
{
  public SpriteRenderer m_renderer;
  public SeaChartData m_ChartData;

  public Text m_TextInterest;
  public Text m_TextRating;

  public Image m_image;

  // Start is called before the first frame update
  void Start()
  {
    Interest.DelegateInterest(m_ChartData.Interest);
    m_ChartData.rating = Random.Range(1, 6);

    m_renderer.color = m_ChartData.Interest.color;

    m_TextInterest.text = m_ChartData.Interest.interest;
    m_TextRating.text = m_ChartData.rating.ToString();

    Debug.Log("Loading sprite from path " + m_ChartData.Interest.imagePath);
    Sprite image = Resources.Load<Sprite>(m_ChartData.Interest.imagePath);
    Debug.Log(image);
    m_image.overrideSprite = image;
  }

  // Update is called once per frame
  
}