﻿using Microsoft.AspNetCore.Mvc;

namespace SchoolOccurrences.School.API.Helpers
{
    //quando realmente for utilizar descomentar a rotina
    public class BaseController : Controller
    {
        //protected readonly IDomainNotificationHandler<DomainNotification> _notifications;

        //public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        //{
        //    _notifications = notifications;
        //}

        //public bool IsValidOperation()
        //{
        //    return (!_notifications.HasNotifications());
        //}

        //public BadRequestObjectResult BadRequestValidations()
        //{
        //    ModelState.AddModelError("Validate", _notifications.GetNotifications().FirstOrDefault().Value);
        //    return BadRequest(ModelState);
        //}
    }
}
