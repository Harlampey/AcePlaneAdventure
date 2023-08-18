using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlaneMovement planeMovement))
        {
            planeMovement.Break();
            Invoke("EndGame", 0.2f);
        }
        
    }
    private void EndGame()
    {
        SceneManager.LoadScene("Lose");
    }
}
