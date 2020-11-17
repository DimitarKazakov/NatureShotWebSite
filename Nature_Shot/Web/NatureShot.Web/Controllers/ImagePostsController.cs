namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Web.ViewModels.Images;

    [Route("api/[controller]")]
    [ApiController]
    public class ImagePostsController : ControllerBase
    {
        public ImagePostsController()
        {
        }

        [HttpGet("{id}")]
        public ICollection<ImagePostViewModel> LoadMoreImages(int id)
        {
            var imageList = new List<ImagePostViewModel>()
            {
                new ImagePostViewModel
                {
                    Username = "Dimitur Dinkov",
                    ImageUrl = "http://res.cloudinary.com/drw0gj3qi/image/upload/v1605470739/a7dwxdo8bnmqnrxe5lju.jpg",
                    Camera = "IPhone 5",
                    Caption = "Very good and beautiful place",
                    Likes = "12",
                    Dislikes = "3",
                    Location = "Sofia/Bulgaria",
                    Tags = "#wow #sunny #amazing",
                    Type = "horizontal",
                },
                new ImagePostViewModel
                {
                    Username = "Dimitur Kazakov",
                    ImageUrl = "http://res.cloudinary.com/drw0gj3qi/image/upload/v1605470739/a7dwxdo8bnmqnrxe5lju.jpg",
                    Camera = "IPhone 6",
                    Caption = "Very good and beautiful place and peaceful",
                    Likes = "123",
                    Dislikes = "32",
                    Location = "Plovdiv/Bulgaria",
                    Tags = "#wow #rainy #amazing",
                    Type = "horizontal",
                },
                new ImagePostViewModel
                {
                    Username = "Ivan Dinkov",
                    ImageUrl = "http://res.cloudinary.com/drw0gj3qi/image/upload/v1605470739/a7dwxdo8bnmqnrxe5lju.jpg",
                    Camera = "IPhone XS",
                    Caption = "Very good and beautiful place and rich of green place",
                    Likes = "1212",
                    Dislikes = "3123",
                    Location = "Varna/Bulgaria",
                    Tags = "#wow #sunny #amazing #beautiful",
                    Type = "horizontal",
                },
            };

            return imageList;
        }
    }
}
