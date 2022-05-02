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
    public class RecallInfoController : Controller
    {
        private readonly RecallInfoService _recallinfoservice;
        public RecallInfoController(RecallInfoService recallinfoservice)
        {
            _recallinfoservice = recallinfoservice;
        }

        [HttpGet]
        [Route("RecallInfos")]
        public IActionResult RecallInfos()
        {
            try
            {
                var recallinfolist = _recallinfoservice.RecallInfos();
                return StatusCode(StatusCodes.Status200OK, recallinfolist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("RecallInfoById")]
        public IActionResult RecallInfoById(int RecallinfoId)
        {
            try
            {
                var recallInfo = _recallinfoservice.RecallInfoById(RecallinfoId);
                return StatusCode(StatusCodes.Status200OK, recallInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("AddRecallInfo")]
        public IActionResult AddRecallInfo([FromBody] RecallInfoVM recallInfo)
        {
            try
            {
                _recallinfoservice.AddRecallInfo(recallInfo);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Details Added Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateRecallInfo")]
        public IActionResult UpdateRecallInfo(RecallInfoVM recallInfo)
        {
            try
            {
                _recallinfoservice.UpdateRecallInfo(recallInfo);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Details Updated Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteRecallInfo/{RecallinfoId}")]
        public IActionResult DeleteRecallInfo(int RecallinfoId)
        {
            try
            {
                _recallinfoservice.DeleteRecallInfo(RecallinfoId);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Details Deleted Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Failed", Message = ex.Message });
            }
        }
    }
}
