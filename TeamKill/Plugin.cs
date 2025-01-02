using Exiled.API.Features;
using TeamKill.Configs;

namespace TeamKill
{
    public class Plugin : Plugin<Config>
    {
		public override string Author => "Руслан0308c";
		public override string Name => "TeamKill";
		public override Version RequiredExiledVersion => new(9, 2, 1);
		public override Version Version => new(1, 0, 0);

		public Plugin? Singleton { get; private set; }
		public Handlers? _handlers { get; private set; }

		public override void OnEnabled()
		{
			_handlers = new();
			Singleton = this;

			Exiled.Events.Handlers.Player.Shooting += _handlers.OnShooting;
			Exiled.Events.Handlers.Map.ExplodingGrenade += _handlers.OnExplodingGrenade;

			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Player.Shooting -= _handlers.OnShooting;
			Exiled.Events.Handlers.Map.ExplodingGrenade -= _handlers.OnExplodingGrenade;

			Singleton = null;
			_handlers = null;

			base.OnDisabled();
		}
	}
}
