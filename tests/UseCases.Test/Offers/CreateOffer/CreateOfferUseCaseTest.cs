﻿using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories.DataAccess;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest {
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId) {

        //arrange      
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 100)).Generate();

        var offerRepository = new Mock<OfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());
        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //act
        var act = () => useCase.Execute(itemId, request);

        //assert
        act.Should().NotThrow();

    }
}