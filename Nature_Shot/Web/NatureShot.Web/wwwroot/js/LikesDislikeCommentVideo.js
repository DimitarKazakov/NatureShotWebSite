(function ($) {
    "use strict";

    const likes = document.querySelector('#likeModalTrigger').addEventListener('click', ShowModal);
    const dislikes = document.querySelector('#dislikeModalTrigger').addEventListener('click', ShowModal);
    const comments = document.querySelector('#commentModalTrigger').addEventListener('click', ShowModal);


    function ShowModal(e) {
        let target = e.target;
        if (target.hasAttribute('id') && (target.getAttribute('id') == 'likesName' ||
            target.getAttribute('id') == 'dislikesName' ||
            target.getAttribute('id') == 'commentsName')) {
            target = e.target.parentElement;
        }

        const modalType = target.getAttribute('id');
        const id = target.parentElement.parentElement.parentElement.querySelector('#id').textContent;

        let xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function (e) {

            if (this.readyState == 4 && this.status == 200) {
                const modalReactionHeaderTitle = document.querySelector('#modalHeader').querySelector('#listOfUsersModalTitle');
                const modalReactionBody = document.querySelector('#modalBody');

                if (modalType == 'likeModalTrigger') {
                    modalReactionHeaderTitle.textContent = 'Likes';
                }
                else if (modalType == 'dislikeModalTrigger') {
                    modalReactionHeaderTitle.textContent = 'Dislikes';
                }
                else if (modalType == 'commentModalTrigger') {
                    modalReactionHeaderTitle.textContent = 'Comments';
                }

                let reactions = JSON.parse(this.response);

                if (reactions.length > 0) {
                    if (modalType != 'commentModalTrigger') {
                        modalReactionBody.innerHTML = "";
                        for (var i = 0; i < reactions.length; i++) {
                            modalReactionBody.innerHTML += "<p>" + reactions[i].user + "</p>"
                        }
                    }
                    else {
                        modalReactionBody.innerHTML = "";
                        console.log("commentModalTrigger");
                        for (var i = 0; i < reactions.length; i++) {
                            modalReactionBody.innerHTML += "<h5>" + reactions[i].user + "</h5><p>" + reactions[i].content + "</p><br>"
                        }
                    }
                }
                else {
                    if (modalType == 'likeModalTrigger') {
                        modalReactionBody.innerHTML = "";
                        modalReactionBody.innerHTML = "<h4>No Likes</h4>";
                    }
                    else if (modalType == 'dislikeModalTrigger') {
                        modalReactionBody.innerHTML = "";
                        modalReactionBody.innerHTML = "<h4>No Dislikes</h4>";

                    }
                    else if (modalType == 'commentModalTrigger') {
                        modalReactionBody.innerHTML = "";
                        modalReactionBody.innerHTML = "<h4>No Comments</h4>";

                    }
                }
                $('#listOfUsersModal').modal('show')
            }
        }

        xhr.open("GET", "/api/ReactionPostsAjax" + "?postId=" + id + "&reaction=" + modalType);
        xhr.send();
    }

})(jQuery);