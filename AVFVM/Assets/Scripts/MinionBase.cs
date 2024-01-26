using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBase : MonoBehaviour
{
    public HealthComponent _healthComponent;

    public void Start()
    {
        _healthComponent = this.GetComponent<HealthComponent>();
        _healthComponent._health = 25;
    }

    public void Update()
    {
        
    }
}
