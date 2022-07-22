using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Canon : MonoBehaviour
{
    public const int ANY_BULLET = -1;

    [SerializeReference] private Rigidbody2D[] _bullet;

    [Header("Shooting")]
    [SerializeField] float _interval = 1f;
    [SerializeField] float _intervalVariance = 0.1f;
    [SerializeReference] private Transform _origin;
    [SerializeField] float _force = 10f;
    [SerializeField] float _forceVariance = 12f;

    [Header("Events")]
    UnityEvent<Rigidbody2D> OnShoot;

    private Coroutine _shootingCoroutine;

    private void OnValidate()
    {
        if (_origin == null) _origin = transform;
        Debug.Assert(_bullet != null, $"{this.name}: needs {nameof(_bullet)}", this);
    }

    private Rigidbody2D GetBulletPrefab(int idx = ANY_BULLET)
    {
        if (idx == ANY_BULLET)
        {
            idx = Mathf.FloorToInt(Random.value * _bullet.Length);
        }

        return _bullet[idx];
    }

    public Rigidbody2D Shoot(int idx = ANY_BULLET)
    {
        var prefab = GetBulletPrefab(idx);

        var inst = Instantiate<Rigidbody2D>(prefab, _origin);

        return Shoot(inst);
    }

    public Rigidbody2D Shoot(Rigidbody2D subject)
    {
        subject.transform.position = Vector3.zero;
        subject.transform.eulerAngles = Vector3.zero;

        float force = Mathf.Max(0f, _force + _forceVariance * Random.value);

        subject.AddForce(Vector2.right * force, ForceMode2D.Impulse);

        OnShoot?.Invoke(subject);

        return subject;
    }

    private IEnumerator Shooter_Coroutine()
    {
        Debug.Log("ShootStart");

        while (enabled)
        {
            yield return new WaitForSeconds(Mathf.Max(
                0f,
                _interval + _intervalVariance * Random.value
                ));

            if (enabled == false) break;

            Debug.Log("Pof!");

            Shoot();
        }

        Debug.Log("ShootStop");
        _shootingCoroutine = null;
    }

    private void OnEnable()
    {
        Debug.Log($"{this.name}: OnEnable");

        _shootingCoroutine = StartCoroutine(Shooter_Coroutine());
    }

    //private void OnDisable()
    //{
    //    Debug.Log($"{this.name}: OnDisable");
    //    // dont't kill, let it end naturally. //StopCoroutine(_shootingCoroutine);
    //}
}
