(function ($) {
    "use strict";

    const container = document.querySelector('#photosClick').addEventListener('click', CheckForLikeDislike);

    function CheckForLikeDislike(e) {
        if (e.target.tagName == 'BUTTON' && e.target.parentElement.tagName == 'FORM') {

            const typeBtn = e.target.getAttribute('value');
            const id = e.target.parentElement.parentElement.querySelector('#id').textContent;
            const antiForgeryToken = document.querySelector('input[name=__RequestVerificationToken]').getAttribute('value');
            const post = e.target.parentElement.parentElement;

            const likeParag = post.querySelector('#likeSpan');
            const dislikeParag = post.querySelector('#dislikeSpan');

            console.log(id);
            console.log(typeBtn);
            $.ajax({
                type: "Put",
                url: "/api/ImagePostsAjax",
                data: JSON.stringify({ type: typeBtn, id: id }),
                headers: {
                    'X-CSRF-TOKEN': antiForgeryToken
                },
                success: function () {
                    const otherbtn = e.target.parentElement.querySelector('[disabled]');
                    const likes = likeParag.textContent;
                    const dislikes = dislikeParag.textContent;

                    if (otherbtn !== null) {
                        otherbtn.disabled = false;

                        if (typeBtn == 'Like') {
                            dislikeParag.textContent = parseInt(dislikes) - 1;
                            likeParag.textContent = parseInt(likes) + 1;
                        }
                        else {
                            dislikeParag.textContent = parseInt(dislikes) + 1;
                            likeParag.textContent = parseInt(likes) - 1;
                        }
                    }
                    else {
                        if (typeBtn == 'Like') {
                            likeParag.textContent = parseInt(likes) + 1;
                        }
                        else {
                            dislikeParag.textContent = parseInt(dislikes) + 1;
                        }
                    }

                    e.target.disabled = true;

                    console.log('OK');
                },
                contentType: 'application/json',
            });
        }
    }

})(jQuery);