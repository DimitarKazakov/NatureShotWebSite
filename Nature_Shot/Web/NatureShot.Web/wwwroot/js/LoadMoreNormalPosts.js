﻿(function ($) {
    "use strict";

    const btnLoad = document.querySelector('.loadMore');
    btnLoad.addEventListener('click', LoadMore);

    function LoadMore() {
        console.log("clicked");
        let xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function (e) {

            if (this.readyState == 4 && this.status == 200) {

                const scrollHeight = window.scrollY;
                const scrollWidth = window.scrollX;

                let posts = JSON.parse(this.response);

                if (posts.length > 0) {
                    for (var i = 0; i < posts.length; i++) {

                        let post = posts[i];

                        let normalPostHtml = "<div class=\"row justify-content-center no-gutters mb-5\"><div class=\"text-center h-100 project border border-primary rounded-pill\"><div class=\"d-flex h-100 border border-primary rounded-pill\"><div class=\"project-text w-100 my-auto text-center border border-primary rounded-pill\"><h4 class=\"text-black mb-4\"><span class=\"border-primary border-bottom\">" + post.username + "</span></h4><br><p class=\"text-black mb-0\"><span class=\"border-bottom border-primary\">" + posts.tags + "</span></p><br><p class=\"mb-0 text-black\">" + post.caption + "</p><br><div class=\"row\"><p class=\"col-3\"></p><p class=\"text-black mb-0 col-3\"><span class=\"border-primary border-bottom\">Likes: <span class=\"text-black\">" + post.likes + "</span></span></p><p class=\"text-black mb-0 col-3\"><span class=\"border-primary border-bottom\">Dislikes: <span class=\"text-black\">" + post.dislikes + "</span></span></p><p class=\"col-3\"></p></div><br><form method=\"post\"><button class=\"btn btn-outline-primary border-primary border mr-3 mb-3 mb-l-0\"><i class=\"fas fa-thumbs-up\"></i> Like</button><button class=\"btn btn-outline-primary border-primary border mb-3 mb-l-0\"><i class=\"fas fa-thumbs-down\"></i> Dislike</button></form></div></div></div></div>";

                        document.querySelector("#normalPostsDiv").innerHTML += normalPostHtml;
                    }

                    window.scroll(scrollWidth, scrollHeight);

                    document.querySelector('.loadMore').addEventListener('click', LoadMore);
                }
                else {
                    btnLoad.textContent = "No more posts...";
                    btnLoad.setAttribute("disabled", true);
                }
            }
        }

        const pageNumber = parseInt(btnLoad.getAttribute("value"), 10);
        xhr.open("GET", "/api/NormalPostsAjax/" + pageNumber);
        btnLoad.setAttribute("value", pageNumber + 1);
        xhr.send();
    }

})(jQuery);