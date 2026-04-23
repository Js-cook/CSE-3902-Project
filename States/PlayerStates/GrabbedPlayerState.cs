using Controllers;
using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class GrabbedPlayerState : AbstractGrabbedPlayerState
{
    private Link player;

    private Wallmaster captor;

    private Vector2 grabOffset = new Vector2(0, 4);


    public GrabbedPlayerState(Link player, Wallmaster wallmaster)
    {
        this.player = player;
        player.HitboxActive = false; // Disable player's hitbox while grabbed
        captor = wallmaster;
    }
    public override void Update(GameTime gameTime)
    {
        player.position = captor.position + grabOffset; // Keep player position locked to the captor's position and apply the grab offset
    }
}
