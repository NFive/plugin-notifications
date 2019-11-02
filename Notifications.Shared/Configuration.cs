using System;
using NFive.SDK.Core.Controllers;

namespace NFive.Notifications.Shared
{
	public class Configuration : ControllerConfiguration
	{
		public ushort QueueSize { get; set; } = 5;

		public string Layout { get; set; } = "centerLeft";

		public string Theme { get; set; } = "bootstrap-v4";

		public string AnimationOpen { get; set; } = "bounceInLeft";

		public string AnimationClose { get; set; } = "bounceOutLeft";

		public string DefaultType { get; set; } = "info";

		public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(5);
	}
}
