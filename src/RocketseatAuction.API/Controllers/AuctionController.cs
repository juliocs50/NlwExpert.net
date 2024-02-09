﻿using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
namespace RocketseatAuction.API.Controllers;

public class AuctionController : RocketseatAuctionBaseController {
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction() {
        var userCase = new GetCurrentAuctionUseCase();
        var result = userCase.Execute();
        if (result is null) {
            return NoContent();
        }
        return Ok(result);
    }

}
