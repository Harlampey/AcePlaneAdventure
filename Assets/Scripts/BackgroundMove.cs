using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private SpriteRenderer _sprite;
    [SerializeField] private float _speed;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveTile();
    }
    private void MoveTile()
    {
        _sprite.size = new Vector2(_sprite.size.x + -Time.deltaTime * _speed, _sprite.size.y);
    }
}
