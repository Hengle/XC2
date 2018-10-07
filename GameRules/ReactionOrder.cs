namespace GameRules
{
    using System;
    using System.Collections.Generic;
    using GameDefinitions;

    public static class ReactionOrder
    {
        public static readonly List<Reaction> Definition = new List<Reaction>
        {
            // whoever has break should aslo have smash for a clean inital rotation
            Reaction.Break,

            // get to topple as soon as possible because they stop dealing damange from this point on
            Reaction.Topple,
            Reaction.Launch,

            // Give preference to finishing combos during smash, working backwards
            Reaction.Smash
        };

        public static Reaction GetNextReaction(Reaction reaction)
        {
            switch (reaction)
            {
                case Reaction.Break:
                    return Reaction.Topple;
                case Reaction.Topple:
                    return Reaction.Launch;
                case Reaction.Launch:
                    return Reaction.Smash;
                case Reaction.Smash:
                    return Reaction.Break;
                default:
                    throw new Exception("Unimplemented Reaction: " + reaction);
            }
        }
    }
}
