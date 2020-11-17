(function ($) {
    "use strict";

    document.querySelector('.loadMore').addEventListener('click', LoadMore);

    function LoadMore() {
        console.log("clicked");
        let xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function (e) {

            if (this.readyState == 4 && this.status == 200) {

                const scrollHeight = window.scrollY;
                const scrollWidth = window.scrollX;

                let images = JSON.parse(this.response);


                for (var i = 0; i < images.length; i++) {

                    let image = images[i];

                    let horizontalLeftImage = "<div class=\"row align-items-center no-gutters mb-4 mb-lg-5\"><div class=\"col-xl-8 col-lg-7\"><img class=\"img-fluid z-depth-1 mb-3 mb-lg-0\" src=\"" + image.imageUrl + "\" alt=\"Image\" data-toggle=\"modal\" data-target=\"#modal1\" /></div><div class=\"col-xl-4 col-lg-5\"><div class=\"featured-text text-center text-lg-left\"><h4>" + image.username + "</h4><p class=\"text-black-50 mb-0\"><u>" + image.tags + "</u></p><br><p class=\"text-black-50 mb-0\">" + image.caption + "</p><p class=\"text-black-50 mb-0 locationText\" hidden>Location: <span class=\"text-dark\">" + image.location + "</span></p><p class=\"text-black-50 mb-0 cameraText\" hidden>Camera: <span class=\"text-dark\">" + image.camera + "</span></p><p class=\"text-black-50 mb-0 likesText\" hidden>Likes: <span class=\"text-dark\">" + image.likes + "</span></p><p class=\"text-black-50 mb-0 dislikesText\" hidden>Dislikes: <span class=\"text-dark\">" + image.dislikes + "</span></p><br><br><br><br><div class=\"input-group mb-3\"><input type=\"text\" class=\"form-control\" placeholder=\"Write a comment . . .\" aria-label=\"comment\" aria-describedby=\"basic-addon2\"><div class=\"input-group-append\"><span class=\"input-group-text bg-outline-dark\" id=\"basic-addon2\"><a href=\"\"><i class=\"fa fa-share-square\" aria-hidden=\"true\"></i></a></span></div></div><form method=\"post\"><button class=\"btn btn-outline-dark mr-3\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button class=\"btn btn-outline-dark\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button ></form ></div ></div ></div> ";
                    let smallHorizontalLeftImage = "<div class=\"row align-items-center no-gutters mb-4 mb-lg-5\"><div class=\"col-xl-4 col-lg-5\"><img class=\"img-fluid z-depth-1 mb-3 mb-lg-0\" src=\"" + image.imageUrl + "\" alt=\"Image\" data-toggle=\"modal\" data-target=\"#modal1\" /></div><div class=\"col-xl-8 col-lg-7 mb-5\"><div class=\"featured-text text-center text-lg-left\"><h4>" + image.username + "</h4><p class=\"text-black-50 mb-0\"><u>" + image.tags + "</u></p><br><p class=\"text-black-50 mb-0\">" + image.caption + "</p><p class=\"text-black-50 mb-0 locationText\" hidden>Location: <span class=\"text-dark\">" + image.location + "</span></p><p class=\"text-black-50 mb-0 cameraText\" hidden>Camera: <span class=\"text-dark\">" + image.camera + "</span></p><p class=\"text-black-50 mb-0 likesText\" hidden>Likes: <span class=\"text-dark\">" + image.likes + "</span></p><p class=\"text-black-50 mb-0 dislikesText\" hidden>Dislikes: <span class=\"text-dark\">" + image.dislikes + "</span></p><br><br><br><br><div class=\"input-group mb-3\"><input type=\"text\" class=\"form-control\" placeholder=\"Write a comment . . .\" aria-label=\"comment\" aria-describedby=\"basic-addon2\"><div class=\"input-group-append\"><span class=\"input-group-text bg-outline-dark\" id=\"basic-addon2\"><a href=\"\"><i class=\"fa fa-share-square\" aria-hidden=\"true\"></i></a></span></div></div><form method=\"post\"><button class=\"btn btn-outline-dark mr-3\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button class=\"btn btn-outline-dark\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button ></form ></div ></div ></div> ";

                    let horizontalRightImage = "<div class=\"row align-items-center no-gutters mb-4 mb-lg-5\"><div class=\"col-xl-8 col-lg-7\"><img class=\"img-fluid z-depth-1 mb-3 mb-lg-0\" src=\"" + image.imageUrl + "\" alt=\"Image\" data-toggle=\"modal\" data-target=\"#modal1\" /></div><div class=\"col-xl-4 col-lg-5 order-lg-first\"><div class=\"featured-text-right text-center text-lg-left\"><h4>" + image.username + "</h4><p class=\"text-black-50 mb-0\"><u>" + image.tags + "</u></p><br><p class=\"text-black-50 mb-0\">" + image.caption + "</p><p class=\"text-black-50 mb-0 locationText\" hidden>Location: <span class=\"text-dark\">" + image.location + "</span></p><p class=\"text-black-50 mb-0 cameraText\" hidden>Camera: <span class=\"text-dark\">" + image.camera + "</span></p><p class=\"text-black-50 mb-0 likesText\" hidden>Likes: <span class=\"text-dark\">" + image.likes + "</span></p><p class=\"text-black-50 mb-0 dislikesText\" hidden>Dislikes: <span class=\"text-dark\">" + image.dislikes + "</span></p><br><br><br><br><div class=\"input-group mb-3\"><input type=\"text\" class=\"form-control\" placeholder=\"Write a comment . . .\" aria-label=\"comment\" aria-describedby=\"basic-addon2\"><div class=\"input-group-append\"><span class=\"input-group-text bg-outline-dark\" id=\"basic-addon2\"><a href=\"\"><i class=\"fa fa-share-square\" aria-hidden=\"true\"></i></a></span></div></div><form method=\"post\"><button class=\"btn btn-outline-dark mr-3\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button class=\"btn btn-outline-dark\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button ></form ></div ></div ></div> ";
                    let smallHorizontalRightImage = "<div class=\"row align-items-center no-gutters mb-4 mb-lg-5\"><div class=\"col-xl-4 col-lg-5\"><img class=\"img-fluid z-depth-1 mb-3 mb-lg-0\" src=\"" + image.imageUrl + "\" alt=\"Image\" data-toggle=\"modal\" data-target=\"#modal1\" /></div><div class=\"col-xl-8 col-lg-7 mb-5 order-lg-first\"><div class=\"featured-text-right text-center text-lg-left\"><h4>" + image.username + "</h4><p class=\"text-black-50 mb-0\"><u>" + image.tags + "</u></p><br><p class=\"text-black-50 mb-0\">" + image.caption + "</p><p class=\"text-black-50 mb-0 locationText\" hidden>Location: <span class=\"text-dark\">" + image.location + "</span></p><p class=\"text-black-50 mb-0 cameraText\" hidden>Camera: <span class=\"text-dark\">" + image.camera + "</span></p><p class=\"text-black-50 mb-0 likesText\" hidden>Likes: <span class=\"text-dark\">" + image.likes + "</span></p><p class=\"text-black-50 mb-0 dislikesText\" hidden>Dislikes: <span class=\"text-dark\">" + image.dislikes + "</span></p><br><br><br><br><div class=\"input-group mb-3\"><input type=\"text\" class=\"form-control\" placeholder=\"Write a comment . . .\" aria-label=\"comment\" aria-describedby=\"basic-addon2\"><div class=\"input-group-append\"><span class=\"input-group-text bg-outline-dark\" id=\"basic-addon2\"><a href=\"\"><i class=\"fa fa-share-square\" aria-hidden=\"true\"></i></a></span></div></div><form method=\"post\"><button class=\"btn btn-outline-dark mr-3\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button class=\"btn btn-outline-dark\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button ></form ></div ></div ></div> ";

                    if (i % 2 == 0) {

                        if (image.type == "horizontal") {

                            document.querySelector("#imagesDiv").innerHTML += horizontalLeftImage;
                        }
                        else {

                            document.querySelector("#imagesDiv").innerHTML += smallHorizontalLeftImage;
                        }

                    }
                    else {

                        if (image.type == "horizontal") {

                            document.querySelector("#imagesDiv").innerHTML += horizontalRightImage;
                        }
                        else {

                            document.querySelector("#imagesDiv").innerHTML += smallHorizontalRightImage;
                        }
                    }
                }

                window.scroll(scrollWidth, scrollHeight);

                document.querySelector('.loadMore').addEventListener('click', LoadMore);

            }
        }

        xhr.open("GET", "/api/ImagePosts/3");
        xhr.send();
    }

})(jQuery);