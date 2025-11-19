using UnityEngine;

public class Basemovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        float rawX = Input.GetAxisRaw("Horizontal");
        float rawY = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(rawX, 0, rawY);

        if (input.sqrMagnitude > 0.1f)
        {
            // Normalize so diagonal isn't faster
            input.Normalize();

            transform.Translate(input * speed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.LookRotation(input);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
        }
    }
}
