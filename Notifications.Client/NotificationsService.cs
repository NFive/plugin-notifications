using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.Notifications.Client.Overlays;
using NFive.Notifications.Shared;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Communications;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;

namespace NFive.Notifications.Client
{
	[PublicAPI]
	public class NotificationsService : Service
	{
		private Configuration config;
		private NotificationsOverlay overlay;

		public NotificationsService(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlay, User user) : base(logger, ticks, comms, commands, overlay, user) { }

		public override async Task Started()
		{
			// Request server configuration
			this.config = await this.Comms.Event(NotificationsEvents.Configuration).ToServer().Request<Configuration>();

			// Create overlay
			this.overlay = new NotificationsOverlay(this.OverlayManager, this.config);

			// Listen to server notifications
			this.Comms.Event(NotificationsEvents.ShowNotification).FromServer().On<Notification>((e, notification) =>
			{
				this.overlay.Notify(notification);
			});

			// Listen to client notifications
			this.Comms.Event(NotificationsEvents.ShowNotification).FromClient().On<Notification>((e, notification) =>
			{
				this.overlay.Notify(notification);
			});
		}
	}
}
