using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _data;
        public NotificationController (NotificationService data)
        {
            _data = data;
        }
        [HttpGet]
        [Route("GetNotificationByUserId/{userId}")]
        public List<NotificationDTO> GetNotificationByUserId(int userId)
        {
            return _data.GetNotificationByUserId(userId);
        }

    }
}