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
        subject.transform.localPosition = Vector3.zero;
        subject.transform.localRotation = Quaternion.identity;

        float forceMagnitude = Mathf.Max(0f, _force + _forceVariance * Random.value);

        subject.AddForce(_origin.right * forceMagnitude, ForceMode2D.Impulse);

        OnShoot?.Invoke(subject);

        return subject;
    }

    private IEnumerator Shooter_Coroutine()
    {

        while (enabled)
        {
            yield return new WaitForSeconds(Mathf.Max(
                0f,
                _interval + _intervalVariance * Random.value
                ));

            if (enabled == false) break;

            Shoot();
        }
        _shootingCoroutine = null;
    }

    private void OnEnable()
    {
        _shootingCoroutine = StartCoroutine(Shooter_Coroutine());
    }

    //private void OnDisable()
    //{
    //    Debug.Log($"{this.name}: OnDisable");
    //    // dont't kill, let it end naturally. //StopCoroutine(_shootingCoroutine);
    //}
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_origin == null) _origin = transform;
        Debug.Assert(_bullet != null, $"{this.name}: needs {nameof(_bullet)}", this);
    }

    static readonly Color GIZMO_COLOR = new Color(0f, 1f, 0f);
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GIZMO_COLOR;

        Gizmos.DrawWireSphere(_origin.position, 0.1f);

        Gizmos.DrawLine(
            _origin.position,
            _origin.position + _force * _origin.right
            );
    }
#endif
}
