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

		public void Notify(Notification notification)
		{
			Emit("notify", new
			{
				text = notification.Text,
				type = notification.Type,
				timeout = notification.Timeout?.TotalMilliseconds
			});
		}
	}
}
