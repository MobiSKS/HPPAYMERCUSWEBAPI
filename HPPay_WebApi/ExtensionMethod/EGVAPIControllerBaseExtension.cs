using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;



namespace HPPay_WebApi.ExtensionMethod
{
    public  static class EGVAPIControllerBaseExtension
    {

        public static IActionResult EGVAPIOkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult EGVAPIFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult EGVAPIBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult EGVAPINotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }

}

