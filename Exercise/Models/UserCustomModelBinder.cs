using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Models
{
    public class UserCustomModelBinder : DefaultModelBinder
    {

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(UserViewModels))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                string firstName = request.Form.Get("FirstName");
                string lastName = request.Form.Get("LastName");
                string email = request.Form.Get("Email");
                string day = request.Form.Get("DateOfBirth.Day");
                string month = request.Form.Get("DateOfBirth.Month");
                string year = request.Form.Get("DateOfBirth.Year");


                ModelBindingContext newBindingContext = new ModelBindingContext()
                {

                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(
                        () => new UserViewModels()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            DateOfBirth = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day))
                        },
                        typeof(UserViewModels)
                    ),
                    ModelState = bindingContext.ModelState,
                    ValueProvider = bindingContext.ValueProvider

                };

                // call the default model binder this new binding context
                return base.BindModel(controllerContext, newBindingContext);
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}