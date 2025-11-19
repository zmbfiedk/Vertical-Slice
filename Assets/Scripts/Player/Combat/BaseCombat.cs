using System.Collections;
using UnityEngine;

public class BaseCombat : MonoBehaviour
{
    [Header("Combat Settings")]
    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject hurtboxPrefab; // The hurtbox to spawn
    [SerializeField] private float delayBetweenAttacks = 0.3f;
    [SerializeField] private float comboCooldown = 1f;
    [SerializeField] private float attackRange = 1f;

    [Header("Read Only")]
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private float comboResetTimer = 0f;

    private int attackIndex = 0; // Tracks which attack in the combo you are on

    private void Start()
    {
        if (hurtboxPrefab == null)
        {
            Debug.LogWarning(" No hurtbox prefab assigned to BaseCombat!");
        }
    }

    void Update()
    {
        // Reduce cooldown after combo
        if (comboResetTimer > 0)
            comboResetTimer -= Time.deltaTime;

        // Prevent attacking if we are in cooldown
        if (comboResetTimer > 0 || isAttacking)
            return;

        // Attack input (mouse 1)
        if (Input.GetMouseButtonDown(0))
        {
            attackIndex = 1;
            StartCoroutine(Attack1());
        }
    }

    private IEnumerator Attack1()
    {
        isAttacking = true;

        SpawnHurtbox();
        Debug.Log("Attack 1!!!");

        yield return new WaitForSeconds(delayBetweenAttacks);

        float timer = delayBetweenAttacks; // Give player a small window to continue the combo


        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                attackIndex = 2;
                StartCoroutine(Attack2());
                yield break;
            }

            yield return null;
        }

        EndCombo();  // No follow-up > end combo

    }

    private IEnumerator Attack2()
    {
        SpawnHurtbox();
        Debug.Log("Attack 2!!!");

        yield return new WaitForSeconds(delayBetweenAttacks);

        float timer = delayBetweenAttacks;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                attackIndex = 3;
                StartCoroutine(Attack3());
                yield break;
            }

            yield return null;
        }

        EndCombo();
    }

    private IEnumerator Attack3()
    {
        SpawnHurtbox();
        Debug.Log("Attack 3!!! FINAL HIT");

        yield return new WaitForSeconds(delayBetweenAttacks);

        comboResetTimer = comboCooldown; // Final attack > give large cooldown

        EndCombo();
    }


    private void EndCombo()
    {
        isAttacking = false;
        attackIndex = 0;
    }

    private void SpawnHurtbox()
    {
        if (hurtboxPrefab == null)
            return;

        Vector3 spawnPos = transform.position + transform.forward * attackRange;

        GameObject hb = Instantiate(hurtboxPrefab, spawnPos, transform.rotation, transform);

        Destroy(hb, 0.2f);
    }

}
