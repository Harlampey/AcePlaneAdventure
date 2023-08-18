using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlaneMovement>())
        {
            Score.Increase();

            if (PlayerPrefs.GetInt("IsSoundOn") == 1)
                _audioSource.Play();
        }
    }
}
