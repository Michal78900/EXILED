// -----------------------------------------------------------------------
// <copyright file="Left.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events
{
    #pragma warning disable SA1313
    using Exiled.Events.Handlers;
    using Exiled.Events.Handlers.EventArgs;
    using HarmonyLib;

    /// <summary>
    /// Patches <see cref="ReferenceHub.OnDestroy"/>.
    /// Adds the <see cref="Player.Left"/> event.
    /// </summary>
    [HarmonyPatch(typeof(ReferenceHub), nameof(ReferenceHub.OnDestroy))]
    public class Left
    {
        /// <summary>
        /// Prefix of <see cref="ReferenceHub.OnDestroy"/>.
        /// </summary>
        /// <param name="__instance">The <see cref="ReferenceHub"/> instance.</param>
        public static void Prefix(ReferenceHub __instance)
        {
            var ev = new LeftEventArgs(API.Features.Player.Get(__instance.gameObject));

            API.Features.Log.Debug($"Player {ev.Player?.Nickname} ({ev.Player?.UserId}) disconnected");

            Player.OnLeft(ev);
        }
    }
}
