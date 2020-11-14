using AutoMapper;
using DataServiceLib.DataServices;
using DataServiceLib.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SubProject.Controllers;
using SubProject.Dto;
using System;
using Xunit;

namespace TestingProject
{
    public class Testing
    {
        private Mock<IMoviesDS> _movieDSMock;
        private Mock<IUserDS> _userDSMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IUrlHelper> _urlMock;

        public Testing()
        {
            _userDSMock = new Mock<IUserDS>();
            _movieDSMock = new Mock<IMoviesDS>();
            _mapperMock = new Mock<IMapper>();
            _urlMock = new Mock<IUrlHelper>();
        }

        [Fact]
        public void GetMovieShouldCallDataService()
        {
            var ctrl = new MovieController(_movieDSMock.Object, _mapperMock.Object);

            ctrl.GetMovie("");

            _movieDSMock.Verify(x => x.GetMovie(""), Times.Once);
        }

        [Fact]
        public void GetMovieWithValidIdSouldRetrunOk()
        {
            _movieDSMock.Setup(x => x.GetMovie("tt10850402")).Returns(new TitleBasics {});
            _mapperMock.Setup(x => x.Map<MovieDto>(It.IsAny<TitleBasics>())).Returns(new MovieDto());

            var ctrl = new MovieController(_movieDSMock.Object, _mapperMock.Object);
            ctrl.Url = _urlMock.Object;

            var response = ctrl.GetMovie("tt10850402");

            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetUserWithInvalidIdSouldRetrunNotFound()
        {
            var ctrl = new UserController(_userDSMock.Object, null);

            var response = ctrl.GetUser("");

            response.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetUserWithValidIdSouldRetrunOk()
        {
            _userDSMock.Setup(x => x.GetUser("saroj121")).Returns(new User { });
            _mapperMock.Setup(x => x.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto());

            var ctrl = new UserController(_userDSMock.Object, _mapperMock.Object);
            ctrl.Url = _urlMock.Object;

            var response = ctrl.GetUser("saroj121");

            response.Should().BeOfType<OkObjectResult>();
        }
    }
}
