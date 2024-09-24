using System.Collections.Generic;

namespace App.Entity.Models.Facebook
{





	//facebook send message

	public class FacebookMessageModel
	{
		public string _object { get; set; }
		public List<Entry> entry { get; set; }
	}

	public class Entry
	{
		public string id { get; set; }
		public long time { get; set; }
		public List<Messaging> messaging { get; set; }
	}

	public class Messaging
	{
		public Sender sender { get; set; }
		public Recipient recipient { get; set; }
		public long timestamp { get; set; }
		public Message message { get; set; }
	}

	public class Sender
	{
		public string id { get; set; }
	}

	public class Recipient
	{
		public string id { get; set; }
	}

	public class Message
	{
		public string mid { get; set; }
		public string text { get; set; }
	}


	//facebook login button
	public class FacebookLoginModel
	{
		public FacebookRecipient recipient { get; set; }
		public FacebookMessage message { get; set; }
	}

	public class FacebookRecipient
	{
		public string id { get; set; }
	}

	public class FacebookMessage
	{
		public Attachment attachment { get; set; }
	}

	public class Attachment
	{
		public string type { get; set; }
		public Payload payload { get; set; }
	}

	public class Payload
	{
		public string template_type { get; set; }
		public string text { get; set; }
		public List<Button> buttons { get; set; }
	}

	public class Button
	{
		public string type { get; set; }
		public string url { get; set; }
	}





}
