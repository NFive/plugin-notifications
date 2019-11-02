using System;
using NFive.Notifications.Shared;
using NFive.SDK.Client.Interface;

namespace NFive.Notifications.Client.Overlays
{
	public class NotificationsOverlay : Overlay
	{
		private readonly Configuration config;

		public NotificationsOverlay(IOverlayManager manager, Configuration configuration) : base(manager)
		{
			this.config = configuration;
		}

		protected override dynamic Ready() => new
		{
			queue = this.config.QueueSize,
			layout = this.config.Layout,
			theme = this.config.Theme,
			animationOpen = this.config.AnimationOpen,
			animationClose = this.config.AnimationClose,
			type = this.config.DefaultType,
			timeout = this.config.DefaultTimeout.TotalMilliseconds
		};

		public void Notify(string text, string type = null, TimeSpan? timeout = null)
		{
			Emit("notify", new
			{
				text,
				type,
				timeout?.TotalMilliseconds
			});
		}
	}
}
