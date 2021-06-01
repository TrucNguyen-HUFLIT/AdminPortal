using Application.Exceptions;
using Application.Models.Account;
using Application.Models.Profile;
using Application.Services.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AccountRequest = Application.Models.Profile.AccountRequest;

namespace AdminPortal.Filters
{
    #region code cũ
    //public class ModelStateFilter : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            string actionName = context.ActionDescriptor.RouteValues.Values.ToArray()[0];
    //            string controllerName = context.ActionDescriptor.RouteValues.Values.ToArray()[1];

    //            var controller = context.Controller as Controller;
    //            if (actionName == "Edit" && controllerName == "Account")
    //            {
    //                var model = new ProfileViewModel();
    //                model.AccountEdit = (AccountEdit)context.ActionArguments.Values.FirstOrDefault();
    //                context.Result = (IActionResult)controller?.View(model);
    //            }

    //            else if (actionName == "Index" && controllerName == "Profile")
    //            {
    //                var model = new ProfileViewModel();
    //                model.AccountRequest = (Application.Models.Profile.AccountRequest)context.ActionArguments.Values.FirstOrDefault();
    //                context.Result = (IActionResult)controller?.View(model);
    //                if (model.AccountRequest.Password == null )
    //                    context.Result = new RedirectToActionResult(actionName, controllerName, "");
    //            }

    //            //else if (actionName == "ChangePassword" && controllerName == "Profile")
    //            //{
    //            //    var model = new ProfileViewModel();
    //            //    model.ProfileChangePassword = (ProfileChangePassword)context.ActionArguments.Values.FirstOrDefault();
    //            //    context.Result = (IActionResult)controller?.View(model);
    //            //}

    //            else if (actionName == "Create" && controllerName == "Account")
    //            {
    //                AccountCreate modelCreate = (AccountCreate)context.ActionArguments.Values.FirstOrDefault();
    //                context.Result = (IActionResult)controller?.View(modelCreate);
    //            }
    //        }

    //        base.OnActionExecuting(context);
    //    }
    //}

    #endregion

    public class ModelStateFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;
                var model = new ProfileViewModel();
                var accInfo = (context.ActionArguments?.Count > 0
                   ? context.ActionArguments.First().Value
                   : null);
                if(! (accInfo is ProfileChangePassword))
                {
                    //if (accInfo is AccountCreate)
                    //    model.AccountCreate = (AccountCreate)accInfo;
                    //else 
                    if (accInfo is AccountEdit)
                        model.AccountEdit = (AccountEdit)accInfo;
                    else
                    if (accInfo is AccountRequest)
                        model.AccountRequest = (AccountRequest)accInfo;

                    context.Result = (IActionResult)controller?.View(model)
                       ?? new BadRequestResult();
                }    
            }

            base.OnActionExecuting(context);
        }
    }

}
