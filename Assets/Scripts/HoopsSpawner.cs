using System.Collections;
using UnityEngine;

public class HoopsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _minPos, _maxPos;
    [SerializeField] private GameObject _hoop;

    [Space]
    [SerializeField] private float _interval;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _sleepTime = new WaitForSeconds(_interval);
        StartCoroutine(Spawning());
    }
    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return _sleepTime;

            Vector3 pos = transform.position;
            pos.y = Random.Range(_minPos.position.y, _maxPos.position.y);

            Instantiate(_hoop, pos, Quaternion.identity);
        }

    }
}
