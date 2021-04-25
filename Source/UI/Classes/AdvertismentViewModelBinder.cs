using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using IMAS.PresentationModel.Model.Advertisment;

namespace ZigmaWeb.UI.Classes
{
    public class AdvertismentViewModelBinder : System.Web.Mvc.DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue0 = bindingContext.ValueProvider.GetValue("ModelType");
            var typeValue = bindingContext.ValueProvider.GetValue("AdvertismentTypeName");
            var type = Type.GetType((string)typeValue.ConvertTo(typeof(string)),
                true
            );
            if (!typeof(AdvertismentPM).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Bad Type");
            }
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = System.Web.Mvc.ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
            return model;
        }
    }
}