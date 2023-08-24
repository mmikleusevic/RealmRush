using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    [SerializeField] [Range(0f, 5f)] float speed = 2f;

    Enemy[] enemies;

    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        enemies = FindObjectsOfType<Enemy>();

        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        if (enemies.Length > 0)
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);

            RotateWeapon();

            if (targetDistance < range)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }
        else
        {
            Attack(false);
        }
    }

    void RotateWeapon()
    {
        Vector3 targetDirection = target.position - weapon.transform.position;

        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(weapon.transform.forward, targetDirection, singleStep, 1f);

        weapon.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void Attack(bool isActive)
    {
        ParticleSystem.EmissionModule emissionModule = projectileParticles.emission;

        emissionModule.enabled = isActive;
    }
}
