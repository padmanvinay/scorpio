using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using scorpio.Data;
using scorpio.Models;

namespace scorpio.Controllers
{
    [ApiController]
    [EnableCors("CorsApi")]
    public class ScorpioController : Controller
    {
        private readonly ScorpioDbContext _dbcontext;

        public ScorpioController(ScorpioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost("GetId")]
        public Response<string> MatchWithProvision([FromBody] Dto dto)
        {
            var response = new Response<string>();
            var PrItemID = _dbcontext.provision.Where(p => p.name.ToLower() == dto.PrItemName.ToLower()).Select(p => p.id).FirstOrDefault();
            var vessel_id = _dbcontext.VesselAddedItem.Where(p => p.name.ToLower() == dto.vesselItemName.ToLower()).Select(p => p.item_id).FirstOrDefault();
            response.PrItemID = PrItemID;
            response.VesselItemId = vessel_id;
            return response;
        }
        [HttpGet("Names")]
        public List<string> ReturnProvision()
        {
            var names = _dbcontext.provision.Where(x => x.from_shore == "True").Select(p => p.name).ToList();
            return names;
        }
        [HttpPost("Querywrite")]
        public IActionResult Post(QueryData queryData)
        {
            var sqlQueries = $"{queryData.QueryOne}\n{queryData.QueryTwo}\n{queryData.QueryThree}\n";
            var folderPath = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath);
            var filePath = Path.Combine(folderPath, "1-Scorpio-update-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write(sqlQueries);
            }
            var sqlQueries1 = $"{queryData.QueryFour}\n";
            var filePath1 = Path.Combine(folderPath, "2-Victualing-update-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath1, true))
            {
                streamWriter.Write(sqlQueries1);
            }
            var sqlQueries2 = $"'{queryData.VesselItemId}',\n";
            var folderPath2 = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath2);
            var filePath2 = Path.Combine(folderPath2, "3-ItemVM-delete-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath2, true))
            {
                if (streamWriter.BaseStream.Length == 0)
                {
                    var sqlQuery = $"delete from item_vessel_mapping where item_id in (";
                    streamWriter.WriteLine(sqlQuery);
                }
                streamWriter.Write(sqlQueries2);
            }
            var sqlQueries3 = $"'{queryData.VesselItemId}',\n";
            var folderPath3 = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath3);
            var filePath3 = Path.Combine(folderPath3, "4-Pr-Select-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath3, true))
            {
                if (streamWriter.BaseStream.Length == 0)
                {
                    var sqlQuery = $"select * from pr_item_details where item_id in (";
                    streamWriter.WriteLine(sqlQuery);
                }
                streamWriter.Write(sqlQueries3);
            }
            var sqlQueries4 = $"'{queryData.VesselItemId}',\n";
            var folderPath4 = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath4);
            var filePath4 = Path.Combine(folderPath4, "5-Po-Select-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath4, true))
            {
                if (streamWriter.BaseStream.Length == 0)
                {
                    var sqlQuery = $"select * from po_item_details where item_id in (";
                    streamWriter.WriteLine(sqlQuery);
                }
                streamWriter.Write(sqlQueries4);
            }
            var sqlQueries5 = $"'{queryData.VesselItemId}',\n";
            var folderPath5 = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath5);
            var filePath5 = Path.Combine(folderPath5, "6-Quote-Select-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath5, true))
            {
                if (streamWriter.BaseStream.Length == 0)
                {
                    var sqlQuery = $"select * from quote_item_details where item_id in (";
                    streamWriter.WriteLine(sqlQuery);
                }
                streamWriter.Write(sqlQueries5);
            }
            var sqlQueries6 = $"'{queryData.VesselItemId}',\n";
            var folderPath6 = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath6);
            var filePath6 = Path.Combine(folderPath6, "7-StockItems-Select-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath6, true))
            {
                if (streamWriter.BaseStream.Length == 0)
                {
                    var sqlQuery = $"select * from stock_items where item_id in (";
                    streamWriter.WriteLine(sqlQuery);
                }
                streamWriter.Write(sqlQueries6);
            }

            var sqlQueries8 = $"'{queryData.VesselItemId}',\n";
            var folderPath8 = queryData.vesselnumber;
            Directory.CreateDirectory(folderPath8);
            var filePath8 = Path.Combine(folderPath8, "8-ItemMaster-delete-Queries.sql");
            using (var streamWriter = new StreamWriter(filePath8, true))
            {
                if (streamWriter.BaseStream.Length == 0)
                {
                    var sqlQuery = $"delete from item_master where item_id in (";
                    streamWriter.WriteLine(sqlQuery);
                }
                streamWriter.Write(sqlQueries8);
            }
            return Ok(new { Message = "Queries saved to file!" });
        }

    }
}