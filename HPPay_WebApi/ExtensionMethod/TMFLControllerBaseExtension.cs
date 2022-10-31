using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HPPay_WebApi.ExtensionMethod
{
    public static class TMFLControllerBaseExtension
    {
        public static IActionResult TMFLOkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult TMFLFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult TMFLBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult TMFLNotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }
}
