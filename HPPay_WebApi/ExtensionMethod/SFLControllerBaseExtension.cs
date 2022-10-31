using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HPPay_WebApi.ExtensionMethod
{
    public static class SFLControllerBaseExtension
    {
        public static IActionResult SFLOkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult SFLFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult SFLBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult SFLNotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }
}
