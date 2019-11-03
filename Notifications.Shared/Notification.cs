using System;

namespace NFive.Notifications.Shared
{
	public class Notification
	{
		public string Text { get; set; }

		public string Type { get; set; }

		public TimeSpan? Timeout { get; set; }
	}
}
