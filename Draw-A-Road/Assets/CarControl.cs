using System.Collections;
using System.Collections.Generic;
using LibraryPro;
using Unity.VisualScripting;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    [SerializeField] AudioSource[] _Sounds;
    [SerializeField] ParticleSystem _CollisionEffect;

    public WheelJoint2D FrontTire;
    public WheelJoint2D RearTire;
    private JointMotor2D MotorFront;
    private JointMotor2D MotorRear;

    [SerializeField] private float Speed;
    [SerializeField] private float Torque;

    public bool Go;


    private void Awake()
    {
        if (MemoryManagement.ReadDataInt("EffectSound") == 0)
        {
            foreach (var item in _Sounds)
            {
                item.mute = true;
            }
        }

    }

    void Update()
    {
        if (Go)
        {
            MotorFront.motorSpeed = Speed * -1;
            MotorFront.maxMotorTorque = Torque;
            FrontTire.motor = MotorFront;

            MotorRear.motorSpeed = Speed * -1;
            MotorRear.maxMotorTorque = Torque;
            RearTire.motor = MotorRear;
        }
        else
        {
            RearTire.useMotor =false;
            FrontTire.useMotor = false;

        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            GeneralManagement._GameManager.Win();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            GeneralManagement._GameManager.Lost();
            _CollisionEffect.gameObject.SetActive(true);
            _CollisionEffect.Play();
            _Sounds[1].mute = true;
            _Sounds[2].Play();
        }

        else if (collision.CompareTag("CarStop"))
        {
            Go = false;
        }
    }

    public void CarSoundControl()
    {
        _Sounds[0].mute = true;
        _Sounds[1].Play();
    }

    public void SoundManagement(bool Valuee)
    {
        foreach (var item in _Sounds)
        {
            item.mute = Valuee;
        }
    }
}
