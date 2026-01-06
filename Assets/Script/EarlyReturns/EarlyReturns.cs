public bool IsPlayerReadyToAttack(Player player)
{
    // Basis checks
    if (player == null)
        return false;

    if (!player.IsAlive)
        return false;

    if (player.AttackCooldown > 0)
        return false;

    // Target checks
    if (player.Target == null)
        return false;

    if (!player.Target.IsAlive)
        return false;

    // Afstand check
    float distance = Vector3.Distance(
        player.transform.position,
        player.Target.transform.position
    );

    if (distance >= 5f)
        return false;

    // Resource / state checks
    bool hasResources =
        (player.Mana >= 20 && player.WeaponEquipped) ||
        (player.Health >= 30 && player.HasBuff("Strength"));

    if (!hasResources)
        return false;

    if (player.IsStunned || player.IsSlowed)
        return false;

    // Alles klopt → aanval mogelijk
    return true;
}
