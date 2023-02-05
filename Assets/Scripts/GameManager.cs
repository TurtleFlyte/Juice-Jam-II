using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float xBounds, yBounds;

    [SerializeField] float points;

    public TextMeshProUGUI pointsText;

    // Getter and setter for the points value
    public float Points
    {
        get { return points; }
        set { points = value;
            pointsText.text = value.ToString();
        }
    }
}
