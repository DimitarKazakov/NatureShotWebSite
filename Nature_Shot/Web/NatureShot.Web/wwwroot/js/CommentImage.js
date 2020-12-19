(function ($) {
    "use strict";

    const container = document.querySelector('#photosClick').addEventListener('click', MakeComment);


    function MakeComment(e) {
        const target = e.target;
        if (target.hasAttribute('id') && target.getAttribute('id') == 'comment') {

            const inputDiv = e.target.parentElement.parentElement;
            const commentInput = inputDiv.querySelector('#commentInput').value;
            if (commentInput != '' && commentInput.length <= 300) {
                const imageInfo = inputDiv.parentElement;
                const antiForgeryToken = document.querySelector('input[name=__RequestVerificationToken]').getAttribute('value');
                const imageId = imageInfo.querySelector('#id').textContent;

                $.ajax({
                    type: "Post",
                    url: "/api/ImagePostsAjax",
                    data: JSON.stringify({ comment: commentInput, id: imageId }),
                    headers: {
                        'X-CSRF-TOKEN': antiForgeryToken
                    },
                    success: function () {
                        inputDiv.querySelector('#commentInput').value = '';
                    },
                    contentType: 'application/json',
                });
            }
        }


    }

})(jQuery);