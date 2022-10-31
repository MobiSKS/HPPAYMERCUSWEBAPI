using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HPPay_WebApi.ExtensionMethod
{
    public static class CustomerAPIControllerBaseExtension
    {
        public static IActionResult CustomerAPIOkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult CustomerAPIFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult CustomerAPIBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult CustomerAPINotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }
}
