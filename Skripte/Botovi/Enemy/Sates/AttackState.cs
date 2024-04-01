using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AttackState : BaseState
{
    private float moveTimer;
    private float izgubiIgracaTimer;
    private float shotTimer;

    // Start is called before the first frame update
    public override void Enter()
    {

    }
    public override void Perform()
    {
        izgubiIgracaTimer = 0;
        moveTimer += Time.deltaTime;
        shotTimer += Time.deltaTime;
        enemy.transform.LookAt(enemy.Igrac.transform);
        if (shotTimer > enemy.brzinaPucanja)
        {
            Pucaj();
        }
        if (moveTimer > Random.Range(1,9))
        {
            enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
            moveTimer = 0;
        }
        else
        {
            izgubiIgracaTimer += Time.deltaTime;
            if (izgubiIgracaTimer > 7)
            {
                stateMasina.ChangeState(new PatrolState()) ;
            }
        }
        

    }
    public void Pucaj()
{
    Transform Cev = enemy.cev;
    GameObject metak = GameObject.Instantiate(Resources.Load("Prefabs/Metak") as GameObject, Cev.position, enemy.transform.rotation);

    // Calculate the normalized direction from Cev to enemy.Igrac
    Vector3 smerPucanja = (enemy.Igrac.transform.position - Cev.transform.position).normalized;

    // Apply a random rotation to the velocity direction
    metak.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-4f, 4f), Vector3.up) * smerPucanja * 30;

    Debug.Log("Shoot");
    shotTimer = 0;
}

    public override void Exit()
    {

    }
}
