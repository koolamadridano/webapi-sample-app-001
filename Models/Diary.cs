/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 27/12/2020
 * Time: 12:11 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	public class Diary
	{
		public int Id { get; set; }
		public int specialId { get; set; }
		public string PostedBy { get; set; }
		public string Category { get; set; }
		public string Content { get; set; }
		public string DatePosted { get; set; }
	}
}
