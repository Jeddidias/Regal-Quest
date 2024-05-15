using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int kiwiis = 0;

    [SerializeField] private Text kiwiisText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kiwii"))
        {
            Destroy(collision.gameObject);
            kiwiis++;
            kiwiisText.text = "Kiwiis: " + kiwiis;
        }
    }
}
