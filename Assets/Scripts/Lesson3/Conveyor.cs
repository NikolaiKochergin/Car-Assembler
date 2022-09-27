using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _materialSpeed = 1f;
    [SerializeField] private Material _conveyorMaterial;
    [SerializeField] private float _maxMaterialOffset;

    private Rigidbody _rigidbody;
    private float _materialOffset;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_materialOffset) < _maxMaterialOffset)
            _materialOffset += _materialSpeed * Time.fixedDeltaTime;
        else
            _materialOffset = 0;
        _conveyorMaterial.mainTextureOffset = new Vector2(_materialOffset, 0f);
        var pos = _rigidbody.position;
        _rigidbody.position += -transform.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(pos);
    }

    private void OnApplicationQuit()
    {
        _conveyorMaterial.mainTextureOffset = new Vector2(0,0);
    }
}
