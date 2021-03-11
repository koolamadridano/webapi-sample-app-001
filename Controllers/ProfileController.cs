using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Collections.Generic;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of ProfileController.
	/// </summary>
	public class ProfileController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpPost]
		[Route("api/profile")]		
        public IHttpActionResult Create(Profile profile)
        {
        	_db.Profiles.Add(profile);
            _db.SaveChanges();
            return Ok(profile);
        }
        
	    [HttpGet]
		[Route("api/profile/all")]		
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var profiles = new List<Profile>();
            if(!string.IsNullOrEmpty(keyword))
            {
               profiles = _db.Profiles
               	.Where(x => x.MobileNumber.Contains(keyword))
                    .ToList();
            }
            profiles = _db.Profiles.ToList();
            return Ok(profiles);
        }
        
        [HttpGet]
    	[Route("api/profile/findById/{Id}")]		
        public IHttpActionResult Get(int Id)
        {       
            var profile = _db.Profiles.Find(Id);
            if (profile != null)
                return Ok(profile);
            else
                return BadRequest("Profile not found");
        }
        [HttpGet]
    	[Route("api/profile/findBySpecialId/{Id}")]		
        public IHttpActionResult GetBySpecialId(int Id)
        {       
        	var profile = _db.Profiles.Where(x => x.SpecialId == Id);
            if (profile != null)
                return Ok(profile);
            else
                return BadRequest("Profile not found");
        }
        [HttpDelete]
        [Route("api/profile/{Id}")]		
        public IHttpActionResult Delete(int Id)
        {
            var profile = _db.Profiles.Find(Id);
            if (profile != null)
            {
                _db.Profiles.Remove(profile);
                _db.SaveChanges();
                return Ok("Profile removed successfully!");
            }
            else
                return BadRequest("Profile not found");
        }
        [HttpPut]
        [Route("api/profile")]		
        public IHttpActionResult Update(Profile profileEdit)
        {
            var profile = _db.Profiles.Find(profileEdit.Id);
            
            if (profile != null)
            {	
            	profile.FirstName = profileEdit.FirstName;
            	profile.LastName = profileEdit.LastName;
            	profile.MobileNumber = profileEdit.MobileNumber;
            	profile.ProfileStatus = profileEdit.ProfileStatus;
            	profile.SubscriptionType = profileEdit.SubscriptionType;
            	            	
                _db.Entry(profile).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(profile);
            }
            else
                return BadRequest("Profile not found");
        }
		
	}
}