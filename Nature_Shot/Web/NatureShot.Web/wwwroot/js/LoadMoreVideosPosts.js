(function ($) {
    "use strict";

    const btnLoad = document.querySelector('.loadMore');
    btnLoad.addEventListener('click', LoadMore);
    const ordeyBy = document.querySelector('#orderByDropDown a.active');

    function LoadMore() {
        let xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function (e) {

            if (this.readyState == 4 && this.status == 200) {
                const scrollHeight = window.scrollY;
                const scrollWidth = window.scrollX;

                let videos = JSON.parse(this.response);

                if (videos.length > 0) {
                    for (var i = 0; i < videos.length; i++) {

                        let video = videos[i];

                        let leftVideo = "<div class=\"row align-items-center no-gutters mb-4 mb-lg-5\"><div class=\"col-xl-8 col-lg-7\"><div class=\"embed-responsive embed-responsive-16by9\"><iframe class=\"embed-responsive-item\" src=\"" + video.videoUrl + "\" frameborder=\"0\" allowfullscreen data-toggle=\"modal\" data-target=\"#modal1\"></iframe></div></div><div class=\"col-xl-4 col-lg-5\"><div class=\"featured-text text-center text-lg-left\"><h4><span class=\"border-bottom border-primary\">" + video.username + "</span></h4><p class=\"text-black-50 mb-0\" id=\"datetime\">" + video.datePosted.format("dddd, dd MMMM yyyy") + "</p><br><p class=\"text-black mb-0\"><span class=\"border-bottom border-primary\">" + video.tags + "</span></p><br><p class=\"text-black-50 mb-0\">" + video.caption + "</p><p class=\"text-black-50 mb-0\" id=\"id\" hidden>" + video.videoId + "</p><p class=\"text-black-50 mb-0 locationText\" hidden>Location: <span class=\"text-dark\">" + video.location + "</span></p><p class=\"text-black-50 mb-0 cameraText\" hidden>Camera: <span class=\"text-dark\">" + video.camera + "</span></p><p class=\"text-black-50 mb-0 likesText\" hidden>Likes: <span class=\"text-dark\">" + video.likes + "</span></p><p class=\"text-black-50 mb-0 dislikesText\" hidden>Dislikes: <span class=\"text-dark\">" + video.dislikes + "</span></p><p class=\"text-black-50 mb-0 lengthText\" hidden>Length: <span class=\"text-dark\">" + video.length + "</span></p><br><br><p class=\"text-black\" id=\"infoTrigger\"><span class=\"border-bottom border-primary\">Click for information</span></p><br><br><div class=\"input-group mb-3\"><input type=\"text\" class=\"form-control\" id=\"commentInput\" placeholder=\"Write a comment . . .\" aria-label=\"comment\" aria-describedby=\"comment\"><div class=\"input-group-append\" id=\"commentDiv\"><span class=\"input-group-text bg-outline-dark\" id=\"comment\"><a href=\"javascript:void(0)\"><i class=\"fa fa-share-square\" aria-hidden=\"true\"></i></a></span></div></div><form method=\"post\" id=\"reaction\"><button type=\"button\" class=\"btn btn-outline-primary mr-3 border border-primary\" value=\"Like\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button type=\"button\" class=\"btn btn-outline-primary border border-primary\" value=\"Dislike\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button></form></div></div></div>";
                        let rightVideo = "<div class=\"row align-items-center no-gutters mb-4 mb-lg-5\"><div class=\"col-xl-8 col-lg-7\"><div class=\"embed-responsive embed-responsive-16by9\"><iframe class=\"embed-responsive-item\" src=\"" + video.videoUrl + "\" frameborder=\"0\" allowfullscreen data-toggle=\"modal\" data-target=\"#modal1\"></iframe></div></div><div class=\"col-xl-4 col-lg-5 order-lg-first\"><div class=\"featured-text-right text-center text-lg-left\"><h4><span class=\"border-bottom border-primary\">" + video.username + "</span></h4><p class=\"text-black-50 mb-0\" id=\"datetime\">" + video.datePosted.format("dddd, dd MMMM yyyy") + "</p><br><p class=\"text-black mb-0\"><span class=\"border-bottom border-primary\">" + video.tags + "</span></p><br><p class=\"text-black-50 mb-0\">" + video.caption + "</p><p class=\"text-black-50 mb-0\" id=\"id\" hidden>" + video.videoId + "</p><p class=\"text-black-50 mb-0 locationText\" hidden>Location: <span class=\"text-dark\">" + video.location + "</span></p><p class=\"text-black-50 mb-0 cameraText\" hidden>Camera: <span class=\"text-dark\">" + video.camera + "</span></p><p class=\"text-black-50 mb-0 likesText\" hidden>Likes: <span class=\"text-dark\">" + video.likes + "</span></p><p class=\"text-black-50 mb-0 dislikesText\" hidden>Dislikes: <span class=\"text-dark\">" + video.dislikes + "</span></p><p class=\"text-black-50 mb-0 lengthText\" hidden>Length: <span class=\"text-dark\">" + video.length + "</span></p><br><br><p class=\"text-black\" id=\"infoTrigger\"><span class=\"border-bottom border-primary\">Click for information</span></p><br><br><div class=\"input-group mb-3\"><input type=\"text\" class=\"form-control\" id=\"commentInput\" placeholder=\"Write a comment . . .\" aria-label=\"comment\" aria-describedby=\"comment\"><div class=\"input-group-append\" id=\"commentDiv\"><span class=\"input-group-text bg-outline-dark\" id=\"comment\"><a href=\"javascript:void(0)\"><i class=\"fa fa-share-square\" aria-hidden=\"true\"></i></a></span></div></div><form method=\"post\" id=\"reaction\"><button type=\"button\" class=\"btn btn-outline-primary mr-3 border border-primary\" value=\"Like\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button type=\"button\" class=\"btn btn-outline-primary border border-primary\" value=\"Dislike\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button></form></div></div></div>";

                        if (i % 2 == 0) {

                            document.querySelector("#videosDiv").innerHTML += leftVideo;


                        }
                        else {

                            document.querySelector("#videosDiv").innerHTML += rightVideo;
                        }
                    }

                    window.scroll(scrollWidth, scrollHeight);

                    document.querySelector('.loadMore').addEventListener('click', LoadMore);
                }
                else {
                    btnLoad.textContent = "No more videos...";
                    btnLoad.setAttribute("disabled", true);
                }
            }
        }

        const paramsInUrl = new URLSearchParams(window.location.search);
        const searchByParam = paramsInUrl.get('searchBy');
        const searchInputParam = paramsInUrl.get('searchInput');

        const pageNumber = parseInt(btnLoad.getAttribute("value"), 10);
        xhr.open("GET", "/api/VideosPostsAjax/" + pageNumber + "?order=" + ordeyBy.textContent + "&searchBy=" + searchByParam + "&searchInput=" + searchInputParam);
        btnLoad.setAttribute("value", pageNumber + 1);
        xhr.send();
    }

})(jQuery);