using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public GameManager gm;

    private void Start()
    {
        gm = Object.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        winnerText.text = "WINNER: PLAYER " + gm.winner;
    }
}
