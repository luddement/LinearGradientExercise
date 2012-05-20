using LinearGradientExercise.Models;
using LinearGradientExercise.Svg;
using Nancy;
using LinearGradientExercise.Validators;

namespace LinearGradientExercise
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            var colorValidator = new ColorValidator();
            var verticalLinearGradientFactory = new VerticalLinearGradientFactory();

            Get["/"] = x => { return View["index"]; };

            Get["/verticalLinearGradient/{color}"] = x =>
                                    {
                                        string color = (string)x.color;
                                        if (!colorValidator.IsHexadecimalRgbColor(color))
                                        {
                                            return 500;
                                        }

                                        RgbHexColor rgbHexColor = new RgbHexColor(color);

                                        var model = verticalLinearGradientFactory.CreateSvgStops(rgbHexColor);

                                        return View["verticalLinearGradient", model]
                                            .WithContentType("image/svg+xml");
                                    };
        }
    }
}