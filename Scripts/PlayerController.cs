using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rd;
    [SerializeField]
    public float jump;
    [SerializeField]
    int score;

    public Transform gameOver;

    public TextMeshProUGUI scoreView;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rd.velocity = Vector2.up * jump;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AddScore"))
        {
            score++;
            scoreView.text = score + "";
        }
        if (collision.CompareTag("Pipe"))
        {
            this.enabled = false;
            gameOver.gameObject.SetActive(true);
            Invoke("Pause", 2);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;

    }
}
