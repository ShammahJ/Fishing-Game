using UnityEngine;

public class Anchor : Upgrade
{
    [Header("Fish Stat Modifiers")]
    [SerializeField] private float strengthMultiplier = -0.25f;
    [SerializeField] private float speedMultiplier = 0.0f;

    public override void OnFishSpawned(Fish fish, ActiveUpgrade runtime)
    {
            fish.ModifyStats(strengthMultiplier, speedMultiplier);
    }

    //public override void OnLineCasted(ActiveUpgrade runtime)
    //{
    //    Hook.Instance.descensionSpeed += 6;
    //    Hook.Instance.ascensionSpeed -= 5;
    //    lowkenuinly
    //}
}
