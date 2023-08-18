using System.Collections;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed, _rotationSpeed;
    [SerializeField] private float _rotationAngle;

    [Space]
    [SerializeField] private float _changeSpeedSleep;
    [SerializeField] private float _changeSpeedStep;

    [Space]
    [SerializeField] private AudioSource _breakAudioSource;

    private float _speed;

    private Transform _transform;
    private bool _canMove, _isBroken;

    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        if (!_canMove && Input.GetMouseButtonDown(0))
        {
            _canMove = true;
            StartCoroutine(SmoothSpeed());
        }

        if (_canMove)
        {
            _transform.Translate(Vector3.up * _speed * Time.deltaTime, Space.World);

            if (Input.GetMouseButton(0) && !_isBroken)
            {
                RotateUp();
            }
            else
            {
                RotateDown();
            }
        }

    }

    private void RotateUp()
    {
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, Quaternion.Euler(0, 0, _rotationAngle), _rotationSpeed * Time.deltaTime);
    }

    private void RotateDown()
    {
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, Quaternion.Euler(0, 0, -_rotationAngle), _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator SmoothSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(_changeSpeedSleep);
            float targetSpeed = (Input.GetMouseButton(0) && !_isBroken) ? _moveSpeed : -_moveSpeed;

            if (targetSpeed > 0 && _speed < targetSpeed)
            {
                _speed += _changeSpeedStep;
            }
            else if (targetSpeed < 0 && _speed > targetSpeed)
            {
                _speed -= _changeSpeedStep;
            }
        }
    }

    public void Break()
    {
        if (_isBroken)
            return;

        GetComponent<Rigidbody2D>().gravityScale = 1f;
        StopAllCoroutines();

        _isBroken = true;
        _speed = 0;
        
        if (PlayerPrefs.GetInt("IsVibroOn") == 1)
            Handheld.Vibrate();
        
        if (PlayerPrefs.GetInt("IsSoundOn") == 1)
            _breakAudioSource.Play();
    }
}
