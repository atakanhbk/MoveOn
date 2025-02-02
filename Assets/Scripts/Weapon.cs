using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private GameObject target;


    public int Damage { get => damage; set => damage = value; }
    public int Speed { get => speed; set => speed = value; }
    public GameObject Target { get => target; set => target = value; }



}
