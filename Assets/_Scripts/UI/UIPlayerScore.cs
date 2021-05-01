using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerScore : MonoBehaviour
{
    [Header("References")]

    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] TMP_Text textPressStart;

    private void Update()
    {
        PrintScore();
    }

    /// <summary>
    /// Deactivate "Press Enter to Start"
    /// </summary>
    void DeactivatePressStart()
    {
        if (!textPressStart.gameObject.activeSelf)
            textPressStart.gameObject.SetActive(false);
    }

    /// <summary>
    /// Print score of each player
    /// </summary>
    void PrintScore()
    {
        string s = "";

        foreach (var player in gameManager.players)
        {
            s += GetPlayerScoreText(player);
            s += "\n";
        }

        scoreText.text = s;
    }

    /// <summary>
    /// Return formated text of player
    /// E.g. " Player 1 - Q B - Score: 2500"
    /// </summary>
    string GetPlayerScoreText(Player player)
    {
        return string.Format("Player {0} - {1} {2} - Score: {3} ", player.id + 1, player.keyLeft.ToString(), player.keyRigth.ToString(), player.score);
    }
}
