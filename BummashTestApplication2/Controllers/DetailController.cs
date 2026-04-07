using BummashTestApplication.ModelPrototypes;
using BummashTestApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BummashTestApplication
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;

        private readonly IDetailService _detailService;

        public DetailController(IDetailService detailService, ILogger<DetailController> logger)
        {
            _detailService = detailService;
            _logger = logger;
        }

        //[HttpGet("Index")]
        public IActionResult Index()
        {
            return Redirect("~/Detail/Calculations");
        }

        public IActionResult Calculations()
        {
            return View();
        }

        public IActionResult Results([FromForm] InitialDetailModel detailModel)
        {
            DetailModel model = new DetailModel();
            DetailProbeModel probeModel = new DetailProbeModel();

            model = (DetailModel)_detailService.CalculateDetail(detailModel, model);
            probeModel = (DetailProbeModel)_detailService.CalculateDetail(detailModel, probeModel);

            IResultDetailModel _resultDetailModel = new ResultDetailModel(model, probeModel);

            ViewData["di"] = "⌀" + _resultDetailModel.DiameterInner;
            ViewData["di_"] = _resultDetailModel.DiameterInnerBlank + "±" + _resultDetailModel.DiameterInnerBlankDelta;

            ViewData["do"] = "⌀" + _resultDetailModel.DiameterOuter;
            ViewData["do_"] = _resultDetailModel.DiameterOuterBlank + "±" + _resultDetailModel.DiameterOuterBlankDelta;

            ViewData["H"] = _resultDetailModel.Height;
            ViewData["H_"] = _resultDetailModel.HeightBlank + "±" + _resultDetailModel.HeightBlankDelta;

            ViewData["MassNominal"] = _resultDetailModel.MassNominal.ToString("f3");
            ViewData["MassMaximal"] = _resultDetailModel.MassMaximal.ToString("f3");

            ViewData["di2"] = "⌀" + _resultDetailModel.DiameterInnerProbe;
            ViewData["di_2"] = _resultDetailModel.DiameterInnerBlankProbe + "±" + _resultDetailModel.DiameterInnerBlankDeltaProbe;

            ViewData["do2"] = "⌀" + _resultDetailModel.DiameterOuterProbe;
            ViewData["do_2"] = _resultDetailModel.DiameterOuterBlankProbe + "±" + _resultDetailModel.DiameterOuterBlankDeltaProbe;

            ViewData["H2"] = _resultDetailModel.HeightProbe;
            ViewData["H_2"] = _resultDetailModel.HeightBlankProbe + "±" + _resultDetailModel.HeightBlankDeltaProbe;

            ViewData["MassNominal2"] = _resultDetailModel.MassNominalProbe.ToString("f3");
            ViewData["MassMaximal2"] = _resultDetailModel.MassMaximalProbe.ToString("f3");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
