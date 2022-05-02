using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectNS.Model;
using ProjectNS.Service;
using ProjectNS.ViewModel;
using System;

namespace ProjectNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDAClassificationController : Controller
    {
        private readonly FDAClassificationService _fdaclassificationservice;
        public FDAClassificationController(FDAClassificationService fdaclassificationservice)
        {
            _fdaclassificationservice = fdaclassificationservice;
        }

        [HttpGet]
        [Route("FDAClassifications")]
        public IActionResult FDAClassifications()
        {
            try
            {
                var fdaclassificationlist = _fdaclassificationservice.FDAClassifications();
                return StatusCode(StatusCodes.Status200OK, fdaclassificationlist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("FDAClassificationById")]
        public IActionResult FDAClassificationById(int FDAClassificationId)
        {
            try
            {
                var fdaclassification = _fdaclassificationservice.FDAClassificationById(FDAClassificationId);
                return StatusCode(StatusCodes.Status200OK, fdaclassification);
            }
            catch (Exception ex)
            {
               return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("AddFDAClassification")]
        public IActionResult AddFDAClassification([FromBody] FDAClassificationVM fDAClassification)
        {
            try
            {
                _fdaclassificationservice.AddFDAClassification(fDAClassification);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Details Added Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateFDAClassification")]
        public IActionResult UpdateFDAClassification(FDAClassificationVM fDAClassification)
        {
            try
            {
                _fdaclassificationservice.UpdateFDAClassification(fDAClassification);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Details Updated Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteFDAClassification/{FDAClassificationId}")]
        public IActionResult DeleteFDAClassification(int FDAClassificationId)
        {
            try
            {
                _fdaclassificationservice.DeleteFDAClassification(FDAClassificationId);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Details Deleted Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }
    }
}
