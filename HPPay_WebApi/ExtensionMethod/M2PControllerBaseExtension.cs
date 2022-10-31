using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HPPay_WebApi.ExtensionMethod
{
    public static class M2PControllerBaseExtension
    {
        public static IActionResult M2POkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult M2PFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult M2PBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult M2PNotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }
}
