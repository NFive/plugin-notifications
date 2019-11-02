using JetBrains.Annotations;
using NFive.Notifications.Shared;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Communications;
using NFive.SDK.Server.Controllers;

namespace NFive.Notifications.Server
{
	[PublicAPI]
	public class NotificationsController : ConfigurableController<Configuration>
	{
		public NotificationsController(ILogger logger, Configuration configuration, ICommunicationManager comms) : base(logger, configuration)
		{
			// Send configuration when requested
			comms.Event(NotificationsEvents.Configuration).FromClients().OnRequest(e => e.Reply(this.Configuration));
		}
	}
}
