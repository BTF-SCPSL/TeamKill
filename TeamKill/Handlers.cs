using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;

namespace TeamKill
{
	public sealed class Handlers
	{
		public void OnShooting(ShootingEventArgs ev)
		{
			if (Server.FriendlyFire)
			{
				ev.IsAllowed = true;
			} else
			{
				if (ev.Player.LeadingTeam == ev.ClaimedTarget.LeadingTeam)
				{
					ev.IsAllowed = false;
				}
			}
		}

		public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
		{
			foreach (Player player in ev.TargetsToAffect.ToList())
			{
				if (Server.FriendlyFire)
				{
					break;
				}

				if (ev.Player == player)
				{
					continue;
				}

				if (ev.Player.LeadingTeam == player.LeadingTeam)
				{
					ev.TargetsToAffect.Remove(player);
				}
			}
		}
	}
}
