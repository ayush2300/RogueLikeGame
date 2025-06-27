using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoolDown
{
    bool IsReadyToFire { get; }
    void TriggerCooldown();
}

