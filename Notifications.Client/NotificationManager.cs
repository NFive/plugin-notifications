using JetBrains.Annotations;
using NFive.Notifications.Shared;
using NFive.SDK.Client.Communications;

namespace NFive.Notifications.Client
{
	[PublicAPI]
	public class NotificationManager
	{
		private readonly ICommunicationManager comms;

		public NotificationManager(ICommunicationManager comms)
		{
			this.comms = comms;
		}

		public void Show(Notification notification)
		{
			this.comms.Event(NotificationsEvents.ShowNotification).ToClient().Emit(notification);
		}
	}
}
