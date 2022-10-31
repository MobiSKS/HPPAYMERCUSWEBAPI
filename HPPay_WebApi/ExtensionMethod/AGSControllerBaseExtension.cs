using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

namespace HPPay_WebApi.ExtensionMethod
{
    public static  class AGSControllerBaseExtension
    {

        public static IActionResult AGSOkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult AGSFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult AGSBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult AGSNotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }
}
