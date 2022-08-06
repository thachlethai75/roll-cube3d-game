using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public AudioSource gemSfx;
    private void Update()
    {

        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerCollision.coinAmount++;
            PlayerPrefs.SetInt("CoinAmount", PlayerCollision.coinAmount);
            gemSfx.Play();
            Destroy(gameObject);
        }
    }
}
