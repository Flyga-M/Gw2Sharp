using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class ServerErrorExceptionExceptionTests
    {
        [Fact]
        public void SerializableTest()
        {
            var request = new HttpRequest(new Uri("http://localhost"), new Dictionary<string, string> { { "hello", "tyria" } });
            var response = new HttpResponse<ErrorObject>(new ErrorObject { Text = "Error" }, HttpStatusCode.InternalServerError, null, null);
            var exception = new ServerErrorException(request, response);
            exception.Should().BeBinarySerializable();
        }
    }
}
