using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HPPay_WebApi.ExtensionMethod
{
    public static class HLFLControllerBaseExtension
    {
        public static IActionResult HLFLOkCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult HLFLFail(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.Ok(data);
        }

        public static IActionResult HLFLBadRequestCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.BadRequest(data);

        }
        public static IActionResult HLFLNotFoundCustom(this ControllerBase controller, object input, object data, ILogger logger)
        {
            return controller.NotFound(data);
        }
    }
}
