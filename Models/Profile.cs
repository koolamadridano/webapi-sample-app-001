using System;

namespace SharpDevelopWebApi.Models
{

	public class Profile
	{
//		Id
		public int Id { get; set; }
		public int SpecialId { get; set; }
		
//		Personal details
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MobileNumber { get; set; }
		
//		Account 
		public string DateJoined { get; set; }
		public string ProfileStatus { get; set; }
		public string SubscriptionType { get; set; }
		
//		Account Leader
		public string Leader { get; set; }
	}
}
