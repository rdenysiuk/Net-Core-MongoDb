using CarXUnitIntegration.Utility;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarXUnitIntegration
{
    public class CarApiIntegrationTest
    {
        private HttpClient _client = new TestClientProvider().Client;

        [Fact]
        public async Task  Get_ShouldReturnCarModelList()
        {
            //Arange
            var responce = await _client.GetAsync(ApiRoutes.Car.GetAll);
            //Act
            //Assert 
            responce.EnsureSuccessStatusCode();
        }
        /*
        [Fact]
        public void Get_ShouldReturnCarModelList()
        {
            //Arange
            //Act
            //Assert        
        }
        */
    }

}
