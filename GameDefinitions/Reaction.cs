namespace GameDefinitions
{
    /// <summary>
    ///     The set of reactions that both stun enemies and multiply damage
    /// </summary>
    /// <remarks>
    ///     Blowdown and knockback are reactions, but aren't used for combos
    /// </remarks>
    public enum Reaction
    {
        Break = 0,
        Topple = 1,
        Launch = 2,
        Smash = 3,
        Blowdown = 4,
        Knockback = 4,
    }
}
