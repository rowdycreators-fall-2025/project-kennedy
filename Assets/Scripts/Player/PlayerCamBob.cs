using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerCamBob : MonoBehaviour
{
    private Vector3 _startPos;
    public MoveComponent _moveComponent;

    public float _bobStepFrequency = 10f;
    public float _bobStepAmplitude = 0.01f;


    void Awake()
    {
        _startPos = transform.localPosition;

    }

    void Update()
    {
        float characterSpeed = new Vector3(_moveComponent.CurrentWalkVelocity.x, 0, _moveComponent.CurrentWalkVelocity.z).magnitude;

        if (characterSpeed > 0 && _moveComponent.IsOnGround())
        {
            Vector3 stepPos = Vector3.zero;
            stepPos.x += Mathf.Cos(Time.time * _bobStepFrequency) * _bobStepAmplitude / 2;
            stepPos.y += Mathf.Sin(Time.time * _bobStepFrequency * 2) * _bobStepAmplitude;
            transform.localPosition += stepPos;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 1f - Mathf.Pow(.01f, Time.deltaTime));
        if (Mathf.Abs(transform.forward.y) < .9f) // gaurds from bug where rotation changes when looking down/up
            transform.LookAt(_moveComponent.transform.position + transform.forward * 15f);

    }
}
