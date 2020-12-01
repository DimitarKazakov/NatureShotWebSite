(function ($) {
    "use strict";

    const container = document.querySelector('#photosClick').addEventListener('click', ShowModal);


    function ShowModal(e) {
        let target = e.target;
        if (e.target.hasAttribute('id') && (target.getAttribute('id') == 'likeModalTrigger' ||
            target.getAttribute('id') == 'dislikeModalTrigger')) {

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

                    let reactions = JSON.parse(this.response);

                    if (reactions.length > 0) {

                        modalReactionBody.innerHTML = "";
                        for (var i = 0; i < reactions.length; i++) {
                            modalReactionBody.innerHTML += "<p>" + reactions[i].user + "</p>"
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
                    }
                    $('#listOfUsersModal').modal('show')
                }
            }
            xhr.open("GET", "/api/ReactionPostsAjax" + "?postId=" + id + "&reaction=" + modalType);
            xhr.send();
        }

    }

})(jQuery);