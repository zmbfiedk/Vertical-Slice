using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.15f;
    [SerializeField] private float shakeStrength = 0.6f;

    private Vector3 originalLocalPos;

    private void Awake()
    {
        // Store the local position so shake resets correctly
        originalLocalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        BaseCombat.OnHit += Shake;
    }

    private void OnDisable()
    {
        BaseCombat.OnHit -= Shake;
    }

    private void Shake()
    {
        transform.DOKill(); // stop old shakes
        transform.localPosition = originalLocalPos; // reset before shaking

        transform.DOShakePosition(
            shakeDuration,
            shakeStrength,
            20,
            90,
            false,
            true
        ).OnComplete(() =>
        {
            // After shaking, snap back to original local position
            transform.localPosition = originalLocalPos;
        });
    }
}
