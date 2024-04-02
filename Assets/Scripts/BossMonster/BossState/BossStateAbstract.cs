using UnityEngine;

public abstract class BossStateAbstract
{
    public abstract void EnterState(BossStateManager Agent);

    public abstract void UpdateState(BossStateManager Agent);

    public abstract void ExitState(BossStateManager Agent);

}
